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
    
    
    public class IPeer_1Impl : br.ufc.pargo.hpe.kinds.Application, IPeer_1 {
        
        private void Go(Object o) {
            ((Activate)(o)).go();
        }
        
        public override void main() {
         /*   IDataSink<br.ufc.mdcc.hpcshelf.platform.maintainer.DataHost.IDataHost> data_sink = ((IDataSink<br.ufc.mdcc.hpcshelf.platform.maintainer.DataHost.IDataHost>)(this.Services.getPort("data_sink")));
            Thread go_data_sink = new Thread(new ParameterizedThreadStart(this.Go));
            go_data_sink.Start(data_sink);
            ISplitterWriteSink<br.ufc.mdcc.hpcshelf.platform.maintainer.DataHost.IDataHost, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.Integer.IInteger> splitter = ((ISplitterWriteSink<br.ufc.mdcc.hpcshelf.platform.maintainer.DataHost.IDataHost, br.ufc.mdcc.common.String.IString, br.ufc.mdcc.common.Integer.IInteger>)(this.Services.getPort("splitter")));
            Thread go_splitter = new Thread(new ParameterizedThreadStart(this.Go));
            go_splitter.Start(splitter);
            go_data_sink.Join();
            go_splitter.Join();*/
        }
    }
}