namespace Task_1_HW_2
{// ідея цікава і не додумана. Все дуже сиро.
    internal class Task_1
    {
        static void Main(string[] args)
        {

        }
// Це мав бути інтерфейс.
        abstract class WaterEssence { public abstract void UpdateState(); }

        class WaterTower : WaterEssence
        {
            private readonly int _maxVolume;
            private int _curentVolume;
            private bool _isPumpOn;

            public WaterTower(int maxVolume)
            {
                _maxVolume = maxVolume;
                _curentVolume = 0;
                _isPumpOn = false;
            }

            public int CurentVolume
            {
                get { return _curentVolume; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Volume can't be negative");
                    }
                    if (value > _maxVolume)
                    {
                        Console.WriteLine("Volume cannot be greater than the maximum volume");
                    }
                    _curentVolume = value;
                }
            }

            public bool IsPumpOn
            {
                get { return _isPumpOn; }
                set { _isPumpOn = value; }
            }

            public int MaxVolume
            {
                get { return _maxVolume; }
            }

            public override void UpdateState()
            {
                if (_curentVolume == 0)
                {
                    _isPumpOn = true;
                }
                else if (_curentVolume == _maxVolume)
                {
                    _isPumpOn = false;
                }
            }

            public override string ToString()
            {
                return $"Volume={_curentVolume}, Max Volume={_maxVolume}, Pump On={_isPumpOn}";
            }
        }

        class WaterConsumer : WaterEssence
        {

            private readonly int _usageRate;
            private int _waterConsumed;

            public int UsageRate
            {
                get { return _usageRate; }
            }



            public WaterConsumer(int usageRate)
            {
                _usageRate = usageRate;
                _waterConsumed = 0;
            }

            public int WaterConsumed
            {
                get { return _waterConsumed; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Water use cannot be negative");
                    }
                    _waterConsumed = value;
                }
            }

            public override void UpdateState()
            {
                _waterConsumed += _usageRate;
            }

            public override string ToString()
            {
                return $"Water Consumed={_waterConsumed}, Rate of use={_usageRate}";
            }
        }
    }
}
