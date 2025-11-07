namespace Modern.Grpc.Reflection.Descriptor;

public sealed record EnumValueOptions : IMessage<EnumValueOptions>
{
    /// <summary>
    /// Is this enum value deprecated?
    /// Depending on the target platform, this can emit Deprecated annotations
    /// for the enum value, or it will be completely ignored; in the very least,
    /// this is a formalization for deprecating enum values.
    /// </summary>
    //= 1 [default = false];
    public bool? Deprecated;

    /// <summary>
    /// The parser stores options it doesn't recognize here. See above.
    /// </summary>
    public List<UninterpretedOption> UninterpretedOptions = []; // 999

    //  // Clients can define custom options in extensions of this message. See above.
    //  extensions 1000 to max;
    public static EnumValueOptions Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, Deprecated);
        writer.Write(999, UninterpretedOptions);
    }
}
