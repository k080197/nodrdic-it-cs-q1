using System;
using System.Collections.Generic;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "()"; // True
            var s2 = "[]()"; // True
            var s3 = "[[]()]"; // True
            var s4 = "([([])])()[]"; // True
            var s5 = "("; // False
            var s6 = "[][)"; // False
            var s7 = "[(])"; // False
            var s8 = "(()[]]"; // False


            Console.WriteLine(IsValid(s2));            Console.ReadKey();
        }

        static bool IsValid(string brackets)
        {
            if (brackets.Length % 2 > 0)
            {
                return false;
            }

            Dictionary<char, char> bracketsDictionary = new Dictionary<char, char>(5);            bracketsDictionary.Add('(', ')');            bracketsDictionary.Add('[', ']');            bracketsDictionary.Add('{', '}');            bracketsDictionary.Add('<', '>');

            var bracketsStackAsc = new Stack<char>();
            var bracketsStackDesc = new Stack<char>();

            for (int i = 0; i < brackets.Length; i++)
            {
                bracketsStackAsc.Push(brackets[i]);
            }
            while (true)
            {
                if (bracketsStackAsc.Count == 0)
                {
                    return true;
                }



                var list = new List<char>();
                var num = bracketsStackAsc.Count;
                for (var k = 0; k < num; k++) //опять пытаетесь забрать элементы из пустого стека
                {
                    list.Add(bracketsStackAsc.Pop());
                    Console.Write(list[k]);
                }
                Console.WriteLine();
                for (var k = 0; k < list.Count; k++) //опять пытаетесь забрать элементы из пустого стека
                {
                    bracketsStackAsc.Push(list[k]);
                }



                for (var i = 0; i < bracketsStackAsc.Count; i++)
                {
                    var bracket = bracketsStackAsc.Pop();

                    if (bracketsDictionary.ContainsValue(bracket))
                    {
                        bracketsStackDesc.Push(bracket);
                        continue;
                    }
                    else if (bracketsDictionary.ContainsKey(bracket))
                    {
                        if (bracketsStackDesc.Count > 0)
                        {
                            bracketsStackDesc.Pop();

                            while (bracketsStackDesc.Count > 0)
                            {
                                bracketsStackAsc.Push(bracketsStackDesc.Pop());
                            }

                            break;
                        }
                    }
                }
            }



        }
    }
}
