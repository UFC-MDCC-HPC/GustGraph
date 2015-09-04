using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.mapreduce.basic.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.basic.Iterator
{
	public interface IIterator<T> : BaseIIterator<T>, IData
		where T:IData
	{
	}
}