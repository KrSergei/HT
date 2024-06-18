

public interface IControllable
{
    bool IsOn { get; }

    void On();
    void Off();
}

public class Device : IControllable
{
    public bool IsOn { get; private set; } = false;

    public void On()
    {
        IsOn = true;
    }

    public void Off()
    {
        IsOn = false; 
    }
}

public class Devices
{
    public List<IControllable> DeviceList { get; init; }

    public Devices()
    {
        DeviceList = 
        [
            new Device(),
            new Device(),
            new Device(),
            new Device(),
            new Device(),
            new Device(),
            new Device(),
            new Device()
        ];
    }
    public void TurnOnOff(Bits bits)
    {
        for (byte i = 0; i < 8; i++)
        {
            if (DeviceList[i].IsOn && !bits[i])
                DeviceList[i].Off();
            else if (!DeviceList[i].IsOn && bits[i])
                DeviceList[i].On();
        }
    }

    public override string ToString()
    {
        return string.Join("", DeviceList.Select(x=>x.IsOn?"1":"0"));
    }
}

