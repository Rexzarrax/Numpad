using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numpadcipher
{
    public class Convertholder
    {
        string[,] ConvArr = new string[,]{
                { "0"," ","@","$","_" },
                { "1","/",".",",","?" },
                { "2","a","b","c","!" },
                { "3","d","e","f","_" },
                { "4","g","h","i","_" },
                { "5","j","k","l","_" },
                { "6","m","n","o","_" },
                { "7","p","q","r","s" },
                { "8","t","u","v","_" },
                { "9","w","x","y","z" },
                };
        public Convertholder()
        {     
        }

        public string Encode(char s)
        {
            string x;
            try
            {
                for (int i = 0; i < ConvArr.Length; i++)
                {
                    for (int ii = 0; ii <= 4; ii++)
                    {
                        if (s == Char.Parse(ConvArr[i, ii]))
                        {
                            return (i).ToString() + (ii).ToString() + " ";
                        }

                    }
                }
                return "cannot convert:" + s;

            }
            catch(Exception ex)
            {
               x = "(Major Fail finding:" + s+")";
            }
            return x;
        }
        public string Decode(int x, int y)
        {
            try
            {
                return ConvArr[x, y];
            }
            catch
            {
                return "invalid 2d co-ords:"+x+","+y;
            }
        }
    }
}
