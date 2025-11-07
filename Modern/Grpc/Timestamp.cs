namespace Modern.Grpc;

internal sealed record Timestamp : IMessage<Timestamp>
{
    public readonly long Seconds;
    public readonly int Nanos;

    public Timestamp(long seconds, int nanos)
    {
        Seconds = seconds;
        Nanos = nanos;
    }

    public static Timestamp FromDateTime(DateTime dateTime)
    {
        dateTime = dateTime.ToUniversalTime();
        var micros = (DateTime.UnixEpoch - dateTime).TotalMicroseconds;

        var seconds = (long)(micros / 1_000_000);
        var nanos = (int)((micros % 1_000_000) * 1000);

        return new Timestamp(seconds, nanos);   
    }

    public static Timestamp Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, Seconds);
        writer.Write(2, Nanos);
    }
}
