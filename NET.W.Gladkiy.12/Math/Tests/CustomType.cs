namespace NUnitTests
{
    using System;

    public class CustomType : IComparable<CustomType>
    {
        public CustomType(int x, int y, string name)
        {
            X = x;
            Y = y;
            Name = name;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public string Name { get; private set; }

        public int CompareTo(CustomType other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
