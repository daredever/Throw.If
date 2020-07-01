using System;
using BenchmarkDotNet.Attributes;
using Dawn;

namespace ThrowIf.Benchmarks
{
    [MemoryDiagnoser]
    public class GuardCompare
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
                    throw new ArgumentException($"{nameof(GuardCompare)} is not valid", nameof(GuardCompare));
                }
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        [Benchmark]
        public void ExplicitIfStatementConcat()
        {
            try
            {
                if (Condition)
                {
                    throw new ArgumentException(nameof(GuardCompare) + " is not valid", nameof(GuardCompare));
                }
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        [Benchmark]
        public void ThrowIfHardcore_Test()
        {
            try
            {
                ThrowTest.ArgumentException().IfHardcode(Condition, nameof(GuardCompare));
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        [Benchmark]
        public void ThrowIfHardcoreWithMessage_Test()
        {
            try
            {
                ThrowTest.ArgumentException(name => $"{nameof(GuardCompare)} is not valid")
                    .If(Condition, nameof(GuardCompare));
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        [Benchmark]
        public void ThrowIfHardcoreWithInlineMessage_Test()
        {
            try
            {
                ThrowTest.ArgumentException()
                    .If(Condition, nameof(GuardCompare), name => $"{nameof(GuardCompare)} is not valid");
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        [Benchmark]
        public void ThrowIf_Test()
        {
            try
            {
                Throw.ArgumentException().If(Condition, nameof(GuardCompare));
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        [Benchmark]
        public void Guard_Test()
        {
            try
            {
                Guard.Argument(Condition, nameof(Condition)).False($"{nameof(GuardCompare)} is not valid");
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}