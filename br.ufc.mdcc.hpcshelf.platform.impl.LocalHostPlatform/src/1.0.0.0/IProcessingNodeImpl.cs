using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpcshelf.platform.maintainer.LocalHost;
using br.ufc.mdcc.hpcshelf.platform.Platform;

namespace br.ufc.mdcc.hpcshelf.platform.impl.LocalHostPlatform
{
	public class IProcessingNodeImpl<M> : BaseIProcessingNodeImpl<M>, IProcessingNode<M>
where M:ILocalHost
	{
	}
}
