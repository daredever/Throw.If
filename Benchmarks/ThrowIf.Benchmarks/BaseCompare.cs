using System;
using BenchmarkDotNet.Attributes;

namespace ThrowIf.Benchmarks
{
    [MemoryDiagnoser]
    public class BaseCompare
    {
        [Params(true, false)]
        public bool Condition { get; set; }

        [Benchmark(Baseline = true)]
        public void ExplicitIfStatement()
        {
            try
            {
                if (Condition)
                {
                    throw new Exception($"{nameof(BaseCompare)} is not valid");
                }
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        [Benchmark]
        public void DefaultMessageTemplate()
        {
            try
            {
                Throw.Exception((name, message) => new Exception(message))
                    .If(Condition, nameof(BaseCompare));
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        [Benchmark]
        public void InlineMessageTemplate()
        {
            try
            {
                Throw.Exception((name, message) => new Exception(message))
                    .If(Condition, nameof(BaseCompare), name => $"{name} is not valid");
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}