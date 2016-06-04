/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction;

namespace br.ufc.mdcc.hpcshelf.mapreduce.impl.custom.PartitionFunctionIntegerKeyDefault { 

public abstract class BaseIPartitionIntegerKeyDefaultImpl<OMK>: Computation, BaseIPartitionFunction<OMK>
where OMK:IInteger
{

private IInteger output_key = null;

public IInteger Output_key {
	get {
		if (this.output_key == null)
			this.output_key = (IInteger) Services.getPort("output_key");
		return this.output_key;
	}
}

private OMK input_key = default(OMK);

public OMK Input_key {
	get {
		if (this.input_key == null)
			this.input_key = (OMK) Services.getPort("input_key");
		return this.input_key;
	}
}



}

}
