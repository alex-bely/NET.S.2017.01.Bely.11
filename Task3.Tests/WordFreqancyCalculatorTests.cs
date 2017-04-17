using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Task3.WordFrequancyCalculator;

namespace Task3.Tests
{
    [TestFixture]
    public class WordFreqancyCalculatorTests
    {
        [TestCase("European","temp.txt",ExpectedResult = 1)]
        [TestCase("used", "temp.txt", ExpectedResult = 2)]
        [TestCase("only", "temp.txt", ExpectedResult = 3)]
        [TestCase("format", "temp.txt", ExpectedResult = 5)]
        [TestCase("the", "temp.txt", ExpectedResult = 25)]
        public int GetOneWord(string word, string filePath)
        {
            return GetFrequancy(word, filePath);
        }

        [TestCase("European", "temp.txt", ExpectedResult = 1)]
        [TestCase("used", "temp.txt", ExpectedResult = 2)]
        [TestCase("only", "temp.txt", ExpectedResult = 3)]
        [TestCase("format", "temp.txt", ExpectedResult = 5)]
        [TestCase("the", "temp.txt", ExpectedResult = 25)]
        public int GetAllWords(string word, string filePath)
        {
            var temp = GetFrequancyOfAllWords(filePath);
            int number;
            temp.TryGetValue(word.ToUpperInvariant(),out number);
            return number;
        }


    }
}
