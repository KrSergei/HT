namespace HTask7
{
    internal class SomeAttribute : System.Attribute
    {
        string StringValue;
        int IntValue;
        decimal DecimalValue;
        char[] CharAray;

        public SomeAttribute()
        {
            
        }

        public SomeAttribute(string stringValue)
        {
            StringValue = stringValue;
        }

        public SomeAttribute(int intValue)
        {
            IntValue = intValue;
        }

        public SomeAttribute(decimal decimalValue)
        {
            DecimalValue = decimalValue; 
        }

        public SomeAttribute(char[] charAray)
        {
            CharAray = charAray;
        }

        public SomeAttribute(string stringValue, int intValue, decimal decimalValue, char[] charAray)
        {
            StringValue = stringValue;
            IntValue = intValue;
            DecimalValue = decimalValue;
            CharAray = charAray;
        }

        public string GetString() => StringValue;

        public int GetInt() => IntValue;

        public decimal GetDecival() => DecimalValue;

        public char[] GetCharArray() => CharAray;
    }
}
