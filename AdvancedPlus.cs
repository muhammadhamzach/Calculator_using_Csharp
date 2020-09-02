using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Calculator
{
    public partial class AdvancedPlus : Advanced
    {
        string[] units = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        string[] tens =  { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty", "Thirty", "Forty",
                                "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};

        public AdvancedPlus()
        {
           comboBox1.SelectedIndexChanged += new System.EventHandler(template_create);
        }

        private void template_create(object sender, EventArgs e)
        {
            this.Controls.Clear();
            if (tab_no == 3)
            {
                basic_calc_create();
                adv_calc_create();
                advpl_calc_create();
                Menu_label.Text = "Advanced+";
            }
            if (tab_no == 2)
            {
                basic_calc_create();
                adv_calc_create();
                Menu_label.Text = "Advanced";
            }  
            if (tab_no == 1)
            {
                basic_calc_create();
                Menu_label.Text = "Basic";
            }
            comboBox1.SelectedIndexChanged += new System.EventHandler(template_create);
        }       //deciding what GUI to make

        private void advpl_calc_create()
        {
            InitializeComponent();
        }                           //ceating adv+ GUI

        private void NumberToWords(object sender, EventArgs e)
        {
            string isNegative = "";
            string number = outputPanel.Text;
            string word = "";

            if (number.Contains("-"))       //negative number check
            {
                isNegative = "Minus ";
                number = number.Substring(1, number.Length - 1);        //extracting from the string... i.e removes -ve symbol and string end-character 
            }
            if (number == "0")      //if no is Zero then do nothing else xD
                word = "Zero";
            else                    //if no is non-zero
                word =  isNegative + ConvertToWords(number);

               wordBox.Text = word;         //putting the text onto the panel
                   
        }       //conversion initializer for Neg/Pos dec no

        private String ConvertToWords(String number)
        {
            String value = "", points = "", andStr = "", pointStr = "", wholeNo = number;

            try {
                decimal d = Decimal.Parse(number, System.Globalization.NumberStyles.Float);
                number = d.ToString();
            }
            catch
            {
                return value;
            }
            int decimalPlace = number.IndexOf(".");     //finding the index of decimal place
            if (decimalPlace > 0)           //if decimal point exists
            {
                wholeNo = number.Substring(0, decimalPlace);        //whole no seperate
                points = number.Substring(decimalPlace + 1);        //decimal no separate
                if (points != "")                                  //making sure there is some no after decimal point
                    if (Convert.ToInt32(points) > 0)                //converting decimal string into number for calc
                    {
                        andStr = " Point";// decimal point 
                        pointStr = ConvertDecimals(points);
                    }
            }
            value = ConvertWholeNumber(wholeNo).Trim() + andStr + pointStr;         //final word formed from number
            
            return value;
        }               //converting full no into words

        private String ConvertDecimals(String number)       //converting after dec point numbers into words
        {
            String decimalAfter = "";
            int digit;
            
            for (int i = 0; i < number.Length; i++)     //looping through all no after point and writing each number on the panel
            {
                digit = Int32.Parse(number[i].ToString());
                decimalAfter += " " + units[digit];
            }
            return decimalAfter;
        }

        private String ConvertWholeNumber(String Number)        //for converting the whole no part into words
        {
            string word = "";
            bool digit_left_check = false;
            double x;
            double Number_double;

            try
            {
                decimal Number_decimal = (Decimal.Parse(Number));
                if (Number_decimal > 0) digit_left_check = true;
                Number_double = (double)Number_decimal;
            }
            catch
            {
                try {
                    Number_double = (Convert.ToDouble(Number));
                    if (Number_double > 0 && Number_double < 1E+15) digit_left_check = true;
                }
                catch { Number_double = 0; } 
            }
           
            if (digit_left_check)
            {
                Number = Number_double.ToString();              //check to remove any preceeding zero like 000001 = 1 etc.
                int numDigits = Number.Length;          
                int digit;
                    
                switch (numDigits)
                {
                    case 1:                 //ones' range    
                        digit = Int32.Parse(Number.ToString());
                        word = units[digit];
                        break;
                    case 2:                 //tens' range    
                        digit = Int32.Parse(Number[1].ToString());
                        if (Number[0].ToString().Equals("1"))           // if no > 9 and no < 20
                            word = tens[digit];
                        else                                            //if no > 20 and no < 100
                        {
                            word = tens[Int32.Parse(Number[0].ToString()) + 8];
                            word += " ";
                            word += units[digit];
                        } 
                        break;
                    case 3:                 //hundreds' range    
                        word = ConvertWholeNumber(Number[0].ToString()) + " Hundred " + ConvertWholeNumber(Number.Substring(1));
                        break;
                    case 4:                 //thousands' range    
                        word = units[Int32.Parse(Number[0].ToString())] + " Thousand " + ConvertWholeNumber(Number.Substring(1));
                        break;
                    case 5:                 //ten-thousand range
                        word = ConvertWholeNumber(Number.Substring(0, 2)) + " Thousand " + ConvertWholeNumber(Number.Substring(2));
                        break;
                    case 6:                 //hundred thousand
                        word = units[Int32.Parse(Number[0].ToString())] + " Hundred Thousand " + ConvertWholeNumber(Number.Substring(1));
                        break;
                    case 7:                 //millions   
                        word = units[Int32.Parse(Number[0].ToString())] + " Million " + ConvertWholeNumber(Number.Substring(1));
                        break;
                    case 8:                 //ten-millions
                        word = ConvertWholeNumber(Number.Substring(0, 2)) + " Million " + ConvertWholeNumber(Number.Substring(2));
                        break;
                    case 9:                 //hundred-million
                        word = units[Int32.Parse(Number[0].ToString())] + " Hundred Million " + ConvertWholeNumber(Number.Substring(1));
                        break;
                    case 10:                 //Billion's range    
                        word = units[Int32.Parse(Number[0].ToString())] + " Billion " + ConvertWholeNumber(Number.Substring(1));
                        break;
                    case 11:                 //Ten-Billion
                        word = ConvertWholeNumber(Number.Substring(0, 2)) + " Billion " + ConvertWholeNumber(Number.Substring(2));
                        break;
                    case 12:                //hundred-billion
                        word = units[Int32.Parse(Number[0].ToString())] + " Hundred Billion " + ConvertWholeNumber(Number.Substring(1));
                        break;
                    case 13:                 //Trillion 
                        word = units[Int32.Parse(Number[0].ToString())] + " Trillion " + ConvertWholeNumber(Number.Substring(1));
                        break;
                    case 14:                 //Ten-Triillion
                        word = ConvertWholeNumber(Number.Substring(0, 2)) + " Trillion " + ConvertWholeNumber(Number.Substring(2));
                        break;
                    case 15:                //hundred-Trillion
                        word = units[Int32.Parse(Number[0].ToString())] + " Hundred Trillion " + ConvertWholeNumber(Number.Substring(1));
                        break;
                    default:
                        word = "";
                        break;
                } 
            }
            return word.Trim();
        }

        protected override void button_clicked(object sender, EventArgs e)  //if any button except AC is pressed
        {
            Button button = (Button)sender;
            something_clicked_pressed(button.Text, SpecialOprList);
            if (tab_no == 3)
                NumberToWords(sender, e);
        }

        private void AdvancedPlus_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberToWords(sender, e);
        }

        private void outputPanel_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            NumberToWords(sender, e);
        }

        private void AdvancedPlus_FormClosing(object sender, FormClosingEventArgs e)  //application closed via advplus tab
        {
            if (!exitCheck)
                Application.Exit();
        }
        
    }
}
