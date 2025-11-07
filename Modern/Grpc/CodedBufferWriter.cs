using Modern.Grpc.WellKnownTypes;
using System.Text;

namespace Modern.Grpc;

public class CodedBufferWriter
{
    private readonly MemoryStream _outputChunk = new();
    private readonly BinaryWriter _outputChunkAsByteData;

    public CodedBufferWriter()
    {
        _outputChunkAsByteData = new BinaryWriter(_outputChunk);
    }

    public byte[] GetBytes()
    {
        return _outputChunk.ToArray();
    }

    private void WriteVarInt32(int value)
    {
        var uv = BitConverter.ToUInt32(BitConverter.GetBytes(value));
        while (uv >= 0x80)
        {
            _outputChunk.WriteByte((byte)(0x80 | (uv & 0x7f)));
            uv >>= 7;
        }
        _outputChunk.WriteByte((byte)uv);
    }

    private void WriteVarInt32(uint value)
    {
        while (value >= 0x80)
        {
            _outputChunk.WriteByte((byte)(0x80 | (value & 0x7f)));
            value >>= 7;
        }
        _outputChunk.WriteByte((byte)value);
    }

    private void WriteVarInt64(long value)
    {
        var uv = BitConverter.ToUInt64(BitConverter.GetBytes(value));

        var lo = (uint)value;
        var hi = (uint)(value >> 32);
        while (hi > 0 || lo >= 0x80)
        {
            _outputChunk.WriteByte((byte)(0x80 | (lo & 0x7f)));
            lo = (lo >> 7) | ((hi & 0x7f) << 25);
            hi >>= 7;
        }

        _outputChunk.WriteByte((byte)lo);
    }

    private void WriteBytesNoTag(byte[] value)
    {
        var length = value.Length;
        WriteVarInt32(length);

        if (length == 0)
        {
            return;
        }

        _outputChunkAsByteData.Write(value);
    }

    private void WriteTag(int fieldNumber, int wireFormat)
    {
        WriteVarInt32(MakeTag(fieldNumber, wireFormat));
    }

    public void Write(int fieldNumber, IEnumerable<IMessage>? value)
    {
        if (value == null || !value.Any())
        {
            return;
        }

        foreach (var message in value)
        {
            WriteTag(fieldNumber, WIRETYPE_LENGTH_DELIMITED);

            var tmp = new CodedBufferWriter();
            message.WriteTo(tmp);
            var bytes = tmp.GetBytes();

            WriteVarInt64(bytes.Length);
            _outputChunkAsByteData.Write(bytes);
        }
    }

    public void Write(int fieldNumber, IEnumerable<byte[]>? value)
    {
        if (value == null || !value.Any())
        {
            return;
        }

        foreach (var message in value)
        {
            Write(fieldNumber, message);
        }
    }

    public void Write(int fieldNumber, IEnumerable<string>? value)
    {
        if (value == null || !value.Any())
        {
            return;
        }

        foreach (var message in value)
        {
            Write(fieldNumber, message);
        }
    }

    public void Write(int fieldNumber, IEnumerable<int>? value)
    {
        if (value == null || !value.Any())
        {
            return;
        }
    }

    public void Write(int fieldNumber, bool? value)
    {
        if (value == null)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_VARINT);
        WriteVarInt32(value == true ? 1 : 0);
    }

    public void Write(int fieldNumber, byte[]? bytes)
    {
        if (bytes == null)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_LENGTH_DELIMITED);
        if (bytes.Length == 0)
        {
            WriteVarInt32(0);
        }
        else
        {
            WriteBytesNoTag(bytes);
        }
    }
    public void Write(int fieldNumber, string? value)
    {
        if (value == null)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_LENGTH_DELIMITED);

        if (value.Length == 0)
        {
            WriteVarInt32(0);
        }
        else
        {
            WriteBytesNoTag(Encoding.UTF8.GetBytes(value));
        }
    }
    public void WriteEnum(int fieldNumber, int? value)
    {
        if (value == null)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_VARINT);
        WriteVarInt32(value.Value);
    }
    public void Write(int fieldNumber, double? value)
    {
        if (value == null || value == 0)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_FIXED64);
        _outputChunkAsByteData.Write(value.Value);
    }
    public void Write(int fieldNumber, float? value)
    {
        if (value == null || value == 0)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_FIXED32);
        _outputChunkAsByteData.Write(value.Value);
    }
    public void Write(int fieldNumber, int? value)
    {
        if (value == null || value == 0)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_VARINT);
        WriteVarInt64(value.Value);
    }

    public void Write(int fieldNumber, DateTime? value)
    {
        if (value == null)
        {
            return;
        }

        var ts = Timestamp.FromDateTime(value.Value);

        Write(fieldNumber, ts);
    }

    public void Write(int fieldNumber, long? value)
    {
        if (value == null || value == 0)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_VARINT);
        WriteVarInt64(value.Value);
    }
    public void WriteSInt32(int fieldNumber, int? value)
    {
        if (value == null || value == 0)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_VARINT);
        WriteVarInt32(_encodeZigZag32(value.Value));
    }
    public void WriteSInt64(int fieldNumber, long? value)
    {
        if (value == null || value == 0)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_VARINT);
        WriteVarInt64(_encodeZigZag64(value.Value));
    }
    public void WriteUInt32(int fieldNumber, int? value)
    {
        if (value == null || value == 0)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_VARINT);
        WriteVarInt32(value.Value);
    }
    public void WriteUInt64(int fieldNumber, long? value)
    {
        if (value == null || value == 0)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_VARINT);
        WriteVarInt64(value.Value);
    }

    public void WriteFixed32(int fieldNumber, int? value)
    {
        if (value == null || value == 0)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_FIXED32);
        _outputChunkAsByteData.Write(value.Value);
    }

    public void WriteFixed64(int fieldNumber, long? value)
    {
        if (value == null || value == 0)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_FIXED64);
        _outputChunkAsByteData.Write(value.Value);
    }
    public void WriteSFixed32(int fieldNumber, int? value)
    {
        if (value == null || value == 0)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_FIXED32);
        _outputChunkAsByteData.Write(value.Value);
    }
    public void WriteSFixed64(int fieldNumber, long? value)
    {
        if (value == null || value == 0)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_FIXED64);
        _outputChunkAsByteData.Write(value.Value);
    }
    public void Write(int fieldNumber, IMessage? value)
    {
        if (value == null)
        {
            return;
        }

        WriteTag(fieldNumber, WIRETYPE_LENGTH_DELIMITED);

        var tmp = new CodedBufferWriter();
        value.WriteTo(tmp);
        var bytes = tmp.GetBytes();

        WriteVarInt64(bytes.Length);
        _outputChunkAsByteData.Write(bytes);
    }


    static int _encodeZigZag32(int value) => (value << 1) ^ (value >> 31);
    static long _encodeZigZag64(long value) => (value << 1) ^ (value >> 63);

    private const int _TAG_TYPE_BITS = 3;
    private const int _TAG_TYPE_MASK = (1 << _TAG_TYPE_BITS) - 1;

    private static int getTagFieldNumber(int tag) => tag >> _TAG_TYPE_BITS;
    private static int getTagWireType(int tag) => tag & _TAG_TYPE_MASK;
    private static int MakeTag(int fieldNumber, int tag) => (fieldNumber << _TAG_TYPE_BITS) | tag;


    const int WIRETYPE_VARINT = 0;
    const int WIRETYPE_FIXED64 = 1;
    const int WIRETYPE_LENGTH_DELIMITED = 2;
    const int WIRETYPE_FIXED32 = 5;

}
