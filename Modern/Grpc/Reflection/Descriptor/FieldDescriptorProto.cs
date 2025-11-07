namespace Modern.Grpc.Reflection.Descriptor;

/// <summary>
/// Describes a field within a message.
/// </summary>
public sealed record FieldDescriptorProto : IMessage<FieldDescriptorProto>
{
    public enum FieldType
    {
        // 0 is reserved for errors.
        // Order is weird for historical reasons.
        TYPE_DOUBLE, // 1
        TYPE_FLOAT, // 2
        // Not ZigZag encoded.  Negative numbers take 10 bytes.  Use TYPE_SINT64 if
        // negative values are likely.
        TYPE_INT64, // 3
        TYPE_UINT64, // 4
        // Not ZigZag encoded.  Negative numbers take 10 bytes.  Use TYPE_SINT32 if
        // negative values are likely.
        TYPE_INT32, // 5
        TYPE_FIXED64, // 6
        TYPE_FIXED32, // 7
        TYPE_BOOL, // 8
        TYPE_STRING, // 9
        // Tag-delimited aggregate.
        // Group type is deprecated and not supported in proto3. However, Proto3
        // implementations should still be able to parse the group wire format and
        // treat group fields as unknown fields.
        TYPE_GROUP, // 10
        TYPE_MESSAGE = 11,  // Length-delimited aggregate.

        // New in version 2.
        TYPE_BYTES, // 12
        TYPE_UINT32, // 13
        TYPE_ENUM, // 14
        TYPE_SFIXED32, // 15
        TYPE_SFIXED64, // 16
        TYPE_SINT32 = 17,  // Uses ZigZag encoding.
        TYPE_SINT64 = 18,  // Uses ZigZag encoding.
    }

    public enum FieldLabel
    {
        // 0 is reserved for errors
        LABEL_OPTIONAL, // 1
        LABEL_REQUIRED, // 2
        LABEL_REPEATED, // 3
    }

    public string? Name; // 1
    public int? Number; // 3
    public FieldLabel? Label; // 4

    // If type_name is set, this need not be set.  If both this and type_name
    // are set, this must be one of TYPE_ENUM, TYPE_MESSAGE or TYPE_GROUP.
    public FieldType? Type; // 5

    // For message and enum types, this is the name of the type.  If the name
    // starts with a '.', it is fully-qualified.  Otherwise, C++-like scoping
    // rules are used to find the type (i.e. first the nested types within this
    // message are searched, then within the parent, on up to the root
    // namespace).
    public string? TypeName; // 6

    // For extensions, this is the name of the type being extended.  It is
    // resolved in the same manner as type_name.
    public string? Extendee; // 2

    // For numeric types, contains the original text representation of the value.
    // For booleans, "true" or "false".
    // For strings, contains the default text contents (not escaped in any way).
    // For bytes, contains the C escaped value.  All bytes >= 128 are escaped.
    // TODO(kenton):  Base-64 encode?
    public string? DefaultValue; // 7

    // If set, gives the index of a oneof in the containing type's oneof_decl
    // list.  This field is a member of that oneof.
    public int? OneofIndex; // 9

    // JSON name of this field. The value is set by protocol compiler. If the
    // user has set a "json_name" option on this field, that option's value
    // will be used. Otherwise, it's deduced from the field's name by converting
    // it to camelCase.
    public string? JsonName; // 10

    public FieldOptions? Options; // 8

    // If true, this is a proto3 "optional". When a proto3 field is optional, it
    // tracks presence regardless of field type.
    //
    // When proto3_optional is true, this field must be belong to a oneof to
    // signal to old proto3 clients that presence is tracked for this field. This
    // oneof is known as a "synthetic" oneof, and this field must be its sole
    // member (each proto3 optional field gets its own synthetic oneof). Synthetic
    // oneofs exist in the descriptor only, and do not generate any API. Synthetic
    // oneofs must be ordered after all "real" oneofs.
    //
    // For message fields, proto3_optional doesn't create any semantic change,
    // since non-repeated message fields always track presence. However it still
    // indicates the semantic detail of whether the user wrote "optional" or not.
    // This can be useful for round-tripping the .proto file. For consistency we
    // give message fields a synthetic oneof also, even though it is not required
    // to track presence. This is especially important because the parser can't
    // tell if a field is a message or an enum, so it must always create a
    // synthetic oneof.
    //
    // Proto2 optional fields do not set this flag, because they already indicate
    // optional with `LABEL_OPTIONAL`.
    public bool? Proto3Optional; // 17


    public static FieldDescriptorProto Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, Name);
        writer.Write(3, Number);
        writer.WriteEnum(4, (int?)Label);
        writer.WriteEnum(5, (int?)Type);
        writer.Write(6, TypeName);
        writer.Write(2, Extendee);
        writer.Write(7, DefaultValue);
        writer.Write(9, OneofIndex);
        writer.Write(10, JsonName);
        writer.Write(8, Options);
        writer.Write(17, Proto3Optional);
    }
}
