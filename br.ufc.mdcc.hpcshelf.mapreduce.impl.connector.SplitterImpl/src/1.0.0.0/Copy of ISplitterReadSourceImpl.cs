using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using System.Collections.Generic;
using br.ufc.mdcc.hpc.storm.binding.task.TaskBindingBase;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingAdvance;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.hpcshelf.mapreduce.port.environment.PortTypeIterator;
using br.ufc.mdcc.hpcshelf.mapreduce.binding.task.TaskBindingData;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.connector.SplitterImpl
{
	public class ISplitterReadSourceImpl<IMK, IMV, BF> : BaseISplitterReadSourceImpl<IMK, IMV, BF>, ISplitterReadSource<IMK, IMV, BF>
		where IMK:IData
		where IMV:IData
		where BF:IPartitionFunction<IMK>
	{
		static private int TAG_SPLIT_PAIR = 246;
		static private int TAG_SPLIT_PAIR_FINISH = 247;

		static private int CHUNK_SIZE = 10;

		public override void main()
		{
			IPortTypeIterator input_instance = (IPortTypeIterator) Source.Client;

			Task_port_data.invoke (ITaskPortData.READ_SOURCE);

			Source.startReadSource ();

			object bin_object = null;

			// CALCULATE TARGETs
			IDictionary<int,Tuple<int,int>> unit_ref = new Dictionary<int, Tuple<int,int>> ();
			int nf = this.FacetMultiplicity [FACET_MAP];
			int m_size = 1;
			foreach (int i in this.FacetIndexes[FACET_MAP]) {   
				int nr0 = m_size;
				m_size += this.UnitSizeInFacet [i] ["map_feeder"];
				for (int k = 0, j = nr0; j < m_size; k++, j++)
					unit_ref [j] = new Tuple<int,int> (i/*, 0 INDEX OF map_feeder */,k);
			}

			bool end_iteration = false;
			while (!end_iteration) // take next chunk
			{
				IActionFuture sync_perform;

				/* All the pairs will be read from the source in a single chunk */

				Task_port_split.invoke (ITaskPortAdvance.READ_CHUNK);
				Task_port_split.invoke (ITaskPortAdvance.PERFORM, out sync_perform);

				Bin_function.NumberOfPartitions = m_size;

				IList<IKVPairInstance<IMK,IMV>>[] buffer = new IList<IKVPairInstance<IMK,IMV>>[m_size];
				for (int i = 0; i < m_size; i++)
					buffer [i] = new List<IKVPairInstance<IMK,IMV>> ();

				// READ CHUNK
				int count = 0;
				while (input_instance.fetch_next (out bin_object) && count < CHUNK_SIZE) 
				{
					IKVPairInstance<IMK,IMV> item = (IKVPairInstance<IMK,IMV>)bin_object;

					this.Input_key.Instance = item.Key;
					Bin_function.go ();
					int index = ((IIntegerInstance)this.Output_key.Instance).Value;

					buffer[index].Add(item);

					count++;
				}

				sync_perform.wait ();

				// PERFORM
				for (int i = 0; i < m_size; i++)
						Split_channel.Send (buffer [i], unit_ref [i], TAG_SPLIT_PAIR);

				if (count < CHUNK_SIZE)
					end_iteration = true;
			}

			// Inform the end of the first iteration
			for (int i = 0; i < m_size; i++)
				Split_channel.Send (new List<IKVPairInstance<IMK,IMV>> (), unit_ref [i], TAG_SPLIT_PAIR_FINISH);		

		}
	}
}
