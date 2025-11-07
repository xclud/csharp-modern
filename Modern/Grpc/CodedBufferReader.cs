using System.Text;

namespace Modern.Grpc;

public class CodedBufferReader
{
    private readonly byte[] _buffer;
    private readonly MemoryStream stream;
    private readonly BinaryReader binaryReader;

    int _lastTag = 0;

    public CodedBufferReader(byte[] data)
    {
        this._buffer = data;
        stream = new MemoryStream(this._buffer, false);
        binaryReader = new BinaryReader(stream);
    }

    internal int ReadTag()
    {
        if (stream.Position == stream.Length - 1)
        {
            _lastTag = 0;
            return 0;
        }

        _lastTag = readint32();
        if (getTagFieldNumber(_lastTag) == 0)
        {
            throw new Exception("Invalid Tag.");
        }
        return _lastTag;
    }

    public uint readUint32() => _readRawVarUInt32();
    public int readint32() => _readRawVarInt32();


    public byte[] readBytes()
    {
        var length = readint32();
        var bytes = binaryReader.ReadBytes(length);
        return bytes;
    }

    public string readString()
    {
        var bytes = readBytes();
        var str = Encoding.UTF8.GetString(bytes);
        return str;
    }

    int _readRawVarInt32()
    {
        var result = 0;

        for (int i = 0; i <= 10; i++)
        {
            var b = binaryReader.ReadByte();
            result |= (b & 0x7f) << (i * 7);
            if ((b & 0x80) == 0)
            {
                return (int)(result - 2 * (0x80000000 & result));
            }

            if (i > 10)
            {
                break;
            }
        }

        throw new Exception("Malformed VarInt");
    }

    uint _readRawVarUInt32()
    {
        var result = 0u;

        for (int i = 0; i <= 10; i++)
        {
            var b = binaryReader.ReadByte();
            result |= ((uint)(b & 0x7f)) << (i * 7);
            if ((b & 0x80) == 0)
            {
                result &= 0xffffffff;
                return result;
            }

            i++;
            if (i > 10)
            {
                break;
            }
        }

        throw new Exception("Malformed VarInt");
    }

    private const int _TAG_TYPE_BITS = 3;
    private const int _TAG_TYPE_MASK = (1 << _TAG_TYPE_BITS) - 1;

    private static int getTagFieldNumber(int tag) => tag >> _TAG_TYPE_BITS;
    private static int getTagWireType(int tag) => tag & _TAG_TYPE_MASK;
}