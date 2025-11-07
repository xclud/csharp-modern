namespace Modern.Grpc.Reflection.Descriptor;

/// <summary>
/// Describes a method of a service.
/// </summary>
public sealed record MethodDescriptorProto : IMessage<MethodDescriptorProto>
{
    public string? name; // 1

    /// <summary>
    /// Input and output type names. These are resolved in the same way as
    /// FieldDescriptorProto.TypeName, but must refer to a message type.
    /// </summary>
    public string? input_type; // 2
    public string? output_type; // 3

    public MethodOptions? options; // 4

    /// <summary>
    /// Identifies if client streams multiple client messages.
    /// </summary>
    public bool? client_streaming;// = 5 [default = false];

    /// <summary>
    /// Identifies if server streams multiple server messages.
    /// </summary>
    public bool? server_streaming;// = 6 [default = false];

    public static MethodDescriptorProto Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        throw new NotImplementedException();
    }
}
