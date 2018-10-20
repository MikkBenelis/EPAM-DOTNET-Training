namespace Logic.Math
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Polynomial
    {
        // Constructor
        public Polynomial(params double[] indexes)
        {
            if (indexes.Length == 0)
            {
                indexes = new double[] { 0 };
            }
            
            Indexes = indexes;
        }
        
        // Length
        public int Length { get => Indexes.Length; }
        
        // Indexes
        public double[] Indexes { get; private set; }
        
        // Operator +
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            // Pad arrays with zeroes
            int maxLength = Math.Max(p1.Length, p2.Length);
            var indexes1 = PadDoubleArray(p1.Indexes, maxLength);
            var indexes2 = PadDoubleArray(p2.Indexes, maxLength);
            
            // Calculate sum of indexes
            var newIndexes = new LinkedList<double>();
            for (int i = 0; i < maxLength; i++)
            {
                newIndexes.AddLast(indexes1[i] + indexes2[i]);
            }

            // Clear indexes from leading zeroes
            while (newIndexes.Count >= 1 && newIndexes.First.Value == 0)
            {
                newIndexes.RemoveFirst();
            }

            return new Polynomial(newIndexes.ToArray<double>());
        }
        
        // Operator -
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            return p1 + (-1 * p2);
        }
        
        // Operator *
        public static Polynomial operator *(Polynomial p, double x)
        {
            // Calculate mul of indexes and x
            var newIndexes = new LinkedList<double>();
            for (int i = 0; i < p.Indexes.Length; i++)
            {
                newIndexes.AddLast(p.Indexes[i] * x);
            }
            
            // Clear indexes from leading zeroes
            while (newIndexes.Count >= 1 && newIndexes.First.Value == 0)
            {
                newIndexes.RemoveFirst();
            }

            return new Polynomial(newIndexes.ToArray<double>());
        }

        // Operator *
        public static Polynomial operator *(double x, Polynomial p)
        {
            return p * x;
        }
        
        // Operator *
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            // Pad arrays with zeroes
            int maxLength = Math.Max(p1.Length, p2.Length);
            var indexes1 = PadDoubleArray(p1.Indexes, maxLength);
            var indexes2 = PadDoubleArray(p2.Indexes, maxLength);

            // Calculate mul of indexes
            var newIndexes = new double[(maxLength * 2) - 1];
            for (int i = 0; i < maxLength; i++)
            {
                for (int j = 0; j < maxLength; j++)
                {
                    newIndexes[i + j] += indexes1[i] * indexes2[j];
                }
            }

            // Clear indexes from leading zeroes
            var resultList = new LinkedList<double>(newIndexes);
            while (resultList.Count >= 1 && resultList.First.Value == 0)
            {
                resultList.RemoveFirst();
            }

            return new Polynomial(resultList.ToArray<double>());
        }

        // Operator ==
        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            return p1.Equals(p2);
        }

        // Operator !=
        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            return !p1.Equals(p2);
        }
        
        // GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode() * Indexes.GetHashCode();
        }
        
        // Equals
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            bool result = true;
            if (obj.GetType() == GetType())
            {
                result &= (obj as Polynomial).Length == this.Length;
                result &= (obj as Polynomial).Indexes.SequenceEqual(this.Indexes);
            }
            else
            {
                result = false;
            }

            return result;
        }
        
        // ToString
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Type:{GetType()}, Length:{Length}, ");
            sb.Append($"Indexes:[{string.Join(",", Indexes)}]");
            return sb.ToString();
        }

        // PadDoubleArray
        private static double[] PadDoubleArray(double[] array, int newLength, double filler = 0)
        {
            double[] result = new double[newLength];
            for (int i = 0; i < newLength; i++)
            {
                if (i < newLength - array.Length)
                {
                    result[i] = filler;
                }
                else
                {
                    result[i] = array[i - (newLength - array.Length)];
                }
            }

            return result;
        }
    }
}
