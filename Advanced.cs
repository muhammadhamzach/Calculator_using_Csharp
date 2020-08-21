using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Advanced : Calculator.Calc
    {
        public Advanced()
        {
            InitializeComponent();
        }

        private void outputPanel_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)       //tab selection drop selection menu
        {
            if (comboBox1.Text == "Basic")
            {
                reinitialize_variables();
                exitCheck = true;
                Calc basic = new Calc();
                basic.Show();
                this.Close();        //hiding the current window
            }
            else if (comboBox1.Text == "Advanced+")
            {
                reinitialize_variables();
                exitCheck = true;
                AdvancedPlus advpl = new AdvancedPlus();
                this.Close();        //hiding the current window
            }
        }

        private void Advanced_FormClosed(object sender, FormClosedEventArgs e)      //application closed via adv tab
        {
            if (!exitCheck)
                Application.Exit();
        }

        protected override void button_clicked(object sender, EventArgs e)  //if any button except AC is pressed
        {
            Button button = (Button)sender;
            if (button.Text.Equals("C"))            //if button pressed is "clear entry" CE
                outputPanel.Text = "0";
            else if (!notANumber(button))   //if the button pressed is either a number or dec point
            {
                if (oprClicked)             //zeroing out the field for new number entry every type check
                {
                    outputPanel.Text = "0";
                    oprClicked = false;
                }
                if (outputPanel.Text.Equals("0") && !button.Text.Equals(".")) //check to see if the first button clicked is a number and not a decimal point i.e not 0.7 something 
                    outputPanel.Text = button.Text;
                else
                {
                    if (button.Text.Equals(".") && !outputPanel.Text.Contains("."))   //check to see if there already isnt a decimal point in the code then if true placee the decimal point
                        outputPanel.Text += button.Text;
                    if (!button.Text.Equals("."))     //check to see if a number is clicked and not a decimal point
                        outputPanel.Text += button.Text;
                }
                conscOp = false;
            }
            else
            {
                if (oprClickCount == 0)           //check to see if its the first time operator has been pressed
                {
                    num1 = float.Parse(outputPanel.Text);
                    if (opr != button.Text)
                        oprClickCount++;
                    opr = button.Text;
                    oprClicked = true;
                    if (button.Text.Equals("%") || button.Text.Equals("SQRT") || button.Text.Equals("1/x") || button.Text.Equals("CbRT") || button.Text.Equals("x^2"))
                    {
                        num1 = calculations(opr, num1, 0);
                        outputPanel.Text = Convert.ToString(num1);
                    }
                    operatorArray = button.Text;
                    conscOp = true;
                }
                else  //if the operator has been pressed beforehand
                {
                    //finding the result from the calc of two no with given operator and displaying in the box
                    if (button.Text.Equals("="))  //if the user has pressed another operator then storing operator in the string variable
                    {
                        if (num1 != float.Parse(outputPanel.Text))      //bug fix for consecutive "=" presses
                            num2 = float.Parse(outputPanel.Text);
                        num1 = calculations(opr, num1, num2);
                        operatorArray = button.Text;
                    }
                    else
                    {
                        if (opr != "%" && opr != "SQRT" && opr != "1/x" && opr != "CbRT" && opr != "x^2" && operatorArray != "=") //making sure last calc wasnt of percentage conditions like these 67%+5 
                        {
                            num2 = float.Parse(outputPanel.Text);
                            if (operatorArray.Length == 1 && conscOp == false)
                            {
                                num1 = calculations(opr, num1, num2);
                                conscOp = true;
                            }

                        }
                        operatorArray = opr = button.Text;     //passing the last pressed operator
                        if (opr == "%" || opr == "SQRT" || opr == "1/x" || opr == "CbRT" || opr == "x^2")     //if the user pressed % after some calc like 4+5%
                        {
                            num1 = calculations(opr, num1, 0);
                            num2 = 0;
                        }

                        oprClickCount++;
                    }
                    outputPanel.Text = Convert.ToString(num1);
                    oprClicked = true;
                }
            }
        }

        protected bool notANumber(Button button)       //check to see if the button clicked is a number or not
        {
            string buttonText = button.Text;

            if (buttonText.Equals("+") || buttonText.Equals("-") || buttonText.Equals("x") || buttonText.Equals("/") || buttonText.Equals("=") || buttonText.Equals("%") || buttonText.Equals("1/x") || buttonText.Equals("SQRT") || buttonText.Equals("x^2") || buttonText.Equals("CbRT"))
                return true;
            else
                return false;
        }

        protected float calculations(string opr, float n1, float n2)      //functions to perform the mathematical function as requested by user
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
                    result = 1 / n1;
                    break;
                case "x^2":
                    result = (float)Math.Pow(Convert.ToDouble(n1), 2);
                    break;
                case "CbRT":
                    result = (float)Math.Ceiling(Math.Pow(Convert.ToDouble(n1), (double)1/3));
                    break;
                default:
                    result = n1;
                    break;
            }
            return result;
        }

        protected void Advanced_Load(object sender, EventArgs e)
        {
        }
    }
}
