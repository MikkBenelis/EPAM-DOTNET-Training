using System;

namespace NET.W.Gladkiy._19
{
    public class Program
    {
        public static void Main()
        {
            var simpleObject = new SimpleClass(10);
            var soValue = simpleObject.GetObject();
            var soToString = simpleObject.ToString();
            var soHashCode = simpleObject.GetHashCode();

            var simpleStruct = new SimpleStruct(10);
            var ssValue = simpleStruct.SquaredValue();
            var ssToString = simpleStruct.ToString();
            var ssHashCode = simpleStruct.GetHashCode();
        }
    }

    public interface IPrintable
    {
        void PrintSomeInfo();
    }

    public class SimpleClass : IPrintable
    {
        private object Value { get; set; }

        public SimpleClass(object value)
        {
            Value = value;
        }

        public object GetObject()
        {
            return Value;
        }

        public void PrintSomeInfo()
        {
            Console.WriteLine("Some helpful info");
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public struct SimpleStruct : IPrintable
    {
        public int Value;

        public SimpleStruct(int value)
        {
            Value = value;
        }

        public int SquaredValue()
        {
            return Value * Value;
        }

        public void PrintSomeInfo()
        {
            Console.WriteLine("Some helpful info");
        }

        public override string ToString()
        {
            return $"Value = {Value}";
        }
    }
}
