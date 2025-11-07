namespace Modern.Grpc.Reflection.Descriptor;

/// <summary>
/// The protocol compiler can output a FileDescriptorSet containing the .proto files it parses.
/// </summary>
public sealed record FileDescriptorSet : IMessage<FileDescriptorSet>
{
    public List<FileDescriptorProto> File { get; } = [];

    public static FileDescriptorSet Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, File);
    }
}
