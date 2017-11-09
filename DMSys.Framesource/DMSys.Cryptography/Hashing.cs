using System;
using System.Text;
using System.Security.Cryptography;

namespace DMSys.Cryptography
{
    public class Hashing
    {
        #region enum, constants and fields
        //types of hashing available
        public enum HashingTypes
        {
            SHA, SHA256, SHA384, SHA512, MD5
        }
        //types of hashing available
        public enum EncodingTypes
        {
            UTF32, UTF8, ASCII
        }
        #endregion

        #region static members

        public static string Hash(String inputText)
        {
            return ComputeHash(inputText, HashingTypes.MD5, EncodingTypes.UTF32, StringFormats.BASE64);
        }

        public static string Hash(String inputText, HashingTypes hashingType)
        {
            return ComputeHash(inputText, hashingType, EncodingTypes.UTF32, StringFormats.BASE64);
        }

        public static string Hash(String inputText, HashingTypes hashingType, EncodingTypes encodingTypes)
        {
            return ComputeHash(inputText, hashingType, encodingTypes, StringFormats.BASE64);
        }

        public static string Hash(String inputText, HashingTypes hashingType, EncodingTypes encodingTypes, StringFormats resultFormat)
        {
            return ComputeHash(inputText, hashingType, encodingTypes, resultFormat);
        }

        /// <summary>
        ///		returns true if the input text is equal to hashed text
        /// </summary>
        /// <param name="inputText">unhashed text to test</param>
        /// <param name="hashText">already hashed text</param>
        /// <returns>boolean true or false</returns>
        public static bool isHashEqual(string inputText, string hashText)
        {
            return (Hash(inputText) == hashText);
        }

        public static bool isHashEqual(string inputText, string hashText, HashingTypes hashingType)
        {
            return (Hash(inputText, hashingType) == hashText);
        }
        #endregion

        #region Hashing Engine

        /// <summary>
        ///		computes the hash code and converts it to string
        /// </summary>
        /// <param name="inputText">input text to be hashed</param>
        /// <param name="hashingType">type of hashing to use</param>
        /// <returns>hashed string</returns>
        private static string ComputeHash(string inputText, HashingTypes hashingType, EncodingTypes encodingTypes, StringFormats resultFormat)
        {
            HashAlgorithm HA = getHashAlgorithm(hashingType);
            Encoding textEncoder = getEncodingTypes(encodingTypes);

            //get byte representation of input text
            byte[] inputBytes = textEncoder.GetBytes(inputText);


            //hash the input byte array
            byte[] output = HA.ComputeHash(inputBytes);

            //convert output byte array to a string
            return ConvertString(output, resultFormat);
        }

        /// <summary>
        ///		returns the specific hashing alorithm
        /// </summary>
        /// <param name="hashingType">type of hashing to use</param>
        /// <returns>HashAlgorithm</returns>
        private static HashAlgorithm getHashAlgorithm(HashingTypes hashingType)
        {
            switch (hashingType)
            {
                case HashingTypes.MD5:
                    return new MD5CryptoServiceProvider();
                case HashingTypes.SHA:
                    return new SHA1CryptoServiceProvider();
                case HashingTypes.SHA256:
                    return new SHA256Managed();
                case HashingTypes.SHA384:
                    return new SHA384Managed();
                case HashingTypes.SHA512:
                    return new SHA512Managed();
                default:
                    return new MD5CryptoServiceProvider();
            }
        }

        private static Encoding getEncodingTypes(EncodingTypes encodingTypes)
        {
            switch (encodingTypes)
            {
                case EncodingTypes.UTF32:
                    return new UTF32Encoding();
                case EncodingTypes.UTF8:
                    return new UTF8Encoding();
                case EncodingTypes.ASCII:
                    return new ASCIIEncoding();
                default:
                    return new UTF32Encoding();
            }
        }

        private static string ConvertString(byte[] aValue, StringFormats resultFormat)
        {
            switch (resultFormat)
            {
                case StringFormats.BASE64:
                    return Convert.ToBase64String(aValue);
                case StringFormats.HEX:
                    return HexConvert.ToString(aValue);
                case StringFormats.BIT:
                    return BitConverter.ToString(aValue).Replace("-", "");
                default:
                    return Convert.ToBase64String(aValue);
            }
        }

        #endregion
    }
}
