using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.SplitFunction
{
	public interface ISplitFunction<IMK, IMV, IMAP> : BaseISplitFunction<IMK, IMV, IMAP>
		where IMAP:IData
		where IMV:IData
		where IMK:IData
	{
	}
}