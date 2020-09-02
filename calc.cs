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
        protected string key_press = "";                //to store the char received from keyboard input
        private string[] SpecialOprList = { "%" };
        protected int tab_no = 1;

        public Calc()
        {
           // if (tab_no == 1)
           // {
                InitializeComponent();
                Menu_label.Text = "Basic";
         //   }
            this.KeyPreview = true;  
        }

        private void Form1_Load(object sender, EventArgs e) //loading the calculator form button controls
        {
            foreach (Control c in Controls)
            {
                if (c is Button)
                    c.Click += new System.EventHandler(button_clicked);
            }
        }

        protected void reinitialize_variables()
        {
            oprClicked = exitCheck = conscOp = false;
            oprClickCount = 0;
            num1 = num2 = 0;
            opr = operatorArray = "";
            outputPanel.Text = "0";
            key_press = "";
    }               //zeroing out the variables for resuse

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)  //tab selection drop selection menu
        {
            if (comboBox1.Text == "Advanced")
            {
                reinitialize_variables();
                exitCheck = true;
                tab_no = 2;
                Menu_label.Text = "Advanced";
            }
            else if (comboBox1.Text == "Advanced+")
            {
                reinitialize_variables();
                exitCheck = true;
                tab_no = 3;
                
            }
            else if (comboBox1.Text == "Basic")
            {
                reinitialize_variables();
                exitCheck = true;       //hiding the current window
                tab_no = 1;
                Menu_label.Text = "Basic";
            }
        }

        protected void basic_calc_create()
        {
            InitializeComponent();
            if (tab_no == 1)
            {
                foreach (Control c in Controls)
                {
                    if (c is Button)
                        c.Click += new System.EventHandler(button_clicked);
                }
            }
        }

        protected virtual void button_clicked(object sender, EventArgs e)  //over riden in Adv+ because more funcionality
        {
            Button button = (Button)sender;
            something_clicked_pressed(button.Text, SpecialOprList);
        }

        private bool notANumber(string text_inp, string[] SpecialOprList)       //check to see if the button clicked is a number or not
        {
            if (text_inp.Equals("+") || text_inp.Equals("-") || text_inp.Equals("x") || text_inp.Equals("/") || text_inp.Equals("=") || SpecialOprList.Contains(text_inp))
                return true;
            else
                return false;
        }

        protected void something_clicked_pressed(string text_inp, string[] SpecialOprList)  //if either valid keyboard key or button is pressed
        {
            if (text_inp.Equals("C"))            //if button pressed is "clear entry" CE
                outputPanel.Text = "0";
            else if (text_inp.Equals("AC"))
                reinitialize_variables();
            else if (!notANumber(text_inp, SpecialOprList))   //if the button pressed is either a number or dec point
            {
                if (oprClicked)             //zeroing out the field for new number entry every type check
                {
                    outputPanel.Text = "0";
                    oprClicked = false;
                }
                if (outputPanel.Text.Equals("0") && (!text_inp.Equals("."))) //check to see if the first button clicked is a number and not a decimal point i.e not 0.7 something 
                    outputPanel.Text = text_inp;
                else
                {
                    if (text_inp.Equals(".") && !outputPanel.Text.Contains("."))   //check to see if there already isnt a decimal point in the code then if true placee the decimal point
                        outputPanel.Text += text_inp;

                    if (!text_inp.Equals("."))     //check to see if a number is clicked and not a decimal point
                        outputPanel.Text += text_inp;
                }
                conscOp = false;
            }
            else
            {
                if (oprClickCount == 0)           //check to see if its the first time operator has been pressed
                {
                    num1 = float.Parse(outputPanel.Text);
                    if (opr != text_inp)
                        oprClickCount++;
                    opr = text_inp;
                    oprClicked = true;
                    if (SpecialOprList.Contains(text_inp))
                    {
                        num1 = calculations(opr, num1, 0);
                        outputPanel.Text = Convert.ToString(num1);
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
                            num2 = float.Parse(outputPanel.Text);
                        num1 = calculations(opr, num1, num2);
                        operatorArray = text_inp;
                        conscOp = true;
                    }
                    else
                    {
                        if (!SpecialOprList.Contains(opr) && operatorArray != "=") //making sure last calc wasnt of percentage conditions like these 67%+5 
                        {
                            num2 = float.Parse(outputPanel.Text);
                            if (operatorArray.Length == 1 && conscOp == false)
                            {
                                num1 = calculations(opr, num1, num2);
                                conscOp = true;
                            }
                        }
                        operatorArray = opr = text_inp;     //passing the last pressed operator
                        if (SpecialOprList.Contains(opr))     //if the user pressed % after some calc like 4+5%
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

        private void Calc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.Handled)
                key_press_handler(sender, e);
            e.Handled = true;
        }

        protected void outputPanel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.Handled)
                key_press_handler(sender, e);
            e.Handled = true;
        }   //keyboard key pressed on output panel

        protected void key_press_handler(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar.Equals('/') || e.KeyChar.Equals('*') || e.KeyChar.Equals('+') ||
                e.KeyChar.Equals('-') || e.KeyChar.Equals('%') || e.KeyChar == (char)Keys.Escape || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Enter)
            {
                if (e.KeyChar.Equals('*'))
                    key_press = "x";
                else if (e.KeyChar == (char)Keys.Escape)
                    key_press = "AC";
                else if (e.KeyChar == (char)Keys.Back)
                    key_press = "C";
                else if (e.KeyChar == (char)Keys.Enter)
                    key_press = "=";
                else
                    key_press = e.KeyChar.ToString();
                e.Handled = true;
                something_clicked_pressed(key_press, SpecialOprList);
            }
            key_press = "";
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

        private void Calc_FormClosing(object sender, FormClosingEventArgs e)        //form closing event 
        {
            if (!exitCheck)
                Application.Exit();
        }
    }
}
