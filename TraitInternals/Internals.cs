using System.Reflection;
using System.Runtime.CompilerServices;

public struct Unit
{

}

public static class Internals
{

    private static Dictionary<(Type, Type, Type, Type), Delegate> cache = new();

    public static Func<A, B> GetMethod<TType, TTrait, A, B>(int methodId)
    {
        var key = (typeof(TType), typeof(TTrait), typeof(A), typeof(B));
        if (cache.TryGetValue(key, out var res))
            return (Func<A, B>)res;
        var mi = TableImpls.methods[(typeof(TType), typeof(TTrait), 0)];
        var f = mi.CreateDelegate<Func<A, B>>();
        cache[key] = f;
        return f;
    }
}

public static class Internals1
{

    private static Dictionary<int, Delegate> cache = new();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Func<A, B> GetMethod<TType, TTrait, A, B>(int methodId)
    {
        var key = typeof(TType).GetHashCode() + typeof(TTrait).GetHashCode() + typeof(A).GetHashCode() + typeof(B).GetHashCode();
        if (cache.TryGetValue(key, out var res))
            return (Func<A, B>)res;
        var mi = TableImpls.methods[(typeof(TType), typeof(TTrait), 0)];
        var f = mi.CreateDelegate<Func<A, B>>();
        cache[key] = f;
        return f;
    }
}

internal static class TableImpls
{
    public static Dictionary<(Type, Type, int), MethodInfo> methods = new () {
        { (typeof(int), typeof(CanQuack<int>), 0), typeof(CanQuack_int_impl_for_Int).GetMethod("Quack")! }
    };
}