namespace Modern.Grpc.Reflection.Descriptor;

public sealed record ExtensionRangeOptions : IMessage<ExtensionRangeOptions>
{
    /// <summary>
    /// The parser stores options it doesn't recognize here. See above.
    /// </summary>
    public List<UninterpretedOption> uninterpreted_option = []; // 999


    //  // Clients can define custom options in extensions of this message. See above.
    //  extensions 1000 to max;
    public static ExtensionRangeOptions Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        throw new NotImplementedException();
    }
}
