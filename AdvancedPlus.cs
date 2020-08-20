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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)  //tab selection drop selection menu
        {
            if (comboBox1.Text == "Basic")
            {
                exitCheck = true;
                reinitialize_variables();
                Calc basic = new Calc();
                basic.Show();
                this.Close();            //hiding the current window
            }
            else if (comboBox1.Text == "Advanced")
            {
                exitCheck = true;
                reinitialize_variables();
                Advanced adv = new Advanced();
                this.Close();          //hiding the current window
            }
        }

        private void AdvancedPlus_Load(object sender, EventArgs e)
        {

        }

        private void AdvancedPlus_FormClosing(object sender, FormClosingEventArgs e)  //application closed via advplus tab
        {
            if (!exitCheck)
                Application.Exit();
        }

      
    }
}
