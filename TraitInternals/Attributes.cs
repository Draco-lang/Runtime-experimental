

[AttributeUsage(AttributeTargets.Class)]
public sealed class TraitImplementation : Attribute
{
    public Type Target { get; }
    public Type Implementation { get; }

    public TraitImplementation(Type target, Type implementation)
        => (Target, Implementation) = (target, implementation);
}

[AttributeUsage(AttributeTargets.Method)]
public sealed class TraitConstraint : Attribute
{
    public string ToConstrain { get; }
    public string TraitName { get; }
    public string[] TraitTypeArgs { get; }

    public TraitConstraint(string toConstrain, string traitName, string[] traitTypeArgs)
        => (ToConstrain, TraitName, TraitTypeArgs) = (toConstrain, traitName, traitTypeArgs);
}

