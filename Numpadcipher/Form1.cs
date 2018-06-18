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
        public Form1()
        {
            InitializeComponent();
            
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                outputString = "=>";
                inputString = textBox1.Text.ToLower();
                inputString.ToCharArray();
                foreach (char c in inputString)
                {
                    outputString += converter.Encode(c);

                }

                textBox2.AppendText(outputString + Environment.NewLine);

                textBox1.Clear();
            }
        }
        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                //if(sender)
                int x = 0, y = 0;

                outputString = "=>";
                inputString = textBox3.Text;
                inputString.ToCharArray();
                foreach (char c in inputString)
                {
                    if(c.ToString() != " ")
                    {   
                       x = inputString[0];
                       y = inputString[1];
                       outputString += converter.Decode(x, y);
                    }
                }

                textBox4.AppendText(outputString + Environment.NewLine);
               
                textBox3.Clear();
            }

        }

    }
}
