using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Splitter
{
	public interface ISplitterCollector<IKey,IValue,BF> : BaseISplitterCollector<IKey,IValue,BF>
		where IKey:IData
		where IValue:IData
		where BF:IPartitionFunction<IKey>
	{
	}
}