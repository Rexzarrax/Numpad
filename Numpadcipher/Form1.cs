using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numpadcipher
{
    public partial class Form1 : Form
    {

        String inputString, outputString;
        Convertholder converter = new Convertholder();
        int cyc = 0;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                outputString = ">>";
                inputString = textBox1.Text.ToLower();
                inputString.ToCharArray();
                foreach (char c in inputString)
                {
                    outputString += converter.Encode(c);

                }

                textBox2.AppendText("=>" + inputString + Environment.NewLine);
                textBox2.AppendText(outputString + Environment.NewLine);

                textBox1.Clear();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
            //need to work out how to better format the intergers.
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                int x = 0, y = 0;
                //if(inputString == )
                outputString = ">>";
                inputString = textBox3.Text;
                string[] inputArray = inputString.Split(' ');
                try
                {
                    foreach (string c in inputArray)
                    {
                        if(c.Length == 2)
                        {
                            x = Int32.Parse(c.ToCharArray()[0].ToString());
                            y = Int32.Parse(c.ToCharArray()[1].ToString());
                            outputString += converter.Decode(x, y);
                        }
                        else
                        {
                            outputString += c + " is in the wrong format";
                        }
                    }
                }
                catch
                {
                    outputString += inputString + " failed to decode";
                }
                textBox4.AppendText("=>" + inputString + Environment.NewLine);
                textBox4.AppendText(outputString + Environment.NewLine);
               
                textBox3.Clear();
            }

        }

    }
    //42 81 81 71 74 54 11 11 41 43 81 42 82 22 12 23 63 61 11 73 32 92 94 21 73 73 21 92 11 62 82 61 71 21 31 
}
