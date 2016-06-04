/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.mdcc.hpcshelf.platform.Maintainer;
using br.ufc.mdcc.hpcshelf.platform.maintainer.LocalHost;
using br.ufc.mdcc.hpcshelf.platform.Platform;

namespace br.ufc.mdcc.hpcshelf.platform.impl.LocalHostPlatform 
{
	public abstract class BaseIProcessingNodeImpl<M>: br.ufc.pargo.hpe.kinds.Platform, BaseIProcessingNode<M>
		where M:ILocalHost
	{
		private M maintainer = default(M);

		protected M Maintainer
		{
			get
			{
				if (this.maintainer == null)
					this.maintainer = (M) Services.getPort("maintainer");
				return this.maintainer;
			}
		}
	}
}