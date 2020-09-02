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
        private string[] SpecialOprList = { "%", "SQRT", "1/x", "CbRT", "x^2"};

        public Advanced()
        {
            InitializeComponent();
            Menu_label.Text = "Advanced";
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)       //tab selection drop selection menu
        {
            if (comboBox1.Text == "Basic")
            {
                reinitialize_variables();
                exitCheck = true;
                Calc basic = new Calc();
                basic.Show();
                this.Hide();        //hiding the current window
            }
            else if (comboBox1.Text == "Advanced+")
            {
                reinitialize_variables();
                exitCheck = true;
                AdvancedPlus advpl = new AdvancedPlus();
                this.Hide();        //hiding the current window
            }
        }

        protected override void button_clicked(object sender, EventArgs e)  //if any button except AC is pressed
        {
            Button button = (Button)sender;
            something_clicked_pressed(button.Text, SpecialOprList);
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
                    result = (float)(Math.Pow(Convert.ToDouble(n1), (double)1/3));
                    break;
                default:
                    result = n1;
                    break;
            }
            return result;
        }

        private void Advanced_FormClosed(object sender, FormClosedEventArgs e)      //application closed via adv tab
        {
            if (!exitCheck)
                Application.Exit();
        }
    }
}
