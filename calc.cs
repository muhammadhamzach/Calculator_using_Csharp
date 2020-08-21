using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calc : Form
    {
        protected bool oprClicked;                    //check for text field display to zero out for new number
        protected int oprClickCount = 0;              //counter to see how many operators have been pressed
        protected float num1, num2;
        protected string opr;                         //string carrying the operator used for calculation
        protected bool exitCheck = false;       //check to see if either user is changing tab or closing the program across all three tabs
        protected string operatorArray = "";               //character array to store the list of operators under operations
        protected bool conscOp = false;                   //check to see if consecutive operator has been pressed 

        public Calc()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //loading the calculator form button controls
        {
            foreach (Control c in Controls)
            {
                if (c is Button)
                    if (c.Text != "AC")                   //any button that isnt AC 
                        c.Click += new System.EventHandler(button_clicked);
                    else if (c.Text == "AC")    
                        c.Click += new System.EventHandler(buttonResetAll_Click);   //if button pressed is All Clear "AC"
            }
        }

        protected void reinitialize_variables()
        {
            oprClicked = exitCheck = conscOp = false;
            oprClickCount = 0;
            num1 = num2 = 0;
            opr = operatorArray = "";
            outputPanel.Text = "0";
        }               //zeroing out the variables for resuse

        protected void buttonResetAll_Click(object sender, EventArgs e)   //event to clear memory of everything
        {
            reinitialize_variables();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)  //tab selection drop selection menu
        {
            if (comboBox1.Text == "Advanced")
            {
                reinitialize_variables();
                exitCheck = true;
                Advanced adv = new Advanced();
                adv.Show();         //opening up the advanced window
                this.Hide();        //hiding the current window
            }
            else if (comboBox1.Text == "Advanced+")
            {
                reinitialize_variables();
                exitCheck = true;
                AdvancedPlus advpl = new AdvancedPlus();
                advpl.Show();
                this.Hide();        //hiding the current window
            }
        }

        protected virtual void button_clicked(object sender, EventArgs e)  //if any button except AC is pressed
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
                    if (button.Text.Equals("%"))
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
                        if (opr != "%" && operatorArray != "=") //making sure last calc wasnt of percentage conditions like these 67%+5 
                        {
                            num2 = float.Parse(outputPanel.Text);
                            if (operatorArray.Length == 1 && conscOp == false)
                            {
                                num1 = calculations(opr, num1, num2);
                                
                                conscOp = true;
                            }
                            //operatorArray = button.Text;

                        }
                        operatorArray = opr = button.Text;     //passing the last pressed operator
                        if (opr == "%")     //if the user pressed % after some calc like 4+5%
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

        private bool notANumber(Button button)       //check to see if the button clicked is a number or not
        {
            string buttonText = button.Text;

            if (buttonText.Equals("+") || buttonText.Equals("-") || buttonText.Equals("x") || buttonText.Equals("/") || buttonText.Equals("=") || buttonText.Equals("%"))
                return true;
            else
                return false;

        }

        private void Calc_FormClosing(object sender, FormClosingEventArgs e)        //form closing event 
        {
            if (!exitCheck)
                Application.Exit();
        }

        private float calculations(string opr, float n1, float n2)      //functions to perform the mathematical function as requested by user
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
                    result = n1/100;
                    break;
                default:
                    result = n1;
                    break;
            }

            return result;
        }
    }

}
