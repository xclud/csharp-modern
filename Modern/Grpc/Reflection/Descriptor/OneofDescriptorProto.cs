namespace Modern.Grpc.Reflection.Descriptor;

/// <summary>
/// Describes a oneof.
/// </summary>
public sealed record OneofDescriptorProto : IMessage<OneofDescriptorProto>
{
    public string? Name; // 1
    public OneofOptions? Options; // 2

    public static OneofDescriptorProto Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, Name);
        writer.Write(2, Options);
    }
}
