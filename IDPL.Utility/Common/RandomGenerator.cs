using System;
using System.Linq;
using System.Text;

namespace Shiksha.Utility.Common
{
    public class RandomStringGenerator
    {
        public string RandomCaps(int length = 2)
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
        public string RandomChars(int length = 8)
        {
            string validChars = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
        public string RandomSymbols(int length = 2)
        {
            string validChars = "!@#$%^&*";
            Random random = new Random();
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
        public string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomCaps());
            builder.Append(RandomChars());
            builder.Append(RandomSymbols());
            return new string(builder.ToString().OrderBy(x => Guid.NewGuid()).ToArray());
        }
    }
}
