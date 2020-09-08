using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class CalcBasic
    {
        protected bool oprClicked;                    //check for text field display to zero out for new number
        protected int oprClickCount = 0;              //counter to see how many operators have been pressed
        protected float num1, num2;
        protected string opr;                         //string carrying the operator used for calculation
        protected string operatorArray = "";               //character array to store the list of operators under operations
        protected bool conscOp = false;                   //check to see if consecutive operator has been pressed 
        private string[] SpecialOprList = { "%" };

        public void reinitialize_variables()
        {
            oprClicked = conscOp = false;
            oprClickCount = 0;
            num1 = num2 = 0;
            opr = operatorArray = "";
        }               //zeroing out the variables for resuse

        #region Handling the Inputs to the Calculator
        protected virtual string[] getOprList()
        {
            return SpecialOprList;
        }

        private bool notANumber(string text_inp, string[] SpecialOprList)       //check to see if the button clicked is a number or not
        {
            if (text_inp.Equals("+") || text_inp.Equals("-") || text_inp.Equals("x") || text_inp.Equals("/") || text_inp.Equals("=") || getOprList().Contains(text_inp))
                return true;
            else
                return false;
        }

        public string something_clicked_pressed(string text_inp, string outputPanelText)  //if either valid keyboard key or button is pressed
        {
            if (text_inp.Equals("C"))            //if button pressed is "clear entry" CE
                outputPanelText = "0";
            else if (text_inp.Equals("AC"))
            {
                reinitialize_variables();
                outputPanelText = "0";
            }
            else if (!notANumber(text_inp, getOprList()))   //if the button pressed is either a number or dec point
            {
                if (oprClicked)             //zeroing out the field for new number entry every type check
                {
                    outputPanelText = "0";
                    oprClicked = false;
                }
                if (outputPanelText.Equals("0") && (!text_inp.Equals("."))) //check to see if the first button clicked is a number and not a decimal point i.e not 0.7 something 
                    outputPanelText = text_inp;
                else
                {
                    if (text_inp.Equals(".") && !outputPanelText.Contains("."))   //check to see if there already isnt a decimal point in the code then if true placee the decimal point
                        outputPanelText += text_inp;

                    if (!text_inp.Equals("."))     //check to see if a number is clicked and not a decimal point
                        outputPanelText += text_inp;
                }
                conscOp = false;
            }
            else
            {
                if (oprClickCount == 0)           //check to see if its the first time operator has been pressed
                {
                    num1 = float.Parse(outputPanelText);
                    if (opr != text_inp)
                        oprClickCount++;
                    opr = text_inp;
                    oprClicked = true;
                    if (getOprList().Contains(text_inp))
                    {
                        num1 = calculations(opr, num1, 0);
                        outputPanelText = Convert.ToString(num1);
                    }
                    operatorArray = text_inp;
                    conscOp = true;
                }
                else  //if the operator has been pressed beforehand
                {
                    //finding the result from the calc of two no with given operator and displaying in the box
                    if (text_inp.Equals("="))  //if the user has pressed another operator then storing operator in the string variable
                    {
                        if (!conscOp)      //bug fix for consecutive "=" presses
                            num2 = float.Parse(outputPanelText);
                        num1 = calculations(opr, num1, num2);
                        operatorArray = text_inp;
                        conscOp = true;
                    }
                    else
                    {
                        if (!getOprList().Contains(opr) && operatorArray != "=") //making sure last calc wasnt of percentage conditions like these 67%+5 
                        {
                            num2 = float.Parse(outputPanelText);
                            if (operatorArray.Length == 1 && conscOp == false)
                            {
                                num1 = calculations(opr, num1, num2);
                                conscOp = true;
                            }
                        }
                        operatorArray = opr = text_inp;     //passing the last pressed operator
                        if (getOprList().Contains(opr))     //if the user pressed % after some calc like 4+5%
                        {
                            num1 = calculations(opr, num1, 0);
                            num2 = 0;
                        }
                        oprClickCount++;
                    }

                    outputPanelText = Convert.ToString(num1);
                    oprClicked = true;
                }
            }
            return outputPanelText;
        }

        protected virtual float calculations(string opr, float n1, float n2)      //functions to perform the mathematical function as requested by user
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
                default:
                    result = n1;
                    break;
            }
            return result;
        }
        #endregion
    }
}
