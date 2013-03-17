using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFuckDotNet
{
    static class Parser
    {
        public static string Parse(string fuckstr)
        {
            Dictionary<char, bool> AllowedChars = new Dictionary<char, bool>();
            AllowedChars.Add('>', true); //increment the data pointer (to point to the next cell to the right).
            AllowedChars.Add('<', true); //decrement the data pointer (to point to the next cell to the left).
            AllowedChars.Add('+', true); //increment (increase by one) the byte at the data pointer.
            AllowedChars.Add('-', true); //decrement (decrease by one) the byte at the data pointer.
            AllowedChars.Add('.', true); //output the byte at the data pointer.
            AllowedChars.Add(',', true); //accept one byte of input, storing its value in the byte at the data pointer.
            AllowedChars.Add('[', true); //if the byte at the data pointer is zero, then instead of moving the instruction pointer forward to the next command, jump it forward to the command after the matching ] command.
            AllowedChars.Add(']', true); //if the byte at the data pointer is nonzero, then instead of moving the instruction pointer forward to the next command, jump it back to the command after the matching [ command.
            //if a char isn't in "allowedchars" we just assume it is part of a comment, as per esolang standards :P
            StringBuilder sb = new StringBuilder();
            foreach (char ch in fuckstr)
            {
                if(AllowedChars.ContainsKey(ch))
                {
                    sb.Append(ch);
                }
            }
            return sb.ToString();
        }
    }
}
