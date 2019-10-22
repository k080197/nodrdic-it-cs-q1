using System;
using System.Collections.Generic;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var brackets = new string[]
            {
                "()",           // True
                "[]()",         // True
                "[[]()]",       // True
                "([([])])()[]", // True
                "(",            // False
                "[][)",         // False
                "[(])",         // False
                "(()[]]",       // False
            };

            foreach (var text in brackets)
            {
                Console.WriteLine(CheckForParentheses(text));
            }

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

            var bracketsStack = new Stack<char>();

            while (true)
            {
                if (brackets.Length == 0)
                {
                    return true;
                }

                for (var i = 0; i < brackets.Length; i++)
                {
                    if (bracketsDictionary.ContainsKey(brackets[i]))
                    {
                        bracketsStack.Push(brackets[i]);
                    }
                    else if (bracketsDictionary[bracketsStack.Pop()] != brackets[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
