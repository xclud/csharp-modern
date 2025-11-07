namespace Modern.Grpc.Reflection;

public sealed record ServerReflectionRequest : IMessage<ServerReflectionRequest>
{
    public string? FileContainingSymbol { get; set; }

    public string? ListServices { get; set; }

    public static ServerReflectionRequest Deserialize(byte[] bytes)
    {
        var input = new CodedBufferReader(bytes);

        var tag = input.ReadTag();

        var wireType = tag & 0x7;
        var tagNumber = tag >> 3;

        string? listService = null;
        string? fileContainingSymbol = null;


        if (tagNumber == 4)
        {
            fileContainingSymbol = input.readString();
        }

        if (tagNumber == 7)
        {
            listService = input.readString();
        }


        return new ServerReflectionRequest
        {
            ListServices = listService,
            FileContainingSymbol = fileContainingSymbol
        };
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(7, ListServices);
    }
}
