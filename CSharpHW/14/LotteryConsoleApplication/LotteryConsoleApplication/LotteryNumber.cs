namespace LotteryConsoleApplication
{
    public class LotteryNumber
    {
        private int[] _numbers;

        public LotteryNumber()
        {
            _numbers = new int[6];
        }

        public int this[int index] 
        {
            get
            {
                return _numbers[index];
            }
            set
            {
                _numbers[index] = value;
            }
        }

        public int Length 
        {
            get { return _numbers.Length; }
        }
    }
}
