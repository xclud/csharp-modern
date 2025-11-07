namespace Modern.Grpc;

public interface IMessage
{
    void WriteTo(CodedBufferWriter writer);
}

public interface IMessage<T> : IMessage
{
    abstract static T Deserialize(byte[] bytes);
}
