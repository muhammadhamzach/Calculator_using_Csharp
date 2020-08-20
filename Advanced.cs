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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Basic")
            {
                Calc basic = new Calc();
                basic.Show();
                this.Close();
            }
            else if (comboBox1.Text == "Advanced+")
            {
                AdvancedPlus advpl = new AdvancedPlus();
                this.Close();
            }
        }
    }
}
