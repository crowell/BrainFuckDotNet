using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;

namespace BrainFuckDotNet
{
    class BrainFuck
    {
        static void CompileCSharp(string code, string output)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
            ICodeCompiler compiler = provider.CreateCompiler();
            CompilerParameters parameters = new CompilerParameters();
            parameters.OutputAssembly = output;
            parameters.GenerateExecutable = true;
            CompilerResults results = compiler.CompileAssemblyFromSource(parameters, code);
            if (results.Output.Count == 0)
            {
                Console.WriteLine("success!");
            }
            else
            {
                CompilerErrorCollection CErros = results.Errors;
                foreach (CompilerError err in CErros)
                {
                    string msg = string.Format("Erro:{0} on line{1} file name:{2}", err.Line, err.ErrorText, err.FileName);
                    Console.WriteLine(msg);
                }
            }
        }
        static void Main(string[] args)
        {
            string input = null, output = null;
            if (args.Length != 1 && args.Length != 3)
            {
                foreach (string s in args)
                {
                    Console.WriteLine("\t{0}", s);
                }
                Console.WriteLine("usage: bfc source.bf [-o bin.exe]");
                return;
            }
            else if (args.Length == 1)
            {
                input = args[0];
                output = "a.exe";
            }
            else if (args.Length == 3)
            {
                if (args[0] == "-o")
                {
                    input = args[2];
                    output = args[1];
                }
                else if (args[1] == "-o")
                {
                    input = args[0];
                    output = args[2];
                }
                else
                {
                    Console.WriteLine("usage: bfc source.bf [-o bin.exe]");
                    return;
                }
            }
            string fuckString = System.IO.File.ReadAllText(input);
            string parsed = Parser.Parse(fuckString);
            string Csharp = BrainFuckToCs.SharpFuck(parsed);
            CompileCSharp(Csharp, output);
        }
    }
}
