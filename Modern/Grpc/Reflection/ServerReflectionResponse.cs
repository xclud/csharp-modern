namespace Modern.Grpc.Reflection;

public sealed record ServerReflectionResponse : IMessage<ServerReflectionResponse>
{
    public required string ValidHost { get; set; }
    public required ServerReflectionRequest OriginalRequest { get; set; }

    /// <summary>
    /// This message is used to answer file_by_filename, file_containing_symbol,
    /// file_containing_extension requests with transitive dependencies.
    /// As the repeated label is not allowed in oneof fields, we use a
    /// FileDescriptorResponse message to encapsulate the repeated fields.
    /// The reflection service is allowed to avoid sending FileDescriptorProtos
    /// that were previously sent in response to earlier requests in the stream.
    /// <br /><br />
    /// 4.
    /// </summary>
    public FileDescriptorResponse? FileDescriptorResponse { get; set; }

    /// <summary>
    /// This message is used to answer list_services requests.
    /// <br /><br />
    /// 6.
    /// </summary>
    public ListServiceResponse? ListServicesResponse { get; set; }

    public static ServerReflectionResponse Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, ValidHost);
        writer.Write(2, OriginalRequest);
        writer.Write(4, FileDescriptorResponse);
        writer.Write(6, ListServicesResponse);
    }
}
