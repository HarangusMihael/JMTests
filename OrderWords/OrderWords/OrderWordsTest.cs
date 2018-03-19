using System;
using Xunit;

namespace OrderWords
{
    public class OrderWordsTest
    {
        [Fact]
        public void Test1()
        {
            var expected = new WordCount[] { new WordCount("Text", 1)};
            var input = "Text";
            Assert.Equal(expected, WordsTop(input));
        }
        [Fact]
        public void Test2()
        {
            var expected = new WordCount[] { new WordCount("Text", 1), new WordCount("two", 1) };
            var input = "Text two";
            Assert.Equal(expected, WordsTop(input));
        }

        [Fact]
        public void Test3()
        {
            var expected = new WordCount[] { new WordCount("Text", 1), new WordCount("two", 2), new WordCount("three", 3) };
            var input = "Text two two three three three";
            Assert.Equal(expected, WordsTop(input));
        }

        [Fact]
        public void Test()
        {
            Assert.Equal(new WordCount[] {
                new WordCount("a", 1),
                new WordCount("b", 2),
                new WordCount("c", 3) }, WordsTop("a b b c c c"));
        }

        [Fact]
        public void DistinctWordsTest()
        {
            var expected = new WordCount[] {
                new WordCount("a", 1),
                new WordCount("b", 2),
                new WordCount("c", 3)
            };
            var actual = CountWords("a b c b c c".Split(new char[] { ' ' }));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ContainsWord_ShouldReturnFalseWhenNotContaining()
        {
            var words = new WordCount[] {
                new WordCount("b", 2),
                new WordCount("c", 3)
            };
            Assert.Equal(-1, ContainsWord(words, "a"));
        }

        [Fact]
        public void ContainsWord_ShouldReturnTrueWhenContaining()
        {
            var words = new WordCount[] {
                new WordCount("b", 2),
                new WordCount("a", 3)
            };
            Assert.Equal(1, ContainsWord(words, "a"));
        }

        [Fact]
        public void ContainsWord_ShouldReturnTrueWhenCasingIsDiffrent()
        {
            var words = new WordCount[] {
                new WordCount("b", 2),
                new WordCount("A", 3)
            };
            Assert.Equal(1, ContainsWord(words, "a"));
        }

        private int ContainsWord(WordCount[] words, string wordToFind)
        {
            for (int i = 0; i < words.Length; i++)
                if (string.Compare(words[i].Word, wordToFind, true) == 0)
                    return i;

            return -1;
        }

        private WordCount[] WordsTop(string v)
        {
            return SelectionSort(CountWords(v.Split(" ".ToCharArray())));
        }

        private WordCount[] SelectionSort(WordCount[] wordsCount)
        {
            WordCount[] SelectedWords = wordsCount;
            WordCount temp;
            int min = 0;
            for (int i = 0; i < SelectedWords.Length - 1; i++)
            {
                min = SelectedWords[i].Count;
                for (int j = i + 1; j < SelectedWords.Length; j++)
                {
                    if (SelectedWords[j].Count < SelectedWords[min].Count)
                    {
                        min = SelectedWords[j].Count;
                    }
                }
                if (min != SelectedWords[i].Count)
                {
                    temp = SelectedWords[i];
                    SelectedWords[i] = SelectedWords[min];
                    SelectedWords[min] = temp;
                }
            }
            return SelectedWords;
        }
        
        WordCount[] CountWords(string[] text)
        {
            var words = new WordCount[0];
            foreach (var word in text)
                AddOrIncrement(ref words, word);

            return words;
        }

        private void AddOrIncrement(ref WordCount[] words, string word)
        {
            int index = ContainsWord(words, word);
            if (index == -1)
            {
                AddNewWord(ref words, word);
            }
            else
            {
                words[index].Count += 1;
            }
        }

        private static void AddNewWord(ref WordCount[] words, string word)
        {
            Array.Resize(ref words, words.Length + 1);
            words[words.Length - 1] = new WordCount(word, 1);
        }

        struct Aparitions
        {
           public int NumberOfAparitions;
           public string Word;
            public Aparitions(int number, string word)
            {
                this.NumberOfAparitions = number;
                this.Word = word;
            }
        }
    }
}
