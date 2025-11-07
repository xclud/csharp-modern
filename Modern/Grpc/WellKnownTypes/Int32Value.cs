namespace Modern.Grpc.WellKnownTypes;

public sealed record Int32Value : IMessage<Int32Value>
{
    public int Value { get; set; }

    public static Int32Value Deserialize(byte[] bytes)
    {
        var input = new CodedBufferReader(bytes);

        var tag = input.ReadTag();

        var wireType = tag & 0x7;
        var tagNumber = tag >> 3;
        var value = input.readint32();

        return new Int32Value { Value = value };
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, Value);
    }

    public static implicit operator Int32Value(int value) => new() { Value = value };
    public static implicit operator int(Int32Value value) => value.Value;
}
