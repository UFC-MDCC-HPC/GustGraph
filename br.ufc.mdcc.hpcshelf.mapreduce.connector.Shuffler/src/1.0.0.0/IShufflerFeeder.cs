using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.connector.Shuffler
{
	public interface IShufflerFeeder<TKey, TValue> : BaseIShufflerFeeder<TKey, TValue>
		where TKey:IData
		where TValue:IData
	{
	}
}