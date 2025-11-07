using Modern.Grpc.Reflection.Descriptor;

namespace Modern.Grpc.Reflection;

public sealed record FileDescriptorResponse : IMessage<FileDescriptorResponse>
{
    public List<FileDescriptorProto> File { get; } = [];

    public static FileDescriptorResponse Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        var fds = File.Select(x =>
        {
            var w = new CodedBufferWriter();
            x.WriteTo(w);

            return w.GetBytes();
        });

        writer.Write(1, fds);
    }
}