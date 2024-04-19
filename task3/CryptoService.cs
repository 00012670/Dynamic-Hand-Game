using System.Security.Cryptography;
using System.Text;

namespace task3
{
    public class CryptoService
    {
        public byte[] GenerateKey()
        {
            byte[] key = new byte[32];                                      // Create a byte array to hold the key. The key is 32 bytes (256 bits) long.
            using (var rng = RandomNumberGenerator.Create())                // Create a new instance of the RandomNumberGenerator class to generate a cryptographically strong random number.
            {
                rng.GetBytes(key);                                          // Fill the byte array with a cryptographically strong sequence of random values.
            }
            return key;                                                 
        }

        public string BytesToString(byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", "").ToLower(); // Convert the byte array to a string representation, remove hyphens, and convert to lowercase.
        }

        public string CalculateHMAC(byte[] key, string message)
        {
            string hmacString;                                              // Declare a variable to hold the HMAC string.
            using (var hmac = new HMACSHA256(key))                          // Create a new instance of the HMACSHA256 class with the specified key.
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);      // Convert the message to a byte array.
                byte[] hmacBytes = hmac.ComputeHash(messageBytes);          // Compute the hash value for the specified byte array.
                hmacString = BytesToString(hmacBytes);                      // Convert the byte array to a string representation.
            }
            return hmacString;                                              // Return the HMAC string.
        }

    }

}
