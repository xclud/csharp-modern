namespace Modern.Grpc.Reflection.Descriptor;

public sealed record MethodOptions : IMessage<MethodOptions>
{
    // Note: Field numbers 1 through 32 are reserved for Google's internal RPC
    // framework.  We apologize for hoarding these numbers to ourselves, but
    // we were already using them long before we decided to release Protocol
    // Buffers.

    /// <summary>
    /// Is this method deprecated?
    /// Depending on the target platform, this can emit Deprecated annotations
    /// for the method, or it will be completely ignored; in the very least,
    /// this is a formalization for deprecating methods.
    /// </summary>
    public bool? Deprecated; // = 33 [default = false];

    /// <summary>
    /// Is this method side-effect-free (or safe in HTTP parlance), or idempotent,
    /// or neither? HTTP based RPC implementation may choose GET verb for safe
    /// methods, and PUT verb for idempotent methods instead of the default POST.
    /// </summary>
    public enum IdempotencyLevel
    {
        IDEMPOTENCY_UNKNOWN = 0,
        /// <summary>
        /// implies idempotent.
        /// </summary>
        NO_SIDE_EFFECTS = 1,

        /// <summary>
        /// idempotent, but may have side effects.
        /// </summary>
        IDEMPOTENT = 2,
    }

    public IdempotencyLevel? Idempotency;// = 34  [default = IDEMPOTENCY_UNKNOWN];

    /// <summary>
    /// The parser stores options it doesn't recognize here. See above.
    /// </summary>
    public List<UninterpretedOption> UninterpretedOptions = []; // 999

    //  // Clients can define custom options in extensions of this message. See above.
    //  extensions 1000 to max;
    public static MethodOptions Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(33, Deprecated);
        writer.WriteEnum(34, (int?)Idempotency);
        writer.Write(999, UninterpretedOptions);
    }
}
