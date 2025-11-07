namespace Modern.Grpc.Reflection.Descriptor;

/// <summary>
/// Describes a value within an enum.
/// </summary>
public sealed record EnumValueDescriptorProto : IMessage<EnumValueDescriptorProto>
{
    public string? Name; // 1
    public int? Number; // 2
    public EnumValueOptions? Options; // 3

    public static EnumValueDescriptorProto Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, Name);
        writer.Write(2, Number);
        writer.Write(3, Options);
    }
}
