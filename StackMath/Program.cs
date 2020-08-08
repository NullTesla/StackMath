using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackMath.Instructions;
using System.Diagnostics;

namespace StackMath
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Stack<double> stack = new Stack<double>();
                    Analyzer p = new Analyzer();
                    Console.Write("Введите выражение: ");
                    string s = Console.ReadLine();
                    Stopwatch sw = new Stopwatch();
                    List<Instruction> inst = p.Analyze(s);
                    sw.Start();
                    inst.ForEach(x => x.Execute(stack));
                    sw.Stop();
                    if (stack.Count > 1)
                        throw new Exception();
                    Console.WriteLine("Результат: {0}", stack.Pop());
                    Console.WriteLine("Время выполнения: {0} ms.", sw.ElapsedMilliseconds);
                    Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("\nНекорректное выражение!\n");
                }
            }
        }
    }
}
