namespace Modern.Grpc.Reflection.Descriptor;

public sealed record MessageOptions : IMessage<MessageOptions>
{
    //  // Set true to use the old proto1 MessageSet wire format for extensions.
    //  // This is provided for backwards-compatibility with the MessageSet wire
    //  // format.  You should not use this for any other reason:  It's less
    //  // efficient, has fewer features, and is more complicated.
    //  //
    //  // The message must be defined exactly as follows:
    //  //   public sealed record Foo : IMessage<Foo> {
    //  //     option message_set_wire_format = true;
    //  //     extensions 4 to max;
    //  //   }
    //  // Note that the message cannot have any defined fields; MessageSets only
    //  // have extensions.
    //  //
    //  // All extensions of your type must be singular messages; e.g. they cannot
    //  // be int32s, enums, or repeated messages.
    //  //
    //  // Because this is an option, the above two restrictions are not enforced by
    //  // the protocol compiler.
    //  public bool? message_set_wire_format = 1 [default = false];

    //  // Disables the generation of the standard "descriptor()" accessor, which can
    //  // conflict with a field of the same name.  This is meant to make migration
    //  // from proto1 easier; new code should avoid fields named "descriptor".
    //  public bool? no_standard_descriptor_accessor = 2 [default = false];

    //  // Is this message deprecated?
    //  // Depending on the target platform, this can emit Deprecated annotations
    //  // for the message, or it will be completely ignored; in the very least,
    //  // this is a formalization for deprecating messages.
    //  public bool? deprecated = 3 [default = false];

    //  // Whether the message is an automatically generated map entry type for the
    //  // maps field.
    //  //
    //  // For maps fields:
    //  //     map<KeyType, ValueType> map_field; // 1
    //  // The parsed descriptor looks like:
    //  //     public sealed record MapFieldEntry : IMessage<MapFieldEntry> {
    //  //         option map_entry = true;
    //  //         optional KeyType key; // 1
    //  //         optional ValueType value; // 2
    //  //     }
    //  //     repeated MapFieldEntry map_field; // 1
    //  //
    //  // Implementations may choose not to generate the map_entry=true message, but
    //  // use a native map in the target language to hold the keys and values.
    //  // The reflection APIs in such implementations still need to work as
    //  // if the field is a repeated message field.
    //  //
    //  // NOTE: Do not set the option in .proto files. Always use the maps syntax
    //  // instead. The option should only be implicitly set by the proto compiler
    //  // parser.
    //  public bool? map_entry; // 7

    //  reserved 8;  // javalite_serializable
    //  reserved 9;  // javanano_as_lite


    //  // The parser stores options it doesn't recognize here. See above.
    //  repeated UninterpretedOption uninterpreted_option; // 999

    //  // Clients can define custom options in extensions of this message. See above.
    //  extensions 1000 to max;
    public static MessageOptions Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        throw new NotImplementedException();
    }
}
