using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.hpcshelf.gust.graph.VertexBasic;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.custom.PartitionFunctionVertexBasicKeyDefault {

	public class IPartitionVertexBasicKeyDefaultImpl<TKey> : BaseIPartitionVertexBasicKeyDefaultImpl<TKey>, IPartitionFunction<TKey>
    where TKey:IVertexBasic
	{
		public IPartitionVertexBasicKeyDefaultImpl() { }

		private int number_of_partitions;
		public int NumberOfPartitions {
			get { return number_of_partitions; }
			set { this.number_of_partitions = value; }
		}

		public override void main()
		{
			IVertexBasicInstance input_instance = (IVertexBasicInstance) Input_key.Instance;
			IIntegerInstance output_instance = (IIntegerInstance) Output_key.Instance;

			byte value = input_instance.PId;
			output_instance.Value = value % NumberOfPartitions;
		}
	}
}
