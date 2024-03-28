using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    internal class CHugeNumber
    {
        private
        const int N = 300;
        public int[] Digits { get; set; }

        public CHugeNumber()
        {
            Digits = new int[N];
        }

        public CHugeNumber(string n)
        {
            Digits = new int[N];
            if (n.Length >= N)
                throw new OverflowException();

            for (int i = 0; i < n.Length; i++)
                Digits[N - i - 1] = n[n.Length - i - 1] - '0';
        }

        public CHugeNumber(int length)
        {
            Digits = new int[N];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int tmp = random.Next(1, 10);
                Digits[N - 1 - i] = tmp;
            }
        }

        public int StartsAt()
        {
            for (int i = 0; i < N; i++)
            {
                if (Digits[i] != 0)
                    return i;
            }

            return 0;
        }

        public bool IsNegative()
        {
            for (int i = 0; i < N; i++)
            {
                if (Digits[i] < 0)
                    return true;
            }

            return false;
        }

        public bool IsZero()
        {
            for (int i = 0; i < N; i++)
            {
                if (Digits[i] != 0)
                    return false;
            }

            return true;
        }

        public bool IsPositive()
        {
            return !(IsNegative() || IsZero());
        }

        private CHugeNumber Comp10()
        {
            CHugeNumber result = new CHugeNumber();
            for (int i = N - 1; i >= 0; i--)
                result.Digits[i] = 9 - Digits[i];

            return result + new CHugeNumber("1");
        }

        public CHugeNumber Sqrt()
        {
            for (var i = new CHugeNumber(); i <= this; i++)
            {
                if (i * i >= this)
                    return i;
            }

            return new CHugeNumber();
        }

        public CHugeNumber Log()
        {
            CHugeNumber two = new CHugeNumber("2");
            for (CHugeNumber i = new CHugeNumber(); i <= this; i++)
            {
                if ((two ^ i) >= this)
                    return i;
            }

            return new CHugeNumber();
        }

        public static CHugeNumber operator +(CHugeNumber a, CHugeNumber b)
        {
            CHugeNumber result = new CHugeNumber();
            int carry = 0;
            for (int i = N - 1; i >= 0; i--)
            {
                int sum = a.Digits[i] + b.Digits[i] + carry;
                result.Digits[i] = sum % 10;
                carry = sum / 10;
            }

            return result;
        }

        public static CHugeNumber operator -(CHugeNumber a, CHugeNumber b)
        {
            CHugeNumber result = a + b.Comp10();

            if (result.Digits[0] == 9)
            {
                result = result.Comp10();
                for (int i = 0; result.Digits[i] == 0; i++)
                {
                    if (result.Digits[i + 1] != 0)
                    {
                        result.Digits[i + 1] = -result.Digits[i + 1];
                        return result;
                    }
                }
            }

            return result;
        }

        public static CHugeNumber operator *(CHugeNumber a, CHugeNumber b)
        {
            CHugeNumber result = new CHugeNumber();
            int[] n1 = a.Digits.Skip(N / 2).ToArray();
            int[] n2 = b.Digits.Skip(N / 2).ToArray();

            for (int i = N / 2 - 1; i >= 0; i--)
            {
                int carry = 0;
                for (int j = N / 2 - 1; j >= 0; j--)
                {
                    int product = n1[i] * n2[j] + result.Digits[i + j + 1] + carry;
                    result.Digits[i + j + 1] = product % 10;
                    carry = product / 10;
                }
                result.Digits[i + N / 2] += carry;
            }

            return result;
        }

        public static CHugeNumber operator /(CHugeNumber a, CHugeNumber b)
        {
            CHugeNumber result = new CHugeNumber();
            if (b.IsZero())
                return result;

            while (a.IsPositive())
            {
                a -= b;
                result++;
            }

            return result;
        }

        public static CHugeNumber operator %(CHugeNumber a, CHugeNumber b)
        {
            CHugeNumber i = new CHugeNumber();
            while (i < a)
                i += b;
            if (i == a)
                return new CHugeNumber();

            return a - (i - b);
        }

        public static CHugeNumber operator ++(CHugeNumber n)
        {
            return n + new CHugeNumber("1");
        }

        public static CHugeNumber operator --(CHugeNumber n)
        {
            return n - new CHugeNumber("1");
        }

        public static bool operator ==(CHugeNumber a, CHugeNumber b)
        {
            for (int i = 0; i < N; i++)
            {
                if (a.Digits[i] != b.Digits[i])
                    return false;
            }

            return true;
        }

        public static bool operator !=(CHugeNumber a, CHugeNumber b)
        {
            return !(a == b);
        }

        public static bool operator >=(CHugeNumber a, CHugeNumber b)
        {
            for (int i = 0; i < N; i++)
            {
                if (a.Digits[i] > b.Digits[i])
                    return true;
                if (a.Digits[i] < b.Digits[i])
                    return false;
            }

            return true;
        }

        public static bool operator <=(CHugeNumber a, CHugeNumber b)
        {
            return !(a >= b) || a == b;
        }

        public static bool operator >(CHugeNumber a, CHugeNumber b)
        {
            return !(a <= b);
        }

        public static bool operator <(CHugeNumber a, CHugeNumber b)
        {
            return !(a >= b);
        }

        public static CHugeNumber operator !(CHugeNumber n)
        {
            CHugeNumber result = n;
            for (int i = 0; i < N; i++)
            {
                if (n.Digits[i] != 0)
                    n.Digits[i] = -n.Digits[i];
            }

            return result;
        }

        public static CHugeNumber operator ^(CHugeNumber a, CHugeNumber b)
        {
            CHugeNumber result = new CHugeNumber("1");
            for (var i = new CHugeNumber(); i < b; i++)
                result *= a;

            return result;
        }

        public override string ToString()
        {
            string result = "";
            if (IsZero())
                return "0";
            for (int i = StartsAt(); i < N; i++)
                result += Digits[i];

            return result.TrimStart('0');
        }

        public override bool Equals(object obj)
        {
            return obj is CHugeNumber number &&
                EqualityComparer<int[]>.Default.Equals(Digits, number.Digits);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Digits);
        }
    }
}