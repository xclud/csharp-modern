namespace Modern.Grpc.Reflection.Descriptor;

/// <summary>
/// Describes a complete .proto file.
/// </summary>
public sealed record FileDescriptorProto : IMessage<FileDescriptorProto>
{
    // file name, relative to root of source tree
    public string? Name;// = 1;   
    // e.g. "foo", "foo.bar", etc.
    public string? Package;// = 2;
    //  // Names of files imported by this file.
    public List<string> Dependency = []; // 3

    //  // All top-level definitions in this file.
    public List<DescriptorProto> MessageType = []; // 4
    public List<EnumDescriptorProto> EnumType = []; // 5
    public List<ServiceDescriptorProto> Service = []; // 6
    public List<FieldDescriptorProto> Extension = []; // 7
    public FileOptions? Options; // 8


    //  // This field contains optional information about the original source code.
    //  // You may safely remove this entire field without harming runtime
    //  // functionality of the descriptors -- the information is needed only by
    //  // development tools.
    public SourceCodeInfo? SourceCodeInfo; // 9

    //  // Indexes of the public imported files in the dependency list above.
    public List<int> PublicDependency = []; // 10
    //  // Indexes of the weak imported files in the dependency list.
    //  // For Google-internal migration only. Do not use.
    public List<int> WeakDependency = []; // 11


    /// <summary>
    /// The syntax of the proto file.
    /// The supported values are "proto2" and "proto3".
    /// </summary>
    public string? Syntax; // 12

    public static FileDescriptorProto Deserialize(byte[] bytes)
    {
        throw new NotImplementedException();
    }

    public void WriteTo(CodedBufferWriter writer)
    {
        writer.Write(1, Name);
        writer.Write(2, Package);
        writer.Write(3, Dependency);
        writer.Write(4, MessageType);
        writer.Write(5, EnumType);
        writer.Write(6, Service);
        writer.Write(7, Extension);
        writer.Write(8, Options);
        writer.Write(9, SourceCodeInfo);
        writer.Write(10, PublicDependency);
        writer.Write(11, WeakDependency);
        writer.Write(12, Syntax);
    }
}
