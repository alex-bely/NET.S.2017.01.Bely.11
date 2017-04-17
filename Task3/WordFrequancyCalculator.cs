using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /// <summary>
    /// Provides methods for calculating word(-s) frequency located in the file
    /// </summary>
    public class WordFrequancyCalculator
    {
        #region Public methods
        /// <summary>
        /// Calculate frequency of one word
        /// </summary>
        /// <param name="word">Key of searching and calculating</param>
        /// <param name="filePath">Path to the file</param>
        /// <returns>Integer value of the word frequency</returns>
        /// <exception cref="ArgumentNullException">One of argument is null referenced</exception>
        /// <exception cref="ArgumentException">One of argument or file is blank</exception>
        public static int GetFrequancy(string word, string filePath)
        {
            if (ReferenceEquals(word, null) || ReferenceEquals(filePath,null))
                throw new ArgumentNullException("Null referenced argument");
            if (word.Length == 0 || filePath.Length == 0) throw new ArgumentException("Blank argument");

            int count = 0;
            char[] separators = { '.', ',', ';', '-', ' ', '(', ')', '?', '!', '\r', '\n', '\t' };
            string[] words = File.ReadAllText(filePath, Encoding.Default).ToUpperInvariant().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 0)
                throw new ArgumentException("Empty file");

            foreach (var temp in words)
                if (temp == word.ToUpperInvariant())
                    count++;

            return count;
        }

        /// <summary>
        /// Calculates frequency of all words located in the file
        /// </summary>
        /// <param name="filePath">Path to the file</param>
        /// <returns>Dictionary of words sorted in ascending order of word frequency</returns>
        /// <exception cref="ArgumentNullException">One of argument is null referenced</exception>
        /// <exception cref="ArgumentException">One of argument or file is blank</exception>
        public static Dictionary<string, int>GetFrequancyOfAllWords(string filePath)
        {
            if (ReferenceEquals(filePath, null))
                throw new ArgumentNullException("Null referenced argument");
            if (filePath.Length == 0) throw new ArgumentException("Blank argument");

            Dictionary<string, int> frequency = new Dictionary<string, int>();
            char[] separators = { '.', ',', ';', '-', ' ', '(', ')', '?', '!', '\r', '\n', '\t' };
            string[] words=File.ReadAllText(filePath).ToUpperInvariant().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
                throw new ArgumentException("File is empty");

            for (int i = 0; i < words.Length; i++)
            {
                if (frequency.ContainsKey(words[i]))
                    frequency[words[i]]++;
                else
                    frequency.Add(words[i], 1);
            }
            frequency=frequency.OrderBy(item => item.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            return frequency;
            
        }
        #endregion


    }
}
