using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 * Viktor Hansson 920911-2995
 * 
 * Uppgift 1
 * 16/04/22
 */

/* Description
 * När ett tal trycks, sparas det i en sträng
 * När sedan en matematisk operation trycks, så sparas strängen i en lista
 * Och när '=' knappen trycks, tas den nuvarande strängen och läggs till i listan
 * 
 * Exempel:
 * 
 * 2 * 4 =>
 * knappen 2 trycks, "2" sparas i strängen temp.
 * knappen * trycks, temp läggs till i listan, efter den läggs "*" till
 * knappen 4 trycks, "4" sparas i strängen temp
 * knappen = trycks, temp läggs till i listan
 * 
 * sedan körs calculator.Quick_maffs(), medans det finns matematiska operationer i listan
 * 
 * Quick_maffs(), gör lite snabb matte på en lista med strängar.
 *
 *
 * Känd bugg:
 * om det är en matematisk operation i slutet när man trycker =   -> crash
 *      lösning, if(om sista strängen inte är tal) 
 */




namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public List<string> listan = new List<string>();
        string temp = "";  // temp string som sparar tal(en) tills man trycket + - / *

        public Form1()
        {
            InitializeComponent();                                 
        }

        private void button0_Click(object sender, EventArgs e)
        {
            info_box.Text += "0";
            temp += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            info_box.Text += "1";
            temp += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            info_box.Text += "2";
            temp += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            info_box.Text += "3";
            temp += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            info_box.Text += "4";
            temp += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            info_box.Text += "5";
            temp += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            info_box.Text += "6";
            temp += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            info_box.Text += "7";
            temp += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            info_box.Text += "8";
            temp += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            info_box.Text += "9";
            temp += "9";
        }

        private void button_gånger_Click(object sender, EventArgs e)
        {    
            if (listan.Count == 0 && temp == "" || info_box.Text == "-")
            {
                info_box.Text = "ERROR";
                info_box.Enabled = false;
                button_lika_med.Font = new Font(button_lika_med.Font.FontFamily, 10);
                button_lika_med.Text = "Igen?";
            }
            else if (listan.Count != 0 && !Char.IsDigit(listan[listan.Count -1][0]) && temp == "")
            {
                info_box.Text = "ERROR";
                info_box.Enabled = false;
                button_lika_med.Font = new Font(button_lika_med.Font.FontFamily, 10);
                button_lika_med.Text = "Igen?";
            }
            else
            {
                info_box.Text += "*";
                listan.Add(temp);
                temp = "";
                listan.Add("*");
            }
        }

            
        private void button_dela_Click(object sender, EventArgs e)
        {
            if (listan.Count == 0 && temp == "" || info_box.Text == "-")
            {
                button_lika_med.Font = new Font(button_lika_med.Font.FontFamily, 10);
                info_box.Enabled = false;
                info_box.Text = "ERROR";
                button_lika_med.Text = "Igen?";
            }
            else if (listan.Count != 0 && !Char.IsDigit(listan[listan.Count - 1][0]) && temp == "")
            {
                info_box.Text = "ERROR";
                info_box.Enabled = false;
                button_lika_med.Font = new Font(button_lika_med.Font.FontFamily, 10);
                button_lika_med.Text = "Igen?";
            }
            else
            {
                info_box.Text += "/";
                listan.Add(temp);
                temp = "";
                listan.Add("/");
            }
        }

        private void button_plus_Click(object sender, EventArgs e)
        {
            if (listan.Count == 0 && temp == "" || info_box.Text == "-")
            {
                button_lika_med.Font = new Font(button_lika_med.Font.FontFamily, 10);
                info_box.Enabled = false;
                info_box.Text = "ERROR";
                button_lika_med.Text = "Igen?";
            }
            else if ( listan.Count != 0 && !Char.IsDigit(listan[listan.Count - 1][0]) && temp == "" )
            {
                info_box.Enabled = false;
                info_box.Text = "ERROR";
                button_lika_med.Font = new Font(button_lika_med.Font.FontFamily, 10);
                button_lika_med.Text = "Igen?";
            }
            else
            {
                info_box.Text += "+";
                listan.Add(temp);
                temp = "";
                listan.Add("+");
            }
        }

        private void button_minus_Click(object sender, EventArgs e)
        {
            if (info_box.Text == "-")
            {
                button_lika_med.Font = new Font(button_lika_med.Font.FontFamily, 10);
                button_lika_med.Text = "Igen?";
                info_box.Text = "ERROR";
                info_box.Enabled = false;
            }
            else if (listan.Count == 0 && temp == "")
            {
                info_box.Text += "-";
                listan.Add("-");
            }
            else if (listan.Count != 0 && !Char.IsDigit(listan[listan.Count - 1][0]) && temp == "")
            {
                button_lika_med.Font = new Font(button_lika_med.Font.FontFamily, 10);
                button_lika_med.Text = "Igen?";
                info_box.Text = "ERROR";
                info_box.Enabled = false;
            }
            else
            {
                info_box.Text += "-";
                listan.Add(temp);
                temp = "";
                listan.Add("-");
            }
        }

        private void button_lika_med_Click(object sender, EventArgs e)
        {
            if (button_lika_med.Text == "Igen?" || listan.Count == 0 ) // om det har varit ett error, eller om lika med trycks utan ngt annat
            {
                info_box.Enabled = true;
                info_box.Clear();
                temp = "";
                listan.RemoveRange(0, listan.Count);
                button_lika_med.Font = new Font(button_lika_med.Font.FontFamily, 40);
                button_lika_med.Text = "=";
            }
            else
            {
                Calculator miniräknare = new Calculator();
                if (temp != "") { listan.Add(temp); }

                // om första strängen är minus, och nästa är ett tal
                if (listan.Count != 1 && listan[0] == "-" && Char.IsDigit(listan[1][0]) && temp != "")  // detta för att "-2+5" tex, ska fungera
                {
                    listan[0] += listan[1]; // från "-", "2" , "...    till "-2", "...
                    listan.RemoveAt(1);   
                }
                else
                {
                    if (listan[0] == "-" && listan.Count == 1) // om man tryker - =         de andra matematiska operationerna har redan en liknande i deras knappar
                    {                                                                      // men eftersom att man ska kunna skriva - först, så blev det såhär
                        info_box.Text = "ERROR";                                           // dvs, - som första input är godkänt, + * / är inte.
                        temp = "";
                        listan.RemoveRange(0, listan.Count);
                        button_lika_med.Font = new Font(button_lika_med.Font.FontFamily, 10);
                        button_lika_med.Text = "Igen?";
                    }
                    else
                    {
                        
                        if (!Char.IsDigit(listan[listan.Count-1][0]))     // kollar så att den sista tryckta knappen inte var en matematisk operation
                        {
                            info_box.Text = "ERROR";                                           
                            temp = "";
                            listan.RemoveRange(0, listan.Count);
                            button_lika_med.Font = new Font(button_lika_med.Font.FontFamily, 10);
                            button_lika_med.Text = "Igen?";
                        }
                        else
                        {
                            try
                            {
                                while (listan.Contains("*")) { miniräknare.Quick_maffs("*", listan); }
                                while (listan.Contains("/")) { miniräknare.Quick_maffs("/", listan); }
                                while (listan.Contains("-")) { miniräknare.Quick_maffs("-", listan); }
                                while (listan.Contains("+")) { miniräknare.Quick_maffs("+", listan); }
                                info_box.Text = listan[0];
                                info_box.Enabled = false;
                                button_lika_med.Font = new Font(button_lika_med.Font.FontFamily, 10);
                                button_lika_med.Text = "Igen?";
                                temp = "";
                            }
                            catch (Exception)
                            {
                                info_box.Text = "ERROR";
                                listan.RemoveRange(0, listan.Count);
                                button_lika_med.Font = new Font(button_lika_med.Font.FontFamily, 10);
                                button_lika_med.Text = "Igen?";
                                throw;
                            }
                        }
                    }
                }
            }
        }

        private void taBort_knapp_Click(object sender, EventArgs e)
        {
            if (info_box.Text.Length > 1)
            {
                info_box.Text = info_box.Text.Substring(0, info_box.Text.Length - 1);
                if (temp.Length <= 1 ) { temp = ""; }
                else { temp = temp.Substring(0, temp.Length - 1); }
            }
            else if (info_box.Text.Length == 1)
            {
                info_box.Text = "";
                temp = "";
                listan.RemoveRange(0, listan.Count);
            }
        }

        private void avsluta_knapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



