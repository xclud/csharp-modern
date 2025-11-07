namespace Modern.Grpc;

public sealed record DecimalValue(string Value) : IMessage<DecimalValue>
{
    public static DecimalValue Deserialize(byte[] bytes)
    {
        return new DecimalValue("0");
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, Value);
    }

    public static implicit operator decimal(DecimalValue grpcDecimal)
    {
        return decimal.Parse(grpcDecimal.Value);
    }

    public static implicit operator DecimalValue(decimal value)
    {
        return new DecimalValue(value.ToString().TrimEnd('0').TrimEnd('.'));
    }
}
