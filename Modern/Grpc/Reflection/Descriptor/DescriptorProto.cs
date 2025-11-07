namespace Modern.Grpc.Reflection.Descriptor;

/// <summary>
/// Describes a message type.
/// </summary>
public sealed record DescriptorProto : IMessage<DescriptorProto>
{
    public string? Name; // 1

    public List<FieldDescriptorProto> Fields = []; // 2
    public List<FieldDescriptorProto> Extensions = []; // 6

    public List<DescriptorProto> NestedTypes = []; // 3
    public List<EnumDescriptorProto> EnumTypes = []; // 4

    public List<ExtensionRange> ExtensionRanges = []; // 5

    public List<OneofDescriptorProto> OneofDeclarations = []; // 8

    public MessageOptions? Options; // 7

    public List<ReservedRange> ReservedRanges = []; // 9


    /// <summary>
    /// Reserved field names, which may not be used by fields in the same message.
    /// A given name may only be reserved once.
    /// </summary>
    public List<string> ReservedNames = []; // 10


    public sealed record ExtensionRange : IMessage<ExtensionRange>
    {
        /// <summary>
        /// Inclusive.
        /// </summary>
        public int? Start;

        /// <summary>
        /// Exclusive.
        /// </summary>
        public int? End;

        public ExtensionRangeOptions? Options; // 3

        public static ExtensionRange Deserialize(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public void WriteTo(CodedBufferWriter writer)
        {
            writer.Write(1, Start);
            writer.Write(2, End);
            writer.Write(3, Options);
        }
    }


    /// <summary>
    /// Range of reserved tag numbers. Reserved tag numbers may not be used by
    /// fields or extension ranges in the same message. Reserved ranges may
    /// not overlap.
    /// </summary>
    public sealed record ReservedRange : IMessage<ReservedRange>
    {
        /// <summary>
        /// Inclusive.
        /// </summary>
        public int? Start;

        /// <summary>
        /// Exclusive.
        /// </summary>
        public int? End;

        public static ReservedRange Deserialize(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public void WriteTo(CodedBufferWriter writer)
        {
            writer.Write(1, Start);
            writer.Write(2, End);
        }
    }


    public static DescriptorProto Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, Name);
        writer.Write(2, Fields);
        writer.Write(6, Extensions);
        writer.Write(3, NestedTypes);
        writer.Write(4, EnumTypes);
        writer.Write(5, ExtensionRanges);
        writer.Write(8, OneofDeclarations);
        writer.Write(7, Options);
        writer.Write(9, ReservedRanges);
        writer.Write(10, ReservedNames);
    }
}


