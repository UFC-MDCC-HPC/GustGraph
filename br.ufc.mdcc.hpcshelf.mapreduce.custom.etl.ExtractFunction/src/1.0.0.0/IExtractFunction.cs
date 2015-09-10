using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.etl.ExtractFunction
{
	public interface IExtractFunction<EOT> : BaseIExtractFunction<EOT>
		where EOT:IData
	{
	}
}