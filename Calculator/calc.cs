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
        Button button20 = new Button();
        Button button21 = new Button();
        Button button22 = new Button();
        Button button23 = new Button();
        TextBox wordConverter = new TextBox();


        public Calc()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) //loading the calculator form
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
                advanced_tab_create();
            else if (comboBox1.Text == "Advanced+")
                advancedplus_tab_create();
            else
                basic_tab_create();

        }

        public void basic_tab_create()
        {
            this.Height = 370;
            if (tabNo != 1)
            {
                this.button1.Top = this.button1.Top - 55;
                this.button2.Top = this.button2.Top - 55;
                this.button3.Top = this.button3.Top - 55;
                this.button4.Top = this.button4.Top - 55;
                this.button5.Top = this.button5.Top - 55;
                this.button6.Top = this.button6.Top - 55;
                this.button7.Top = this.button7.Top - 55;
                this.button8.Top = this.button8.Top - 55;
                this.button9.Top = this.button9.Top - 55;
                this.button10.Top = this.button10.Top - 55;
                this.button11.Top = this.button11.Top - 55;
                this.button11.Width = 75;
                this.button11.Left = 100;
                this.button12.Top = this.button12.Top - 55;
                this.button12.Left = 20;
                this.button13.Top = this.button13.Top - 55;
                this.button14.Top = this.button14.Top - 55;
                this.button15.Top = this.button15.Top - 55;
                this.button17.Top = this.button17.Top - 55;
                this.button18.Top = 270;
                this.button18.Left = 180;
                this.Controls.Remove(wordConverter);
                outputPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Controls.Remove(button20);
                this.Controls.Remove(button21);
                this.Controls.Remove(button22);
                this.Controls.Remove(button23);
            }
            tabNo = 1;
        }


        public void advanced_tab_create()
        {
            
            if (tabNo == 1)
            {
                this.Height = 425;
                this.button1.Top = this.button1.Top + 55;
                this.button2.Top = this.button2.Top + 55;
                this.button3.Top = this.button3.Top + 55;
                this.button4.Top = this.button4.Top + 55;
                this.button5.Top = this.button5.Top + 55;
                this.button6.Top = this.button6.Top + 55;
                this.button7.Top = this.button7.Top + 55;
                this.button8.Top = this.button8.Top + 55;
                this.button9.Top = this.button9.Top + 55;
                this.button10.Top = this.button10.Top + 55;
                this.button11.Top = this.button11.Top + 55;
                this.button11.Width += 80;
                this.button11.Left = 20;
                this.button12.Top = this.button12.Top + 55;
                this.button12.Left = 180;
                this.button13.Top = this.button13.Top + 55;
                this.button14.Top = this.button14.Top + 55;
                this.button15.Top = this.button15.Top + 55;
                this.button17.Top = this.button17.Top + 55;
                this.button18.Top = 215;
                this.button18.Left = 340;
                button20.Location = new Point(20, 105);
                button21.Location = new Point(100, 105);
                button22.Location = new Point(180, 105);
                button23.Location = new Point(260, 105);
                button20.Text = "CbRT";
                button21.Text = "x^2";
                button22.Text = "1/x";
                button23.Text = "SQRT";
                button20.Font = new Font("Microsoft Sans Sarif", 12);
                button21.Font = new Font("Microsoft Sans Sarif", 12);
                button22.Font = new Font("Microsoft Sans Sarif", 12);
                button23.Font = new Font("Microsoft Sans Sarif", 12);
                button20.Font = new Font("Microsoft Sans Sarif", 12);
                button20.Size = new System.Drawing.Size(75, 50);
                button21.Size = new System.Drawing.Size(75, 50);
                button22.Size = new System.Drawing.Size(75, 50);
                button23.Size = new System.Drawing.Size(75, 50);
                this.Controls.Add(button20);
                this.Controls.Add(button21);
                this.Controls.Add(button22);
                this.Controls.Add(button23);
            }
            if (tabNo == 3)
            {
                this.Controls.Remove(wordConverter);
                outputPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            
            

            tabNo = 2;
        }

        public void advancedplus_tab_create()
        {
            if(tabNo != 3)
            {
                this.outputPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                wordConverter.Location = new System.Drawing.Point(20, 80);
                wordConverter.Size = new System.Drawing.Size(395, 35);
                wordConverter.TabIndex = 0;
                wordConverter.Text = "Zero";
                wordConverter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.Controls.Add(wordConverter);
            }
            if (tabNo==1)
            {
                this.Height = 425;
                this.button1.Top = this.button1.Top + 55;
                this.button2.Top = this.button2.Top + 55;
                this.button3.Top = this.button3.Top + 55;
                this.button4.Top = this.button4.Top + 55;
                this.button5.Top = this.button5.Top + 55;
                this.button6.Top = this.button6.Top + 55;
                this.button7.Top = this.button7.Top + 55;
                this.button8.Top = this.button8.Top + 55;
                this.button9.Top = this.button9.Top + 55;
                this.button10.Top = this.button10.Top + 55;
                this.button11.Top = this.button11.Top + 55;
                this.button11.Width += 80;
                this.button11.Left = 20;
                this.button12.Top = this.button12.Top + 55;
                this.button12.Left = 180;
                this.button13.Top = this.button13.Top + 55;
                this.button14.Top = this.button14.Top + 55;
                this.button15.Top = this.button15.Top + 55;
                this.button17.Top = this.button17.Top + 55;
                this.button18.Top = 215;
                this.button18.Left = 340;
                button20.Location = new Point(20, 105);
                button21.Location = new Point(100, 105);
                button22.Location = new Point(180, 105);
                button23.Location = new Point(260, 105);
                button20.Text = "CbRT";
                button21.Text = "x^2";
                button22.Text = "1/x";
                button23.Text = "SQRT";
                button20.Font = new Font("Microsoft Sans Sarif", 12);
                button21.Font = new Font("Microsoft Sans Sarif", 12);
                button22.Font = new Font("Microsoft Sans Sarif", 12);
                button23.Font = new Font("Microsoft Sans Sarif", 12);
                button20.Font = new Font("Microsoft Sans Sarif", 12);
                button20.Size = new System.Drawing.Size(75, 50);
                button21.Size = new System.Drawing.Size(75, 50);
                button22.Size = new System.Drawing.Size(75, 50);
                button23.Size = new System.Drawing.Size(75, 50);
                this.Controls.Add(button20);
                this.Controls.Add(button21);
                this.Controls.Add(button22);
                this.Controls.Add(button23);
            }
            tabNo = 3;
        }


        public void button_clicked(object sender, EventArgs e)  //if any button except AC is pressed
        {
            Button button = (Button)sender;
        //    if (button.Text.Equals("z"))
        //        Calc.
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
