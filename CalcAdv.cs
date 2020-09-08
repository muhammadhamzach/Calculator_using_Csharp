using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class CalcAdv : CalcBasic
    {
        #region Over-Riding Functions for Advanced Functionality on Basic Calc

        protected string[] SpecialOprList = { "%", "SQRT", "1/x", "CbRT", "x^2" };

        protected override string[] getOprList()
        {
            return SpecialOprList;
        }

        protected override float calculations(string opr, float n1, float n2)      //functions to perform the mathematical function as requested by user
        {
            float result = 0;
            switch (opr)
            {
                case "+":
                    result = n1 + n2;
                    break;
                case "-":
                    result = n1 - n2;
                    break;
                case "/":
                    if (n2 != 0)
                        result = n1 / n2;
                    break;
                case "x":
                    result = n1 * n2;
                    break;
                case "%":
                    result = n1 / 100;
                    break;
                case "SQRT":
                    result = (float)Math.Sqrt(Convert.ToDouble(n1));
                    break;
                case "1/x":
                    if (n1 != 0)
                        result = 1 / n1;
                    break;
                case "x^2":
                    result = (float)Math.Pow(Convert.ToDouble(n1), 2);
                    break;
                case "CbRT":
                    result = (float)(Math.Pow(Convert.ToDouble(n1), (double)1 / 3));
                    break;
                default:
                    result = n1;
                    break;
            }
            return result;
        }
        #endregion
    }
}
