using System;
using System.Collections.Generic;
using System.Text;

namespace StackCalculator
{
    public class StackCalculator
    {
        Stack<decimal> stack = new Stack<decimal>();
        StringBuilder result = new StringBuilder();

        public string Calculate(string[] commands)
        {
            foreach (var command in commands)
            {
                var splits = command.Split(' ');

                if (splits.Length > 0)
                {
                    switch (splits[0])
                    {
                        case "PUSH":
                            Push(splits);
                            break;
                        case "PRINT":
                            Print();
                            break;
                        case "POP":
                            Pop();
                            break;
                        case "ADD":
                            Add();
                            break;
                        case "SUBTRACT":
                            Subtract();
                            break;
                        case "DIVIDE":
                            Push(splits);
                            break;
                        case "MULTIPLY":
                            Print();
                            break;
                        default:
                            Console.WriteLine("Unknown command");
                            break;
                    }
                }
            }
            return result.ToString();
        }

        void Push(string[] splits)
        {
            if (splits.Length > 1)
            {
                var number = decimal.Parse(splits[1]);
                stack.Push(number);
            }
        }

        void Pop()
        {
            if (stack.Count > 0)
            {
                stack.Pop();
            }
        }

        void Print()
        {
            if (stack.Count > 0)
                result.AppendLine(stack.Peek().ToString());
        }

        void Add()
        {
            if (stack.Count >= 2)
            {
                stack.Push(stack.Pop() + stack.Pop());
            }
        }

        void Subtract()
        {
            if (stack.Count >= 2)
            {
                decimal number1 = stack.Pop();
                decimal number2 = stack.Pop();
                stack.Push((number2) - (number1));
            }
        }

        void Multiply()
        {
            if (stack.Count >= 2)
            {
                stack.Push((stack.Pop()) * (stack.Pop()));
            }
        }

        void Divide()
        {
            if (stack.Count >= 2)
            {
                decimal number1 = stack.Pop();
                decimal number2 = stack.Pop();

                if (number1 != 0)
                {
                    stack.Push((number2) / (number1));
                }
                else
                {
                    stack.Push(number2);
                    stack.Push(number1);
                }
            }
        }
    }
}
