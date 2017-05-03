using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.hpc.storm.binding.environment.EnvironmentPortTypeSinglePartner;
using System.Collections.Generic;

namespace br.ufc.mdcc.hpcshelf.gust.port.environment.PortTypeDataSourceGraphInterface
{
	public interface IPortTypeDataSourceGraphInterface : BaseIPortTypeDataSourceGraphInterface, IEnvironmentPortTypeSinglePartner
	{
		object IteratorInstance{ get; }
		IEnumerable<object> fetchContentsKeyValue();
	}
}