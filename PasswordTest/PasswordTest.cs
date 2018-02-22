using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;



namespace PasswordTest
{
    [TestClass]
    public class PasswordTest
    {
        [STAThread]
        static void Main()
        {
        }

        [TestMethod]
        public void lowerCaseLetters()
        {

            string password = GetPassword(10, 0,0,0,true,true);
            Assert.AreEqual(10, password.Length);
            Assert.AreEqual(10, CountCharacters(password,new Range('a','z')));
                            
        }
        [TestMethod]
        public void upperCaseAndLowerCaseLetters()
        {

            string password = GetPassword(3, 1,0,0,false,true);
            Assert.AreEqual(4, password.Length);
            Assert.AreEqual(3, CountCharacters(password,new Range('a','z')));
            Assert.AreEqual(1, CountCharacters(password,new Range('A','Z')));
                       
        }
        [TestMethod]
        public void upperCaseLowerCaseLettersAndNumbers()
        {
            string password = GetPassword(3, 1, 2,0,false,true);
            Assert.AreEqual(6, password.Length);
            Assert.AreEqual(3, CountCharacters(password, new Range('a', 'z')));
            Assert.AreEqual(1, CountCharacters(password, new Range('A', 'Z')));
            Assert.AreEqual(2, CountCharacters(password, new Range('0', '9')));
        }
        [TestMethod]
        public void upperCaseLowerCaseLettersNumbersAndSymbols()
        {
            string password = GetPassword(3, 1, 2, 7,false,true);
            Assert.AreEqual(13, password.Length);
            Assert.AreEqual(3, CountCharacters(password, new Range('a', 'z')));
            Assert.AreEqual(1, CountCharacters(password, new Range('A', 'Z')));
            Assert.AreEqual(2, CountCharacters(password, new Range('0', '9')));
            Assert.AreEqual(7 / 2, CountCharacters(password, new Range(';', '@')));
            Assert.AreEqual(7-(7 / 2), CountCharacters(password, new Range('!', '/')));
        }
        [TestMethod]
        public void VerifyUpperCaseLowerCaseLettersNumbersAndSymbols()
        {
            string password = GetPassword(3, 1, 2, 7, false,false);
            Assert.AreEqual(13, password.Length);
            Assert.AreEqual(3, CountCharacters(password, new Range('a', 'z')));
            Assert.AreEqual(1, CountCharacters(password, new Range('A', 'Z')));
            Assert.AreEqual(2, CountCharacters(password, new Range('0', '9')));
            Assert.AreEqual(7 / 2, CountCharacters(password, new Range(';', '@')));
            Assert.AreEqual(7 - (7 / 2), CountCharacters(password, new Range('!', '/')));
            Assert.IsTrue(VerifyPasswordAmbiguous(password));
            Assert.IsTrue(VerifyPasswordSimilar(password));
            
            
        }
        [TestMethod]
        public void numberOfCharacters()
        {
            Assert.AreEqual(3, CountCharacters("abcD", new Range('a', 'z')));
            Assert.AreEqual(1, CountCharacters("abcD", new Range('A', 'Z')));
            Assert.AreEqual(3, CountCharacters("012ac", new Range('0', '9')));
            Assert.AreEqual(2, CountCharacters("012ac@>", new Range(';', '@')));
        }
        [TestMethod]
        public void Verify()
        {
            Assert.IsTrue(!VerifyAmbiguous('a'));
            Assert.IsTrue(VerifySimilar('1'));
            Assert.IsTrue(VerifyPasswordAmbiguous("abcd"));
            Assert.IsTrue(VerifyPasswordSimilar("abc"));
        }

        string GetPassword(int lowerNumber, int upperNumber,int Numbers,int symbol,bool ambiguous,bool similar)
        {
            var random = new Random();
            string password = null;
            
            password += GenerateRandomChar(lowerNumber,new Range('a','z'),random,ambiguous,similar) 
                      + GenerateRandomChar(upperNumber,new Range('A','Z'),random, ambiguous, similar)
                           +GenerateRandomChar(Numbers,new Range('0','9'),random, ambiguous, similar)
                         + GenerateRandomChar(symbol/2, new Range(';', '@'),random, ambiguous, similar)
                         + GenerateRandomChar(symbol-(symbol/2), new Range('!', '/'), random, ambiguous,similar);
                        


            return password;
        }

        string GenerateRandomChar(int n, Range range,Random random,bool ambiguous,bool similar)
        {
            
            string result = null;
            char character;
            int k = n;
            while (k != 0) 
            {
                character = (char)random.Next(range.first, range.second);
                    if ((ambiguous || !VerifyAmbiguous(character))&&(similar||!VerifySimilar(character)))
                    {
                       result +=character;
                       k--;        

                     }
                
                } 
            

            return result;
            
        }

        struct Range
        {
            public char first;
            public char second;

            public Range(char a, char b)
            {
                this.first = a;
                this.second = b;
            }
                       
        }

        int CountCharacters(string input, Range range)
        {
            var count = 0;
            foreach (var c in input)
            {
                if (range.first <= c && c <= range.second)
                    count++;
            }
            return count;

        }

        bool VerifyAmbiguous(char input)
        {

            return (input == '/' || input == '\\' || input == '>' || input == '<');                                          
                      
        }

        bool  VerifySimilar(char input)
        {

            return (input == 'l' || input == '1' || input == 'I'
                     || input == 'o' || input == '0' || input == 'O');
                                        
        }

        bool VerifyPasswordAmbiguous(string input)
        {
            foreach (var i in input)
            {
                if (VerifyAmbiguous(i))
                    return false;
            }
            return true;
        }

        bool VerifyPasswordSimilar(string input)
        {
            foreach (var i in input)
            {
                if (VerifySimilar(i))
                    return false;
            }
            return true;
        }
    }

}
