using System;
using System.Collections.Generic;
using System.Text;

namespace Rhymer
{
    public static class WordList
    {
        public static List<String> EnglishWords = new List<string>()
        {
            "Fame",
            "Section",
            "Dream"
        };

        public static List<String> PolishWords = new List<string>()
        {
            "Sława",
            "Sekcja",
            "Marzenie"
        };

        public static bool IsRhyme(this string text, string textToRhyme)
        {
            if(text.Equals(textToRhyme))
            {
                return false;
            }
            
            if(text.EndsWith(textToRhyme.Substring(textToRhyme.Length -4)))
            {
                return true;
            }
            else if (text.EndsWith(textToRhyme.Substring(textToRhyme.Length - 3)))
            {
                return true;
            }
            else if (text.EndsWith(textToRhyme.Substring(textToRhyme.Length - 2)))
            {
                return true;
            }

            return false;
        }

        public static string GetDifferentRandomWord(this string text, Language lang)
        {
            string rolledText;

            do
            {
                rolledText = GenerateRandomWord(lang);
            }
            while (text.Equals(rolledText));

            return rolledText;
        }

        private static string GenerateRandomWord(Language lang)
        {
            Random random = new Random();

            switch(lang)
            {
                case Language.English:
                    return EnglishWords[random.Next(0, EnglishWords.Count)];
                case Language.Polish:
                    return PolishWords[random.Next(0, EnglishWords.Count)];
                default:
                    return string.Empty;
            }
        }
    }

    public enum Language
    {
        English,
        Polish
    }
}
