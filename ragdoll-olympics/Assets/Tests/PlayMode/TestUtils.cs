using System;
using System.Collections;

namespace Tests
{
    public static class TestUtils
    {
        public static string CreateRandomString(System.Random random, int stringLength = 10) {
            int _stringLength = stringLength - 1;
            string randomString = "";
            string[] characters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
            for (int i = 0; i <= _stringLength; i++) {
                randomString = randomString + characters[random.Next(0, characters.Length)];
            }
            return randomString;
        }
    }
}