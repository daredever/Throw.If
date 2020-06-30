using BenchmarkDotNet.Running;

namespace ThrowIf.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BaseCompare>();
        }
    }
}