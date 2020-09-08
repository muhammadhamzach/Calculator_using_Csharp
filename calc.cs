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
        
       // protected bool oprClicked;                    //check for text field display to zero out for new number
       // protected int oprClickCount = 0;              //counter to see how many operators have been pressed
       // protected float num1, num2;
       // protected string opr;                         //string carrying the operator used for calculation
        protected bool exitCheck = false;       //check to see if either user is changing tab or closing the program across all three tabs
       // protected string operatorArray = "";               //character array to store the list of operators under operations
       // protected bool conscOp = false;                   //check to see if consecutive operator has been pressed 
        protected string key_press = "";                //to store the char received from keyboard input
        //private string[] SpecialOprList = { "%" };
        protected int tab_no = 1;
        protected System.Windows.Forms.Button button20;
        protected System.Windows.Forms.Button button21;
        protected System.Windows.Forms.Button button22;
        protected System.Windows.Forms.Button button23;
        protected System.Windows.Forms.TextBox wordBox;

        dynamic calcObj;

        public Calc()
        {
            InitializeComponent();
            Menu_label.Text = "Basic";
            this.KeyPreview = true;
            calcObj = new CalcBasic();
        }

        private void Form1_Load(object sender, EventArgs e) //loading the calculator form button controls
        {
            foreach (Control c in Controls)
            {
                if (c is Button)
                    c.Click += new System.EventHandler(button_clicked);
            }
        }
    
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)  //tab selection drop selection menu
        {
            if (comboBox1.Text == "Advanced")
            {
                calcObj = new CalcAdv();
                adv_calc_create();
                calcObj.reinitialize_variables();
                outputPanel.Text = "0";
                exitCheck = true;
                tab_no = 2;
                Menu_label.Text = "Advanced";
            }
            else if (comboBox1.Text == "Advanced+")
            {
                calcObj = new CalcAdvPlus();
                advplus_calc_create();
                calcObj.reinitialize_variables();
                outputPanel.Text = "0";
                exitCheck = true;
                tab_no = 3;
                Menu_label.Text = "Advanced+";
            }
            else if (comboBox1.Text == "Basic")
            {
                calcObj = new CalcBasic();
                basic_calc_create();
                calcObj.reinitialize_variables();
                outputPanel.Text = "0";
                exitCheck = true;       //hiding the current window
                tab_no = 1;
                Menu_label.Text = "Basic";
            }
        }

        protected void basic_calc_create()
        {
            this.Controls.Clear();
            InitializeComponent();
            if (tab_no == 1)
            {
                foreach (Control c in Controls)
                {
                    if (c is Button)
                        c.Click += new System.EventHandler(button_clicked);
                }
            }
        }                               //creating basic calc GUI

        protected void adv_calc_create()
        {
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button2.Location = new System.Drawing.Point(98, 157);
            this.button3.Location = new System.Drawing.Point(180, 158);
            this.button4.Location = new System.Drawing.Point(260, 214); 
            this.button1.Location = new System.Drawing.Point(20, 158);
            this.button5.Location = new System.Drawing.Point(20, 214);
            this.button6.Location = new System.Drawing.Point(179, 214);
            this.button7.Location = new System.Drawing.Point(100, 214);
            this.button8.Location = new System.Drawing.Point(20, 269);
            this.button9.Location = new System.Drawing.Point(180, 269);
            this.button10.Location = new System.Drawing.Point(100, 269);
            this.button11.Location = new System.Drawing.Point(20, 324); 
            this.button12.Location = new System.Drawing.Point(179, 325);
            this.button13.Size = new System.Drawing.Size(75, 104);
            this.button14.Location = new System.Drawing.Point(260, 324);
            this.button15.Location = new System.Drawing.Point(260, 269); 
            this.button17.Location = new System.Drawing.Point(260, 158);
            this.button18.Location = new System.Drawing.Point(340, 214);
            this.button19.Location = new System.Drawing.Point(340, 102);
            this.button16.Location = new System.Drawing.Point(340, 158);
            this.button20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.Location = new System.Drawing.Point(20, 102);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(75, 50);
            this.button20.TabIndex = 25;
            this.button20.Text = "CbRT";
            this.button20.UseVisualStyleBackColor = true;
            // button21
            this.button21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.Location = new System.Drawing.Point(98, 102);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(75, 50);
            this.button21.TabIndex = 26;
            this.button21.Text = "x^2";
            this.button21.UseVisualStyleBackColor = true;
            // button22
            this.button22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button22.Location = new System.Drawing.Point(179, 102);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(75, 50);
            this.button22.TabIndex = 27;
            this.button22.Text = "1/x";
            this.button22.UseVisualStyleBackColor = true;
            // button23 
            this.button23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button23.Location = new System.Drawing.Point(260, 102);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(75, 50);
            this.button23.TabIndex = 28;
            this.button23.Text = "SQRT";
            this.button23.UseVisualStyleBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(434, 386);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button20);
            this.Name = "Advanced";
            button20.Click += new System.EventHandler(button_clicked);
            button21.Click += new System.EventHandler(button_clicked);
            button22.Click += new System.EventHandler(button_clicked);
            button23.Click += new System.EventHandler(button_clicked);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        protected void advplus_calc_create()
        {
            adv_calc_create();
            this.wordBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            this.outputPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputPanel.Size = new System.Drawing.Size(395, 31);
           // this.outputPanel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.outputPanel_KeyPress_1);
           // this.wordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordBox.Location = new System.Drawing.Point(20, 77);
            this.wordBox.Name = "wordBox";
            this.wordBox.Size = new System.Drawing.Size(395, 20);
            this.wordBox.TabIndex = 29;
            this.wordBox.Text = "Zero";
            this.wordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // AdvancedPlus
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(434, 386);
            this.Controls.Add(this.wordBox);
            this.Name = "AdvancedPlus";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //over ridden in Adv+ because more functionality
        protected virtual void button_clicked(object sender, EventArgs e)  
        {
            Button button = (Button)sender;
            string text = calcObj.something_clicked_pressed(button.Text, outputPanel.Text);
            outputPanel.Text = text;
            if (tab_no == 3)
            {
                string textword = calcObj.NumberToWords(outputPanel.Text);
                wordBox.Text = textword;
            }
                
        }
        
        private void Calc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.Handled)
                key_press_handler(sender, e);
            e.Handled = true;
            if (tab_no == 3)
            {
                string textword = calcObj.NumberToWords(outputPanel.Text);
                wordBox.Text = textword;
            }
        }

        protected void outputPanel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.Handled)
                key_press_handler(sender, e);
            e.Handled = true;
            if(tab_no == 3)
            {
                string textword = calcObj.NumberToWords(outputPanel.Text);
                wordBox.Text = textword;
            }
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
                string text = calcObj.something_clicked_pressed(key_press, outputPanel.Text);
                outputPanel.Text = text;
            }
            key_press = "";
        }       //key board input validation fntn
       
    }
}
