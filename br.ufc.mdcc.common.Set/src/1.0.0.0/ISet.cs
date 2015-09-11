using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.Set
{
	public interface ISet<V> : BaseISet<V>, IData
	where V:IData
	{
	}
}