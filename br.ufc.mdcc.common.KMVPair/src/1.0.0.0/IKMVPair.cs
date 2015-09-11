using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.KMVPair
{
	public interface IKMVPair<K,MVT> : BaseIKMVPair<K,MVT>, IData
		where K:IData
		where MVT:IData
	{
	}
}