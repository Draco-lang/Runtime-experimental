/*

quack(56)

quack<T> (a : T) = where T : CanQuack<T> = a.Quack()

trait CanQuack<T>
{
    Quack : T -> ()
}

impl CanQuack<int> for int
{
    Quack a = ()
}

*/

// quack(56)
quack(56);

/*

quack<T> (a : T) = where T : CanQuack<T> = a.Quack()

*/
[TraitConstraint(toConstrain: "T", traitName: "CanQuack", traitTypeArgs: new [] { "T" })]
static void quack<T>(T a)
{
    var methodToInvoke = Internals.GetMethod<T, CanQuack<T>, T, Unit>(methodId: 0);
    methodToInvoke(a);
}

/*

trait CanQuack<T>
{
    Quack : T -> ()
}


*/

interface CanQuack<T>
{
    // methodId : 0
    Unit Quack(T a);
}

/*

impl CanQuack<int> for int
{
    Quack a = ()
}

*/

[TraitImplementation(typeof(int), typeof(CanQuack<int>))]
public static class CanQuack_int_impl_for_Int
{
    public static Unit Quack(int i)
    {
        Console.WriteLine($"Quack. {i}");
        return new Unit();
    }
}

