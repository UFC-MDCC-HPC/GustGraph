// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.17020
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using br.ufc.pargo.hpe.kinds;
using mapreduce.gust.iterative.sssp.System;
using System;
using System.Threading;


namespace mapreduce.gust.iterative.sssp.SystemImpl {
    
    
    public class IPeer_3Impl : br.ufc.pargo.hpe.kinds.Application, IPeer_3 {
        
        private void Go(Object o) {
            ((Activate)(o)).go();
        }
        
        public override void main() {
           /* IReducer<br.ufc.mdcc.hpcshelf.platform.maintainer.ComputeHost.IComputeHost, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.Integer.IInteger, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.Integer.IInteger, br.ufc.mdcc.hpcshelf.mapreduce.example.cw.Tallier.ITallier> reducer = ((IReducer<br.ufc.mdcc.hpcshelf.platform.maintainer.ComputeHost.IComputeHost, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.Integer.IInteger, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.Integer.IInteger, br.ufc.mdcc.hpcshelf.mapreduce.example.cw.Tallier.ITallier>)(this.Services.getPort("reducer")));
            Thread go_reducer = new Thread(new ParameterizedThreadStart(this.Go));
            go_reducer.Start(reducer);
            ISplitterReduceCollector<br.ufc.mdcc.hpcshelf.platform.maintainer.ComputeHost.IComputeHost, br.ufc.mdcc.common.Integer.IInteger, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.Integer.IInteger, br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction.IPartitionFunction<br.ufc.mdcc.common.Integer.IInteger>, br.ufc.mdcc.hpcshelf.mapreduce.custom.TerminateFunction.ITerminateFunction<br.ufc.mdcc.common.Integer.IInteger, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.Integer.IInteger>> splitter = ((ISplitterReduceCollector<br.ufc.mdcc.hpcshelf.platform.maintainer.ComputeHost.IComputeHost, br.ufc.mdcc.common.Integer.IInteger, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.Integer.IInteger, br.ufc.mdcc.hpcshelf.mapreduce.custom.PartitionFunction.IPartitionFunction<br.ufc.mdcc.common.Integer.IInteger>, br.ufc.mdcc.hpcshelf.mapreduce.custom.TerminateFunction.ITerminateFunction<br.ufc.mdcc.common.Integer.IInteger, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.Integer.IInteger>>)(this.Services.getPort("splitter")));
            Thread go_splitter = new Thread(new ParameterizedThreadStart(this.Go));
            go_splitter.Start(splitter);
            IShufflerReduceFeeder<br.ufc.mdcc.hpcshelf.platform.maintainer.ComputeHost.IComputeHost, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.Integer.IInteger> shuffler = ((IShufflerReduceFeeder<br.ufc.mdcc.hpcshelf.platform.maintainer.ComputeHost.IComputeHost, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.Integer.IInteger>)(this.Services.getPort("shuffler")));
            Thread go_shuffler = new Thread(new ParameterizedThreadStart(this.Go));
            go_shuffler.Start(shuffler);
            go_reducer.Join();
            go_splitter.Join();
            go_shuffler.Join();*/
        }
    }
}
