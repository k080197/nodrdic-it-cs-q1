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


            Console.WriteLine(CheckForParentheses(s1));
            Console.WriteLine(CheckForParentheses(s2));
            Console.WriteLine(CheckForParentheses(s3));
            Console.WriteLine(CheckForParentheses(s4));
            Console.WriteLine(CheckForParentheses(s5));
            Console.WriteLine(CheckForParentheses(s6));
            Console.WriteLine(CheckForParentheses(s7));
            Console.WriteLine(CheckForParentheses(s8));

            Console.ReadKey();
        }

        static bool CheckForParentheses(string brackets)
        {
            if (brackets.Length % 2 > 0)
            {
                return false;
            }

            Dictionary<char, char> bracketsDictionary = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' },
                { '<', '>' }
            };

            var bracketsStackAsc = new Stack<char>();
            var bracketsStackDesc = new Stack<char>();

            for (int i = brackets.Length - 1; i >= 0; i--)
            {
                bracketsStackAsc.Push(brackets[i]);
            }

            while (true)
            {
                if (bracketsStackAsc.Count == 0)
                {
                    return true;
                }

                var stop = false;

                for (var i = 0; i < bracketsStackAsc.Count; i++)
                {
                    var openingBracket = bracketsStackAsc.Pop();

                    if (bracketsDictionary.ContainsKey(openingBracket))
                    {
                        bracketsStackDesc.Push(openingBracket);
                    }
                    else 
                    {
                        var closingBracket = bracketsStackDesc.Pop();

                        foreach (KeyValuePair<char, char> keyValue in bracketsDictionary)
                        {
                            if (keyValue.Key == closingBracket && keyValue.Value == openingBracket)
                            {
                                stop = false;
                                break;
                            }
                            stop = true;
                        }

                        if (stop)
                        {
                            return false;
                        }
                    }
                }
            }



        }
    }
}
