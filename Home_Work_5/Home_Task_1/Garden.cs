using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_1
{
    class Garden : IComparable<Garden>
    {
        public double[] TreeCoordinates { get; set; }

        public double CalculateFenceLength()
        {
            double fenceLength = 0.0;
            return fenceLength;
        }

        public int CompareTo(Garden other)
        {
            double thisFenceLength = this.CalculateFenceLength();
            double otherFenceLength = other.CalculateFenceLength();

            if (thisFenceLength < otherFenceLength)
            {
                return -1;
            }
            else if (thisFenceLength > otherFenceLength)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static bool operator <(Garden garden1, Garden garden2)
        {
            return garden1.CompareTo(garden2) < 0;
        }

        public static bool operator >(Garden garden1, Garden garden2)
        {
            return garden1.CompareTo(garden2) > 0;
        }

        public static bool operator <=(Garden garden1, Garden garden2)
        {
            return garden1.CompareTo(garden2) <= 0;
        }

        public static bool operator >=(Garden garden1, Garden garden2)
        {
            return garden1.CompareTo(garden2) >= 0;
        }
    }
}
