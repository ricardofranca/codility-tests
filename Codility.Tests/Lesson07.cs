using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codility.Tests
{
    [TestFixture]
    public class Lesson07
    {
        [Test]
        [TestCase("{[()()]}", ExpectedResult = 1)]
        [TestCase("([)()]", ExpectedResult = 0)]
        [TestCase("{[()({[()()]})]}", ExpectedResult = 1)]
        [TestCase("{[()({[()()]})]", ExpectedResult = 0)]
        [TestCase("[()({[()()]})]", ExpectedResult = 1)]
        [TestCase("[()({[()()]})][()({[()([()({[()()]})])]})]", ExpectedResult = 1)]
        public int Item_07_01(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 1;

            var stack = new Stack<char>();
            var openingChar = new[] { '{', '[', '(' };

            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];


                if (openingChar.Contains(currentChar))
                {
                    stack.Push(currentChar);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return 0;
                    }

                    var latestCharOpening = stack.Pop();

                    if ((currentChar == ']' && latestCharOpening == '[') ||
                      (currentChar == '}' && latestCharOpening == '{') ||
                      (currentChar == ')' && latestCharOpening == '(')
                        )
                    {
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            if (stack.Count != 0)
                return 0;

            return 1;
        }


        [Test]
        [TestCase("(()(())())", ExpectedResult = 1)]
        [TestCase("())", ExpectedResult = 0)]
        public int Item_07_03(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 1;

            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];


                if (currentChar == '(')
                {
                    stack.Push(currentChar);
                }
                else
                {
                    if (stack.Count == 0)
                        return 0;

                    var latestChar = stack.Pop();
                }
            }

            if (stack.Count != 0)
                return 0;

            return 1;
        }
    }
}
