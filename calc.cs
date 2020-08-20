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
        bool oprClicked, onceClick;
        int oprClickCount = 0;
        float num1, num2, tempNum = 0 ;
        string opr;
        int tabNo = 1;

        public Calc()
        {
            InitializeComponent();
        }
        protected void Form1_Load(object sender, EventArgs e) //loading the calculator form
        {
            foreach (Control c in Controls)
            {
                if (c is Button)
                    if (c.Text != "AC" && c.Text != "CE")
                        c.Click += new System.EventHandler(button_clicked);
                    else if (c.Text == "AC")    
                        c.Click += new System.EventHandler(buttonResetAll_Click);   //if button pressed is All Clear "AC"
            }
        }

        private void buttonResetAll_Click(object sender, EventArgs e)   //event to clear memory of everything
        {
            num1 = 0;
            num2 = 0;
            oprClicked = false;
            oprClickCount = 0;
            outputPanel.Text = "0";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Advanced")
            {
                Advanced adv = new Advanced();
                adv.Show();
                this.Hide();
            }
            else if (comboBox1.Text == "Advanced+")
            {
                AdvancedPlus advpl = new AdvancedPlus();
                advpl.Show();
                this.Hide();
            }
        }



        public void button_clicked(object sender, EventArgs e)  //if any button except AC is pressed
        {
            Button button = (Button)sender;
            if (button.Text.Equals("C"))            //if button pressed is "clear entry" CE
                outputPanel.Text = "0";
            else if (!notANumber(button))   //if the button pressed is either a number or dec point
            {
                if (oprClicked)
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
                    //    oprClicked = false;
                }
                else  //if the operator has been pressed beforehand
                {
                    //finding the result from the calc of two no with given operator and displaying in the box
                    if (button.Text.Equals("="))  //if the user has pressed another operator then storing operator in the string variable
                    {
                        if (num1 != float.Parse(outputPanel.Text))      //bug fix for consecutive "=" presses
                            num2 = float.Parse(outputPanel.Text);
                        num1 = calculations(opr, num1, num2);
                        num2 = 0;
                    }
                    else
                    {
                        if (opr != "%") //making sure last calc wasnt of percentage conditions like these 67%+5 
                        {
                            num2 = float.Parse(outputPanel.Text);
                            num1 = calculations(opr, num1, num2);
                        }
                            
                        opr = button.Text;     //passing the last pressed operator
                        if (opr == "%")     //if the user pressed % after some calc like 4+5%
                            num1 = calculations(opr, num1, num2);

                        oprClickCount++;
                    }
                    outputPanel.Text = Convert.ToString(num1);
                    oprClicked = true;
                }
            }
        }

        public bool notANumber(Button button)       //check to see if the button clicked is a number or not
        {
            string buttonText = button.Text;

            if (buttonText.Equals("+") || buttonText.Equals("-") || buttonText.Equals("x") || buttonText.Equals("/") || buttonText.Equals("=") || buttonText.Equals("%"))
                return true;
            else
                return false;

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
