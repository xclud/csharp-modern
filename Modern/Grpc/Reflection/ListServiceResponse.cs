namespace Modern.Grpc.Reflection;

public sealed record ListServiceResponse : IMessage<ListServiceResponse>
{
    public List<ServiceResponse> Services { get; } = [];

    public static ListServiceResponse Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, Services);
    }
}
