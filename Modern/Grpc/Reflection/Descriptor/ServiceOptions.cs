namespace Modern.Grpc.Reflection.Descriptor;

public sealed record ServiceOptions : IMessage<ServiceOptions>
{
    // Note: Field numbers 1 through 32 are reserved for Google's internal RPC
    // framework.  We apologize for hoarding these numbers to ourselves, but
    // we were already using them long before we decided to release Protocol
    // Buffers.

    /// <summary>
    /// Is this service deprecated?
    /// Depending on the target platform, this can emit Deprecated annotations
    /// for the service, or it will be completely ignored; in the very least,
    /// this is a formalization for deprecating services.
    /// </summary>
    public bool? Deprecated;// = 33 [default = false];

    /// <summary>
    /// The parser stores options it doesn't recognize here. See above.
    /// </summary>
    public List<UninterpretedOption> UninterpretedOptions = []; // 999

    //  // Clients can define custom options in extensions of this message. See above.
    //  extensions 1000 to max;
    public static ServiceOptions Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
       writer.Write(33, Deprecated);
       writer.Write(999, UninterpretedOptions);
    }
}
