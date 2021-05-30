using NUnit.Framework;

namespace Rhymer.UnitTests
{
    [TestFixture]
    public class WordListTest
    {
        [TestCase("213321", Language.Polish)]
        [TestCase("Cake", Language.Polish)]
        [TestCase("Cake00_14", Language.Polish)]
        [TestCase("", Language.Polish)]
        [TestCase("213321", Language.English)]
        [TestCase("Cake", Language.English)]
        [TestCase("Cake00_14", Language.English)]
        [TestCase("", Language.English)]
        [Order(1)]
        public void GetDifferentRandomWord_AnyString_ReturnsDifferentString(string word, Language lang)
        {
            var rolledWord = word.GetDifferentRandomWord(lang);

            Assert.AreNotEqual(word, rolledWord);
        }

        [TestCase("", Language.Polish)]
        [TestCase("", Language.English)]
        [Order(2)]
        public void GetDifferentRandomWord_RolledWord_ReturnsDifferentString(string word, Language lang)
        {
            var firstWord = word.GetDifferentRandomWord(lang);
            var secondWord = firstWord.GetDifferentRandomWord(lang);

            Assert.AreNotEqual(firstWord, secondWord);
        }

        [TestCase("", Language.Polish)]
        [TestCase("", Language.English)]
        [Order(6)]
        public void GetDifferentRandomWord_AfterAddingItemToList_ReturnsDifferentString(string word, Language lang)
        {
            switch(lang)
            {
                case Language.English:
                    WordList.EnglishWords.Add(word);
                    break;
                case Language.Polish:
                    WordList.PolishWords.Add(word);
                    break;
            }

            var rolledWord = word.GetDifferentRandomWord(lang);

            Assert.AreNotEqual(word, rolledWord);
        }

        [TestCase("")]
        [TestCase("000000")]
        [TestCase("A")]
        [TestCase("Bar")]
        [TestCase("///Test123-")]
        [Order(3)]
        public void IsRhyme_TheSameWord_ReturnsFalse(string word)
        {
            var result = word.IsRhyme(word);

            Assert.IsFalse(result);
        }

        [TestCase("", "-")]
        [TestCase("Car", "Airplane")]
        [TestCase("///Test123-", "///Test432-")]
        [Order(4)]
        public void IsRhyme_DifferentWordWithoutRhyme_ReturnsFalse(string firstWord, string secondWord)
        {
            var result = firstWord.IsRhyme(secondWord);

            Assert.IsFalse(result);
        }

        [TestCase("Apple", "Pineapple")]
        [TestCase("Gun", "Sun")]
        [TestCase("Row", "Narrow")]
        [Order(5)]
        public void IsRhyme_Rhyme_ReturnsTrue(string firstWord, string secondWord)
        {
            var result = firstWord.IsRhyme(secondWord);

            Assert.IsTrue(result);
        }
    }
}
