namespace Modern.Grpc.Reflection.Descriptor;

/// <summary>
/// Describes an enum type.
/// </summary>
public sealed record EnumDescriptorProto : IMessage<EnumDescriptorProto>
{
    public string? Name; // 1

    public List<EnumValueDescriptorProto> Value = []; // 2

    public EnumOptions? Options; // 3

    /// <summary>
    /// Range of reserved numeric values. Reserved values may not be used by
    /// entries in the same enum. Reserved ranges may not overlap.
    ///
    /// Note that this is distinct from DescriptorProto.ReservedRange in that it
    /// is inclusive such that it can appropriately represent the entire int32
    /// domain.
    /// </summary>
    public sealed record EnumReservedRange : IMessage<EnumReservedRange>
    {
        /// <summary>
        /// Inclusive.
        /// </summary>
        public int? Start; // 1

        /// <summary>
        /// Inclusive.
        /// </summary>
        public int? End; // 2

        public static EnumReservedRange Deserialize(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public void WriteTo(CodedBufferWriter writer)
        {
            writer.Write(1, Start);
            writer.Write(2, End);
        }
    }

    /// <summary>
    /// Range of reserved numeric values. Reserved numeric values may not be used
    /// by enum values in the same enum declaration. Reserved ranges may not
    /// overlap.
    /// </summary>
    public List<EnumReservedRange> ReservedRanges = []; // 4

    /// <summary>
    /// Reserved enum value names, which may not be reused. A given name may only
    /// be reserved once.
    /// </summary>
    public List<string> ReservedNames = []; // 5


    public static EnumDescriptorProto Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, Name);
        writer.Write(2, Value);
        writer.Write(3, Options);
        writer.Write(4, ReservedRanges);
        writer.Write(5, ReservedNames);
    }
}
