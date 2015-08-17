using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.basic.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.basic.KVPair
{
	public interface IKVPair<K, V> : BaseIKVPair<K, V>, IData
		where K:IData
		where V:IData
	{
	}
}