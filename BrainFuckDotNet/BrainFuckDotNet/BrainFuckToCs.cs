using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFuckDotNet
{
    static class BrainFuckToCs
    {
        public static byte [] cells = new byte[30000];
        public static string SharpFuck(string parsed)
        {
            //first initialize the cells
            for(int ii = 0; ii < 30000; ii++)
            {
                cells[ii] = 0;
            }
            StringBuilder codeBuilder = new StringBuilder("using System;\n").Append("namespace bfuck\n{ class bfuck\n{");
            codeBuilder.Append("static void Main(string[] args)\n{ byte[] cells = new byte[30000];\n");
            codeBuilder.Append("for(int ii = 0; ii < 30000; ii++){cells[ii] = (byte)0;}\n");
            codeBuilder.AppendLine("int ptr = 0;");
            if(parsed.Contains(','))
            {
                codeBuilder.AppendLine("ConsoleKeyInfo cki;");
            }
            foreach (char ch in parsed)
            {
                switch (ch)
                {
                    case('>'):
                        codeBuilder.AppendLine("ptr = (ptr+1) % 30000;");
                        break;
                    case('<'):
                        codeBuilder.AppendLine("ptr = (ptr-1) % 30000;");
                        break;
                    case('+'):
                        codeBuilder.AppendLine("cells[ptr]++;");
                        break;
                    case ('-'):
                        codeBuilder.AppendLine("cells[ptr]--;");
                        break;
                    case('.'):
                        codeBuilder.AppendLine("System.Console.Write((char)cells[ptr]);");
                        break;
                    case(','):
                        codeBuilder.AppendLine("cki = System.Console.ReadKey();");
                        codeBuilder.AppendLine("cells[ptr] = (byte)cki.KeyChar;");
                        break;
                    case('['):
                        codeBuilder.AppendLine("while(cells[ptr]!=0){");
                        break;
                    case(']'):
                        codeBuilder.AppendLine("}");
                        break;
                }
            }
            codeBuilder.AppendLine("}}}");
            return codeBuilder.ToString();
        }
    }
}
