using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace sigma_7_1
{
    class Translator
    {
        private string _text;
        private List<string> _words;
        private Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        public Translator(string filename = "data.txt")
        {
            try
            {
                using(StreamReader sr = new StreamReader(filename))
                {
                    _text = sr.ReadToEnd().ToLower();
                    _words = _text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("File was not found");
                Environment.Exit(-1);
            }
            catch(OutOfMemoryException)
            {
                Console.WriteLine("Text is too large");
                Environment.Exit(-1);
            }

            _dictionary.Add("i", "boy");
            _dictionary.Add("go", "runs");
            _dictionary.Add("to", "to");
            _dictionary.Add("the", "the");
            _dictionary.Add("school", "cinema");

        }

        public string Translate()
        {
            try
            {
                foreach (string word in _words)
                {
                    if(!_dictionary.ContainsKey(word))
                    {
                        Console.WriteLine($"\"{word}\" wasn't found in dictionary.\n" +
                            "Enter the word you want to replace it with:\n");
                        string val = Console.ReadLine();
                        _dictionary.Add(word, val);
                    }
                }
                foreach (var item in _dictionary)
                {
                    _text = _text.Replace(item.Key, item.Value);
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return _text;
        }
    }
}
