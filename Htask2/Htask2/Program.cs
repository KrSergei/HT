//Реализуйте операторы неявного приведения из long,int,byt в Bits.


namespace Htask2;

public class Programm
{
    public static void Main()
    {
        //Bits bits = new Bits(4);
        //Console.WriteLine(bits.GetBitByIndex(2));
        //bits.SetBitByIndex(0, true);
        //Console.WriteLine(bits.GetBitByIndex(0));
        //bits[1] = true;
        //Console.WriteLine(bits.Value);
        //Console.WriteLine(bits);
        //byte val = (byte)bits;

        //Devices devices = new();
        //Bits bits2 = new(2);
        //Console.WriteLine(devices);
        //devices.TurnOnOff(bits2);
        //Console.WriteLine(devices);
        #region Task4
        //Collection<string> collection = new Collection<string>(10);

        //collection[0] = "New string";
        //collection[1] = "New string1";
        //collection[2] = "New string2";

        //Console.WriteLine(collection[0]);
        //Console.WriteLine(collection[1]);
        //Console.WriteLine(collection[2]);
        #endregion
        #region Task5
        //Matrix<int> array = new Matrix<int>(2, 2);
        //array[0, 0] = 0;
        //array[0, 1] = 1;
        //array[1, 0] = 2;
        //array[1, 1] = 3;
        //array.PrintMatrix();

        #endregion
        #region HOMETASK
        Bits byteBit = new Bits((byte)10);
        Bits intBit = new Bits((int)1000);
        Bits longBit = new Bits((long)123345);
        Console.WriteLine(byteBit);
        Console.WriteLine(intBit);
        Console.WriteLine(longBit);
        #endregion

    }
}