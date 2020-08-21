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

        private static String ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static String tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }

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
            else
                word =  isNegative + ConvertToWords(number);

            wordBox.Text = word;
        }

        private static String ConvertToWords(String number)
        {
            String value = "", points = "", andStr = "", pointStr = "", wholeNo = number;
            {
                int decimalPlace = number.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = number.Substring(0, decimalPlace);
                    points = number.Substring(decimalPlace + 1);
                    if (points != "")
                        if (Convert.ToInt32(points) > 0)
                        {
                            andStr = " Point";// decimal point 
                            pointStr = ConvertDecimals(points);
                        }
                }
                value = ConvertWholeNumber(wholeNo).Trim() + andStr + pointStr;
            }
            return value;
        }

        private static String ConvertDecimals(String number)
        {
            String decimalAfter = "";
            int digit;
            var units = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            for (int i = 0; i < number.Length; i++)
            {
                digit = Int32.Parse(number[i].ToString());
                decimalAfter += " " + units[digit];
            }
            return decimalAfter;
        }

        private static String ConvertWholeNumber(String Number)
        {
            var units = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            var tenss = new[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty", "Thirty", "Forty",
    "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX    
                bool isDone = false;//test if already translated    
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && number.StartsWith("0"))    
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric    
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping   
                    int digit;
                    String place = "";//digit grouping name:hundres,thousand,etc...    
                    switch (numDigits)
                    {
                        case 1://ones' range    
                            //word = ones(Number);
                            digit = Int32.Parse(Number.ToString());
                            word = units[digit];
                            isDone = true;
                            break;
                        case 2://tens' range    
                            digit = Int32.Parse(Number[1].ToString());
                            if (Number[0].Equals("1"))   
                                word = tenss[digit];
                            else
                            {
                                word = tenss[Int32.Parse(Number[0].ToString()) + 8];
                                word += " ";
                                word += units[digit];
                            } 
                            isDone = true;
                            break;
                        case 3://hundreds' range    
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range    
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range    
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range    
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...    
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)    
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }

                        //check for trailing zeros    
                        //if (beginsZero) word = " and " + word.Trim();    
                    }
                    //ignore digit grouping names    
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)  //tab selection drop selection menu
        {
            if (comboBox1.Text == "Basic")
            {
                reinitialize_variables();
                exitCheck = true;
                Calc basic = new Calc();
                basic.Show();
                this.Close();            //hiding the current window
            }
            else if (comboBox1.Text == "Advanced")
            {
                reinitialize_variables();
                exitCheck = true;
                Advanced adv = new Advanced();
                this.Close();          //hiding the current window
            }
        }

        private void AdvancedPlus_Load(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is Button)
                      c.Click += new System.EventHandler(NumberToWords);
                    
            }
        }

        private void AdvancedPlus_FormClosing(object sender, FormClosingEventArgs e)  //application closed via advplus tab
        {
            if (!exitCheck)
                Application.Exit();
        }
    }
}
