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
            // Check if an invalid key for input was pressed
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }

            // Now we can handle valid inputs
            if ( !(e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete) ) // Check if key is not backspace or delete
            {
                string[] inputArray = textBox3.Text.Split(' ');
                // Check the last bit of text we put in is 2 characters long
                if (inputArray.ToList<string>().Last().Length == 2 && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Enter)
                {
                    // Add a space and the typed character to the end then set the cursor to the end of the text
                    textBox3.Text += " " + e.KeyChar;
                    textBox3.SelectionStart = textBox3.Text.Length;
                    e.Handled = true;
                }

                // Ah the curse of the broken code. Fix this if you want I can't be bothered fixing it myself
                //
                // // Now we can check that every set of coords is a valid length
                // for (int i = 0; i < inputArray.Length; i++)
                // {
                //     if (inputArray[i].Length > 2) inputArray[i] = inputArray[i].Substring(0, 2); // Cut down coord pair to 2 characters if greater than 2 chars
                // }
                // 
                // // If we had to modify the input to make it valid, then change the input in the textbox
                // if (inputArray != textBox3.Text.Split(' '))
                // {
                //     string output = inputArray[0];
                //     for (int i = 1; i < inputArray.Length; i++)
                //     {
                //         output += " " + inputArray[i];
                //     }
                // 
                //     textBox3.Text = output;
                //     textBox3.SelectionStart = textBox3.Text.Length;
                // }
            }
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
                        Console.WriteLine("c: {0} Length: {1}", c, c.Length);
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
