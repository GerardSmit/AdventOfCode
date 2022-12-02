namespace Core;

public readonly ref struct SpanReader
{
    private readonly Stream _reader;
    private readonly Span<char> _charData;
    private readonly Span<byte> _buffer;

    public SpanReader(Stream reader, Span<byte> buffer, Span<char> charData)
    {
        _charData = charData;
        _buffer = buffer;
        _reader = reader;
    }

    public List<string> ToList(bool allowEmpty = false)
    {
        var items = new List<string>(1024);

        foreach (var span in this)
        {
            if (span.Length == 0 && !allowEmpty)
            {
                continue;
            }

            items.Add(new string(span));
        }

        return items;
    }

    public SpanReaderEnumerator GetEnumerator()
    {
        if (_reader.Position != 0)
        {
            _reader.Seek(0, SeekOrigin.Begin);
        }

        return new SpanReaderEnumerator(_reader, _buffer, _charData);
    }
}
