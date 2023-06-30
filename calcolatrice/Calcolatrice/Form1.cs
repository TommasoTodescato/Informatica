using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private readonly CCalculator calculator;
        private readonly string[] signs = { "+", "-", "*", "/", "%", "^", "sqrt", "log" };
        private readonly Dictionary<string, int> SignsOperations;

        private readonly Stack<string> LastCalculated;
        private bool HistoryMode = false;
        private int HistoryIndex = 0;

        private bool Error = false;

        public Form1()
        {
            InitializeComponent();
            SignsOperations = new Dictionary<string, int>();
            for (int i = 0; i < signs.Length; i++)
                SignsOperations.Add(signs[i], i);

            LastCalculated = new Stack<string>();
            calculator = new CCalculator();
        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            display.Text += e.KeyChar;
        }

        private void Equals(object sender, EventArgs e)
        {
            int count = 0;
            foreach (string s in signs)
            {
                if (display.Text.Contains(s))
                    count++;
            }
            if (count == 0 || (count == 1 && display.Text[0] == '-'))
                return;
            if (count > 1)
            {
                display.Text = "SyntaxError";
                Error = true;
                return;
            }

            string[] output = display.Text.Split(signs, StringSplitOptions.RemoveEmptyEntries);
            if (output.Length == 0)
            {
                display.Text = "0";
                return;
            }
            else if (output.Length == 1)
                calculator.SecondOperand = new CHugeNumber(output[0]);
            else
                calculator.SecondOperand = new CHugeNumber(output[1]);

            if (calculator.FirstOperand is null || calculator.SecondOperand is null)
            {
                display.Text = "SyntaxError";
                Error = true;
                return;
            }

            switch (calculator.Operation)
            {
                case CCalculator.Operations.sum:
                    calculator.Result = calculator.FirstOperand + calculator.SecondOperand;
                    break;
                case CCalculator.Operations.difference:
                    calculator.Result = calculator.FirstOperand - calculator.SecondOperand;
                    break;
                case CCalculator.Operations.multiplication:
                    calculator.Result = calculator.FirstOperand * calculator.SecondOperand;
                    break;
                case CCalculator.Operations.division:
                    if (calculator.SecondOperand.IsZero())
                    {
                        display.Text = "MathError";
                        Error = true;
                        return;
                    }
                    calculator.Result = calculator.FirstOperand / calculator.SecondOperand;
                    break;
                case CCalculator.Operations.modulo:
                    if (calculator.SecondOperand.IsZero())
                    {
                        display.Text = "MathError";
                        Error = true;
                        return;
                    }
                    calculator.Result = calculator.FirstOperand % calculator.SecondOperand;
                    break;
                case CCalculator.Operations.power:
                    calculator.Result = calculator.FirstOperand ^ calculator.SecondOperand;
                    break;
                case CCalculator.Operations.root:
                    calculator.Result = calculator.SecondOperand.Sqrt();
                    break;
                case CCalculator.Operations.log:
                    calculator.Result = calculator.SecondOperand.Log();
                    break;
            }
            calculator.Ans = calculator.Result;

            string tmp = display.Text;
            display.Text = calculator.Result.ToString();
            LastCalculated.Push(tmp + "=" + display.Text);
        }

        private void NumberPressed(object sender, EventArgs e)
        {
            if (HistoryMode || Error)
            {
                HistoryMode = false;
                Error = false;
                HistoryIndex = 0;
                display.Text = "0";
            }

            if (sender is Button tmp)
            {
                if (display.Text == "0")
                    display.Text = "";
                display.Text += tmp.Text;
            }
        }

        private void BasicSign(object sender, EventArgs e)
        {
            if (HistoryMode || Error)
            {
                HistoryMode = false;
                Error = false;
                HistoryIndex = 0;
                display.Text = "0";
            }
            if (!display.Text.All(char.IsDigit))
                return;

            calculator.FirstOperand = new CHugeNumber(display.Text);
            if (sender is Button tmp)
            {
                calculator.Operation = (CCalculator.Operations)SignsOperations[tmp.Text];
                if (tmp.Text == "log" || tmp.Text == "sqrt")
                    display.Text = display.Text.TrimStart('0');
                display.Text += tmp.Text;
            }
        }

        private void ClearAll(object sender, EventArgs e)
        {
            if (HistoryMode || Error)
            {
                HistoryMode = false;
                Error = false;
                HistoryIndex = 0;
            }
            display.Text = "0";
        }

        private void Cancel(object sender, EventArgs e)
        {
            if (HistoryMode || Error)
            {
                HistoryMode = false;
                Error = false;
                HistoryIndex = 0;
                display.Text = "0";
            }
            string tmp = display.Text;
            if (tmp == "0" || tmp == "")
                return;

            tmp = tmp.Remove(tmp.Length - 1);
            while (tmp.Length > 0 && char.IsLetter(tmp[^1]))
                tmp = tmp.Remove(tmp.Length - 1);

            display.Text = tmp;
        }

        private void History(object sender, EventArgs e)
        {
            if (Error)
            {
                Error = false;
                display.Text = "0";
            }

            HistoryMode = true;
            if (HistoryIndex >= LastCalculated.Count)
                return;

            display.Text = LastCalculated.ElementAt(HistoryIndex);
            HistoryIndex++;
        }

        private void Answer(object sender, EventArgs e)
        {
            if (HistoryMode || Error)
            {
                HistoryMode = false;
                Error = false;
                HistoryIndex = 0;
                display.Text = "0";
            }

            if (sender is Button)
            {
                display.Text = display.Text.TrimStart('0');
                if (display.Text.Length == 0 || char.IsDigit(display.Text[^1]))
                    display.Text = "";

                display.Text += calculator.Ans;
            }
        }
    }
}