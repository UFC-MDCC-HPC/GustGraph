/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;


namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.MapFunction { 

public interface BaseIMapFunction<IMK, IMV, OMK, OMV> : IComputationKind 
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where OMV:IData
{

	IIterator<IKVPair<OMK,OMV>> Output_data {get;}
	IMK Input_key {get;}
	IMV Input_value {get;}


} // end main interface 

} // end namespace 
