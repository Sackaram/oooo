using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/* Viktor Hansson
 * Uppgift 2 DVGB07, vt22
 * 18/04/22
*/


namespace WinFormsApp4
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int AntalRätt(List<int> a, List<int> b)
        {
            int rätt = 0;
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 0; j < a.Count; j++)
                {
                    if (a[i] == b[j])
                    {
                        rätt++;
                    }}}
            return rätt;
        }

        public void Lotto(List<int> lottoRader, List<int> minaGissningar)
        {
            var rand = new Random();

            int fem_rätt = 0;
            int sex_rätt = 0;
            int sju_rätt = 0;

            for (int i = 0; i < Int32.Parse(dragningar_box.Text); i++) // för varje dragning
            {

                for (int j = 0; j < 7; j++)
                {
                    int k = rand.Next(1, 36);
                    while (lottoRader.Contains(k)) { k = rand.Next(1, 36); } // ser till att det inte genereras dubbletter
                    lottoRader.Add(k);
                }
                if (AntalRätt(minaGissningar, lottoRader) == 7)
                {
                    sju_rätt++;
                }
                else if (AntalRätt(minaGissningar, lottoRader) == 6)
                {
                    sex_rätt++;
                }
                else if (AntalRätt(minaGissningar, lottoRader) == 5)
                {
                    fem_rätt++;
                }
                lottoRader.Clear();
            }
            richTextBox_7rätt.Text = sju_rätt.ToString();
            richTextBox_6rätt.Text = sex_rätt.ToString();
            richTextBox_5rätt.Text = fem_rätt.ToString();
        }


        public bool FelInput()
        {
            bool fel = false;
            List<RichTextBox> textboxar = new List<RichTextBox>();

            textboxar.Add(gissning1);
            textboxar.Add(gissning2);
            textboxar.Add(gissning3);
            textboxar.Add(gissning4);
            textboxar.Add(gissning5);
            textboxar.Add(gissning6);
            textboxar.Add(gissning7);

            for (int i = 0; i < textboxar.Count; i++) // kollar så att det finns input i alla sju boxar
            {
                if (textboxar[i].Text == "")
                {
                    fel = true;
                    break;
                }
            }

            for (int i = 0; i < textboxar.Count && fel == false; i++)  
            {
                for (int j = 0; j < textboxar[i].Text.Length; j++) // kollar så att det faktiskt är tal, och inte någon annan char
                {
                    if (!char.IsDigit(textboxar[i].Text[j]) && textboxar[i].Text[j] != ' ')
                    {
                        fel = true;
                        break;
                    }
                }
                if (fel == false)
                {
                    if (Int32.Parse(textboxar[i].Text) < 0 || Int32.Parse(textboxar[i].Text) > 35) // kolla så att talen är mellan godkända gränsen
                    {
                        fel = true;
                        break;
                    }
                }  
            }


            // kollar efter dubbletter, kanske lättare med iterator men..
            for (int i = 0; i < textboxar.Count && fel == false; i++)
            {
                for (int j = 0; j < textboxar.Count; j++)
                {
                    if (textboxar[j].Text == textboxar[i].Text && j != i)
                    {
                        fel = true;
                        break;
                    }
                }
            }


            for (int i = 0; i < dragningar_box.Text.Length; i++) // kollar input i antal dragningar
            {
                if (!char.IsDigit(dragningar_box.Text[i]) || Int32.Parse(dragningar_box.Text) < 0)
                {
                    fel = true;
                    break;
                }
            }
            return fel;
        }
        private void StartaLottoKnapp_Click(object sender, EventArgs e)
        {
            
            List<int> lottoRader = new List<int>();
            List<int> minaGissningar = new List<int>();

            if (!FelInput())
            {
                minaGissningar.Add(Int32.Parse(gissning1.Text));
                minaGissningar.Add(Int32.Parse(gissning2.Text));
                minaGissningar.Add(Int32.Parse(gissning3.Text));
                minaGissningar.Add(Int32.Parse(gissning4.Text));
                minaGissningar.Add(Int32.Parse(gissning5.Text));
                minaGissningar.Add(Int32.Parse(gissning6.Text));
                minaGissningar.Add(Int32.Parse(gissning7.Text));

                Lotto(lottoRader, minaGissningar);
            }
            else
            {
                dragningar_box.Text = "Bad input, prova igen";
            }
        }

        private void AvslutaKnapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



