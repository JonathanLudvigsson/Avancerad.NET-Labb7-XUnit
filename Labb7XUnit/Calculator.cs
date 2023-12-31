﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Labb7XUnit
{
    public class Calculator
    {
        public static List<string> calculations = new List<string>();

        public static double Addition(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Subtraction(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Division(double n1, double n2)
        {
            if (n2 == 0)
            {
                return 0;
            }
            return n1 / n2;
        }

        public static double Multiplication(double n1, double n2)
        {
            return n1 * n2;
        }

        public static bool CreateResult(string choice, double n1, double n2, double result)
        {
            char operation = GetOperationSymbol(choice);
            if (CheckDivideZero(choice, n2) || !CheckValidCalculation(choice))
            {
                return false;
            }
            else
            {
                calculations.Add($"{n1}{operation}{n2} = {result}");
                return true;
            }
        }

        public static char GetOperationSymbol(string choice)
        {
            char operation = '0';
            switch (choice)
            {
                case "1":
                    operation = '+';
                    break;
                case "2":
                    operation = '-';
                    break;
                case "3":
                    operation = '/';
                    break;
                case "4":
                    operation = '*';
                    break;
                default: break;
            }
            return operation;
        }

        public static bool CheckDivideZero(string choice, double n2)
        {
            return choice == "3" && n2 == 0;
        }

        public static bool CheckValidCalculation(string choice)
        {
            return choice == "1" || choice == "2" || choice == "3" || choice == "4";
        }
    }
}
