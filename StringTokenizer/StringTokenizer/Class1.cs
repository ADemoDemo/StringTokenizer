using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StringTokenizer
{
    public class Tokenizer
    {
        private ArrayList Stream;
        private int CurrentToken;
        private int next;
        private bool isInitiated = false;
        
        /// <summary>
        /// Constructor Tokenizer(string s, string t), s is the 
        /// string to be parsed, t is the string containing the
        /// delimiters
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        public Tokenizer(string s, string t)
        {
            
            Stream = getStream(s, t);
        }

        private ArrayList getStream(string s, string t)
        {
            // "input" parameters, the string to split and its delimiters
            // can be modified to work with string delimiters instead

            Char[] arrDelimiters;

            if (t == null)
            {
                arrDelimiters = "+-/*;()=".ToCharArray();    //The default delimiters

            }
            else
                arrDelimiters= t.ToCharArray();
           
            // Start of tokenizing
            // Create a work array where the finished result also will be
            ArrayList Stream = new ArrayList();
            Stream.Add(s);
            // Temporary variables
            Object[] arrSplitted;
            Char[] arrChar = new Char[1];
            ArrayList alTemp = new ArrayList();
            // Process each delimiter
            foreach (Char c in arrDelimiters)
            {
                // Clear temp vars
                arrChar[0] = c;
                alTemp.Clear();
                // Process each string
                foreach (String strWork in Stream)
                {
                    // Split it by delimiter
                    arrSplitted = strWork.Split(arrChar, StringSplitOptions.None);
                    if (arrSplitted.Length > 1)
                    {
                        // Split took place, add delimiter between every item 
                        for (int n = 0; n < arrSplitted.Length; n++)
                        {
                            alTemp.Add(arrSplitted[n]);
                            if (n < arrSplitted.Length - 1)
                            {
                                alTemp.Add(c.ToString());
                            }
                        }
                    }
                    else
                    {
                        // No split took place, use original string
                        alTemp.Add(strWork);
                    }
                }
                // Copy temp array to work array

                Stream.Clear();
                Stream.AddRange(alTemp);
                
            }
            int i=0;
            alTemp.Clear();
            foreach( string removestr in Stream)
            {
                if (removestr.Equals(""))
                {
                    alTemp.Add(i);
                }
                i++;
            }

            foreach (int intremove in alTemp)
            {
                Stream.Remove("");
            }

            return Stream;
        }


        /// <summary>
        /// Return an integer, length of the object tokenizer
        /// </summary>
        /// <returns></returns>
        public int Langd()
        {
            int i = Stream.Count;
            return i;
        }

        /// <summary>
        /// Not used
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private int Langd2(ArrayList s)
        {
            return s.Count;
        }

        /// <summary>
        /// Sets the next token in the stream
        /// </summary>
        public void NextToken()
        {
            if (isInitiated == false)
            {
                CurrentToken = 0;
                next = 1;
                isInitiated = true;
            }
            else if (isInitiated == true)
            {
                CurrentToken += 1;
                next += 1;

            }

        }

        /// <summary>
        /// taking away -1
        /// </summary>
        public void PushBack()
        {
            CurrentToken -= 1;
            next -= 1;
        }
        /// <summary>
        /// returns true if the current token is a number
        /// </summary>
        /// <returns></returns>
        public Boolean isNumber()
        {
            double temp;
            String s = (String)Stream[CurrentToken];
            if (double.TryParse(s, out temp))
                return true;
            else
                return false;
        }
        /// <summary>
        /// returns the numerical value of the current token. 
        /// </summary>
        /// <returns></returns>
        public double GetNumber()
        {
            String s = (String)Stream[CurrentToken];
            return double.Parse(s);
        }

        public Boolean isPlus()
        {
            String s = (String)Stream[CurrentToken];
            if (s.Equals("+"))
                return true;
            else
                return false;
        }

        public Boolean isMinus()
        {
            String s = (String)Stream[CurrentToken];
            if (s.Equals("-"))
                return true;
            else
                return false;
        }

        public Boolean isMult()
        {
            String s = (String)Stream[CurrentToken];
            if (s.Equals("*"))
                return true;
            else
                return false;
        }

        public Boolean isDiv()
        {
            String s = (String)Stream[CurrentToken];
            if (s.Equals("/"))
                return true;
            else
                return false;
        }
        /// <summary>
        /// returns the current string in the stream
        /// </summary>
        /// <returns></returns>
        public String getString()
        {
            String s = (String)Stream[CurrentToken];
            return s;
        }

    
      }
  }

