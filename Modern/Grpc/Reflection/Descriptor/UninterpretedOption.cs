namespace Modern.Grpc.Reflection.Descriptor;


/// <summary>
/// A message representing a option the parser does not recognize. This only
/// appears in options protos created by the compiler::Parser class.
/// DescriptorPool resolves these when building Descriptor objects. Therefore,
/// options protos in descriptor objects (e.g. returned by Descriptor::options(),
/// or produced by Descriptor::CopyTo()) will never have UninterpretedOptions
/// in them.
/// </summary>
public sealed record UninterpretedOption : IMessage<UninterpretedOption>
{
    // The name of the uninterpreted option.  Each string represents a segment in
    // a dot-separated name.  is_extension is true iff a segment represents an
    // extension (denoted with parentheses in options specs in .proto files).
    // E.g.,{ ["foo", false], ["bar.baz", true], ["qux", false] } represents
    // "foo.(bar.baz).qux".
    public sealed record NamePart : IMessage<NamePart>
    {
        public required string Name; // 1required
        public required bool IsExtension; // 2required

        public static NamePart Deserialize(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public void WriteTo(CodedBufferWriter writer)
        {
            writer.Write(1, Name);
            writer.Write(2, IsExtension);
        }
    }


    public List<NamePart> Name = []; // 2

    // The value of the uninterpreted option, in whatever type the tokenizer
    // identified it as during parsing. Exactly one of these should be set.

    public string? IdentifierValue; // 3
    public ulong? PositiveIntValue; // 4
    public long? NegativeIntValue; // 5
    public double? DoubleValue; // 6
    public byte[]? StringValue; // 7
    public string? AggregateValue; // 8

    public static UninterpretedOption Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(2, Name);
        writer.Write(3, IdentifierValue);
        writer.Write(4, PositiveIntValue);
        writer.Write(5, NegativeIntValue);
        writer.Write(6, DoubleValue);
        writer.Write(7, StringValue);
        writer.Write(8, AggregateValue);
    }
}
