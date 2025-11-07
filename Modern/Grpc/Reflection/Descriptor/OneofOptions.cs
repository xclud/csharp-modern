namespace Modern.Grpc.Reflection.Descriptor;

public sealed record OneofOptions : IMessage<OneofOptions>
{
    /// <summary>
    /// The parser stores options it doesn't recognize here. See above.
    /// </summary>
    public List<UninterpretedOption> UninterpretedOptions = []; // 999

    //  Clients can define custom options in extensions of this message. See above.
    //  extensions 1000 to max;
    public static OneofOptions Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(999, UninterpretedOptions);
    }
}
