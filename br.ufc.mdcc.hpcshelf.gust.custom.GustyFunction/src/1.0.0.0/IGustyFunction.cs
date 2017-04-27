using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.hpcshelf.gust.graph.InputFormat;
using br.ufc.mdcc.hpcshelf.mapreduce.custom.ReduceFunction;

namespace br.ufc.mdcc.hpcshelf.gust.custom.GustyFunction
{
	public interface IGustyFunction<TKey, TValue, OKey, OValue, G, GIF> : BaseIGustyFunction<TKey, TValue, OKey, OValue, G, GIF>, IReduceFunction<TKey, TValue, OKey, OValue>
		where TKey:IData
		where TValue:IData
		where OKey:IData
		where OValue:IData
		where G:IData
		where GIF:IInputFormat
	{
	   // Define o contador de superstep (iteration count)
	   int Superstep { get; set; }

		// Método construtor de grafos
		// void graph_creator();

		// Método getMessages
		//void input_messages();

		// Algoritmo deve possuir pelo menos uma etapa, onde a assinatura é gustx, para x>=0
		void gust0();
	}
}
