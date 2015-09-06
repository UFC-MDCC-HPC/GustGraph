/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.hpcshelf.mapreduce.custom.SplitFunction
{
	public interface BaseISplitFunction<IMK, IMV, IMAP> : IComputationKind 
		where IMAP:IData
		where IMV:IData
		where IMK:IData
	{
		IMAP Input {get;}
		IIterator<IKVPair<IMK, IMV>> Iterator {get;}
	}
}