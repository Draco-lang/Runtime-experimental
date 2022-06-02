using BenchmarkDotNet.Attributes;
using BenchmarkDotNet;
using BenchmarkDotNet.Running;
using CodegenAnalysis.Benchmarks;


// BenchmarkRunner.Run<Bench>();
CodegenBenchmarkRunner.Run<Bench>();
// Bench.quack(5);
// Bench.quack1(10);

public class Bench
{
    [Benchmark]
    public void TotalOverhead()
    {
        quack(5);
    }

    [Benchmark]
    [CAAnalyze()]
    public void TotalOverhead1()
    {
        quack1(5);
    }

    [TraitConstraint(toConstrain: "T", traitName: "CanQuack", traitTypeArgs: new [] { "T" })]
    public static void quack<T>(T a)
    {
        var methodToInvoke = Internals.GetMethod<T, CanQuack<T>, T, Unit>(methodId: 0);
        methodToInvoke(a);
    }

    [TraitConstraint(toConstrain: "T", traitName: "CanQuack", traitTypeArgs: new [] { "T" })]
    public static void quack1<T>(T a)
    {
        var methodToInvoke = Internals1.GetMethod<T, CanQuack<T>, T, Unit>(methodId: 0);
        methodToInvoke(a);
    }
}


[TraitImplementation(typeof(int), typeof(CanQuack<int>))]
public static class CanQuack_int_impl_for_Int
{
    public static Unit Quack(int i)
    {
        // Console.WriteLine($"Quack. {i}");
        return new Unit();
    }
}

interface CanQuack<T>
{
    // methodId : 0
    Unit Quack(T a);
}