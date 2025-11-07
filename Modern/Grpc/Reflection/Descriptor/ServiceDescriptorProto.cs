namespace Modern.Grpc.Reflection.Descriptor;

/// <summary>
/// Describes a service.
/// </summary>
public sealed record ServiceDescriptorProto : IMessage<ServiceDescriptorProto>
{
    public string? Name; // 1
    public List<MethodDescriptorProto> Methods = []; // 2
    public ServiceOptions? Options; // 3


    public static ServiceDescriptorProto Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, Name);
        writer.Write(2, Methods);
        writer.Write(3, Options);
    }
}
