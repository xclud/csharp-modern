namespace Modern.Grpc.Reflection.Descriptor;

public sealed record EnumOptions : IMessage<EnumOptions>
{
    /// <summary>
    /// Set this option to true to allow mapping different tag names to the same value.
    /// </summary>
    public bool? allow_alias; // 2

    //  // Is this enum deprecated?
    //  // Depending on the target platform, this can emit Deprecated annotations
    //  // for the enum, or it will be completely ignored; in the very least, this
    //  // is a formalization for deprecating enums.
    public bool? deprecated;// = 3 [default = false];

    //  reserved 5;  // javanano_as_lite

    //  // The parser stores options it doesn't recognize here. See above.
    public List<UninterpretedOption> UninterpretedOptions = []; // 999

    //  // Clients can define custom options in extensions of this message. See above.
    //  extensions 1000 to max;
    public static EnumOptions Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        throw new NotImplementedException();
    }
}
