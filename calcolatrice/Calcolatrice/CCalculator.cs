namespace Calculator
{
    internal class CCalculator
    {
        public enum Operations
        {
            sum,
            difference,
            multiplication,
            division,
            modulo,
            power,
            root,
            log
        }

        public CHugeNumber FirstOperand { get; set; }
        public CHugeNumber SecondOperand { get; set; }
        public CHugeNumber Result { get; set; }
        public CHugeNumber Ans { get; set; }
        public Operations Operation { get; set; }
    }
}
