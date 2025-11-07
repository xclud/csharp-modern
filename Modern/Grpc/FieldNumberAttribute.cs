namespace Modern.Grpc;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class FieldNumberAttribute(uint number) : Attribute
{
    public uint Number { get; set; } = number;
}
