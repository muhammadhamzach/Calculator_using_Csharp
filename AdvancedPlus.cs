using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class AdvancedPlus : Calculator.Advanced
    {

        public AdvancedPlus()
        {
            InitializeComponent();
           
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Basic")
            {
                Calc basic = new Calc();
                basic.Show();
                this.Close();
            }
            else if (comboBox1.Text == "Advanced")
            {
                Advanced adv = new Advanced();
                this.Close();
            }
        }
    }
}
