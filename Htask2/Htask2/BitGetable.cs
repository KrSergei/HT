public interface IBitGetable
{
    bool GetBitByIndex(byte index);
    void SetBitByIndex(byte index, bool value);
}

public class Bits : IBitGetable
{
    public long Value { get; private set; }
    public int Size { get; private set; }

    public Bits(byte value)
    {
        Value = value;
        Size = sizeof(byte);
    }

    public Bits(int value)
    {
        Value = value;
        Size = sizeof(int);
    }

    public Bits(long value)
    {
        Value = value;
        Size = sizeof(long);
    }


    private int _value;
    public bool GetBitByIndex(byte index)
    {
        return (Value & (1 << index)) != 0;
    }

    public void SetBitByIndex(byte index, bool value)
    {
        if (value)
            Value |= (byte)(1 << index);
        else
            Value &= (byte)~(1 << index);
    }
    public bool this[byte index]
    {
        get => GetBitByIndex(index);
        set => SetBitByIndex(index, value);
    }

    public static implicit operator long(Bits bits) => bits.Value;
    public static implicit operator Bits(long value) => new Bits(value);
}

