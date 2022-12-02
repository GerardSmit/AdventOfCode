using System.Runtime.CompilerServices;
using System.Text.Unicode;

namespace Core;

public ref struct SpanReaderEnumerator
{
    private readonly Stream _reader;
    private readonly Span<byte> _buffer;
    private readonly Span<char> _charData;
    private Span<char> _remaining;
    private Span<char> _value;
    private bool _finished;

    public SpanReaderEnumerator(Stream reader, Span<byte> buffer, Span<char> charData)
    {
        _reader = reader;
        _buffer = buffer;
        _charData = charData;
    }

    public bool MoveNext()
    {
        var index = _remaining.IndexOfAny('\r', '\n');

        // Move to the next line.
        if (index == -1)
        {
            if (_finished)
            {
                return false;
            }

            Span<char> target;
            Span<byte> buffer;
            int remainingLength;

            if (_remaining.Length > 0)
            {
                _remaining.CopyTo(_charData);
                remainingLength = _remaining.Length;
                target = _charData.Slice(remainingLength);
                buffer = _buffer.Slice((remainingLength + 1) * 3);
            }
            else
            {
                target = _charData;
                buffer = _buffer;
                remainingLength = 0;
            }

            var byteLength = _reader.Read(buffer);

            if (byteLength == 0)
            {
                _finished = true;
                return SetRemainingAsValue();
            }

            var utf8Bytes = buffer.Slice(0, byteLength);

            Utf8.ToUtf16(utf8Bytes, target, out _, out var charLength);

            _remaining = _charData.Slice(0, remainingLength + charLength);
            index = _remaining.IndexOfAny('\r', '\n');

            if (index == -1)
            {
                return SetRemainingAsValue();
            }
        }

        // Skip the line ending.
        var skipLength = _remaining[index] == '\r' ? 2 : 1;

        // Set value
        var nextIndex = index + skipLength;
        _value = _remaining.Slice(0, index);
        _remaining = nextIndex < _remaining.Length ? _remaining.Slice(nextIndex) : default;
        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool SetRemainingAsValue()
    {
        _value = _remaining;
        _remaining = default;
        return true;
    }

    public ReadOnlySpan<char> Current => _value;
}
