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
                { "3","d","e","f","=" },
                { "4","g","h","i","-" },
                { "5","j","k","l",":" },
                { "6","m","n","o",";" },
                { "7","p","q","r","s" },
                { "8","t","u","v","'" },
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
            catch(Exception Ex)
            {
               x = "(Major Fail finding:<" + s+">)";
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
    //42 81 81 71 74 54 11 11 41 43 81 42 82 22 12 23 63 61 11 73 32 92 94 21 73 73 21 92 11 62 82 61 71 21 31 
}
