using System;

namespace CorrelationCalc
{
    // se isso for um struct, FirstOrDefault vai retornar vazio. Struct nao é nullable (por padrao...ele herda de ValueType ou algo do tipo)
    public class Range
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Duration => End - Start;
    }
}