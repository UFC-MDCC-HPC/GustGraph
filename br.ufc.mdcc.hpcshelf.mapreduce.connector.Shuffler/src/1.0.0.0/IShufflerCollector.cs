using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler
{
	public interface IShufflerCollector<TKey,TValue,PF> : BaseIShufflerCollector<TKey,TValue,PF>
		where PF:IPartitionFunction<TKey>
		where TKey:IData
		where TValue:IData
	{
	}
}