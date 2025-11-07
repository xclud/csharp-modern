namespace Modern.Grpc.Reflection;

public sealed record ServiceResponse : IMessage<ServiceResponse>
{
    public required string Name { get; set; }
    public static ServiceResponse Deserialize(byte[] bytes)
    {
        var input = new CodedBufferReader(bytes);

        var tag = input.ReadTag();

        var wireType = tag & 0x7;
        var tagNumber = tag >> 3;

        var name = input.readString();


        return new ServiceResponse { Name = name };
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, Name);
    }
}
