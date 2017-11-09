using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace DMSys.Cryptography
{
    public partial class CryptoSymmetric : Component
    {
        #region Constructors

        public CryptoSymmetric()
        {
            InitializeComponent();
        }

        public CryptoSymmetric(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion
        
        #region enums, constants & fields

        //types of symmetric encyption
        public enum CryptoTypes { DES, RC2, Rijndael, TripleDES, TripleDES_192 }

        private byte[] mKey = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        private byte[] mIV = { 65, 110, 68, 26, 69, 178, 200, 219 };
        private byte[] SaltByteArray = { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };
        
        #endregion

        #region Propertis

        private CryptoTypes mCryptoType = CryptoTypes.Rijndael;
        [Category("Data")]
        [Description("type of encryption / decryption used")]
        public CryptoTypes CryptoType
        {
            get
            { return mCryptoType; }
            set
            { mCryptoType = value; }
        }

        private bool _CalculateKey = true;
        [Category("Data")]
        [Description("calculates the key and IV acc. to the symmetric method from the password key and IV size dependant on symmetric method")]
        public bool CalculateKey
        {
            get
            { return _CalculateKey; }
            set
            { _CalculateKey = value; }
        }

        private string mPassword = "abcd!@#";
        [Category("Data")]
        [Description("Passsword Key Property. The password key used when encrypting / decrypting")]
        public string Password
        {
            set
            { mPassword = value; }
            get
            { return mPassword; }
        }

        private string mInitializationVector = "";
        [Category("Data")]
        [Description("Initialization Vector Property. The initialization vector used when encrypting / decrypting")]
        public string InitializationVector
        {
            set
            { mInitializationVector = value; }
            get
            { return mInitializationVector; }
        }

        private StringFormats _StringFormat = StringFormats.BASE64;
        [Category("Data")]
        [Description("Format of string.")]
        public StringFormats StringFormat
        {
            get
            { return _StringFormat; }
            set
            { _StringFormat = value; }
        }

        #endregion Propertis

        #region Encryption

        /// <summary>
        ///		Encrypt a string
        /// </summary>
        /// <param name="inputText">text to encrypt</param>
        /// <returns>an encrypted string</returns>
        public string Encrypt(string inputText)
        {
            //declare a new encoder
            UTF8Encoding UTF8Encoder = new UTF8Encoding();
            //get byte representation of string
            byte[] inputBytes = UTF8Encoder.GetBytes(inputText);

            //convert back to a string
            return ToString(EncryptDecrypt(inputBytes, true), _StringFormat);
        }

        /// <summary>
        /// Encrypt string with user defined password
        /// </summary>
        /// <param name="inputText">text to encrypt</param>
        /// <param name="password">password to use when encrypting</param>
        /// <returns>an encrypted string</returns>
        public string Encrypt(string inputText, string password)
        {
            mPassword = password;
            return this.Encrypt(inputText);
        }

        /// <summary>
        /// Encrypt string with user defined password
        /// </summary>
        /// <param name="inputText">text to encrypt</param>
        /// <param name="password">password to use when encrypting</param>
        /// <param name="iv">initialization vector</param>
        /// <returns>an encrypted string</returns>
        public string Encrypt(string inputText, string password, string iv)
        {
            mInitializationVector = iv;
            return this.Encrypt(inputText, password);
        }

        /// <summary>
        /// Encrypt string acc. to cryptoType and with user defined password
        /// </summary>
        /// <param name="inputText">text to encrypt</param>
        /// <param name="password">password to use when encrypting</param>
        /// <param name="cryptoType">type of encryption</param>
        /// <returns>an encrypted string</returns>
        public string Encrypt(string inputText, string password, CryptoTypes cryptoType)
        {
            mCryptoType = cryptoType;
            return this.Encrypt(inputText, password);
        }

        /// <summary>
        /// Encrypt string acc. to cryptoType
        /// </summary>
        /// <param name="inputText">text to encrypt</param>
        /// <param name="cryptoType">type of encryption</param>
        /// <returns>an encrypted string</returns>
        public string Encrypt(string inputText, CryptoTypes cryptoType)
        {
            mCryptoType = cryptoType;
            return this.Encrypt(inputText);
        }

        private string ToString(byte[] aValue, StringFormats resultFormat)
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

        #region Decryption

        /// <summary>
        ///		decrypts a string
        /// </summary>
        /// <param name="inputText">string to decrypt</param>
        /// <returns>a decrypted string</returns>
        public string Decrypt(string inputText)
        {
            //declare a new encoder
            UTF8Encoding UTF8Encoder = new UTF8Encoding();
            //get byte representation of string
          //  byte[] inputBytes = Convert.FromBase64String(inputText);
            byte[] inputBytes = FromString(inputText, _StringFormat);

            //convert back to a string
            return UTF8Encoder.GetString(EncryptDecrypt(inputBytes, false)).TrimEnd('\0');
        }

        /// <summary>
        ///		decrypts a string using a user defined password key
        /// </summary>
        /// <param name="inputText">string to decrypt</param>
        /// <param name="password">password to use when decrypting</param>
        /// <returns>a decrypted string</returns>
        public string Decrypt(string inputText, string password)
        {
            mPassword = password;
            return Decrypt(inputText);
        }

        /// <summary>
        ///		decrypts a string using a user defined password key
        /// </summary>
        /// <param name="inputText">string to decrypt</param>
        /// <param name="password">password to use when decrypting</param>
        /// <param name="iv">initialization vector</param>
        /// <returns>a decrypted string</returns>
        public string Decrypt(string inputText, string password, string iv)
        {
            mInitializationVector = iv;
            return Decrypt(inputText, password);
        }

        /// <summary>
        ///		decrypts a string acc. to decryption type and user defined password key
        /// </summary>
        /// <param name="inputText">string to decrypt</param>
        /// <param name="password">password key used to decrypt</param>
        /// <param name="cryptoType">type of decryption</param>
        /// <returns>a decrypted string</returns>
        public string Decrypt(string inputText, string password, CryptoTypes cryptoType)
        {
            mCryptoType = cryptoType;
            return Decrypt(inputText, password);
        }

        /// <summary>
        ///		decrypts a string acc. to the decryption type
        /// </summary>
        /// <param name="inputText">string to decrypt</param>
        /// <param name="cryptoType">type of decryption</param>
        /// <returns>a decrypted string</returns>
        public string Decrypt(string inputText, CryptoTypes cryptoType)
        {
            mCryptoType = cryptoType;
            return Decrypt(inputText);
        }


        private byte[] FromString(string aValue, StringFormats resultFormat)
        {
            switch (resultFormat)
            {
                case StringFormats.BASE64:
                    return Convert.FromBase64String(aValue);
                case StringFormats.HEX:
                case StringFormats.BIT:
                    return HexConvert.FromString(aValue);
                default:
                    return Convert.FromBase64String(aValue);
            }
        }

        #endregion

        #region Symmetric Engine

        /// <summary>
        ///		performs the actual enc/dec.
        /// </summary>
        /// <param name="inputBytes">input byte array</param>
        /// <param name="Encrpyt">wheather or not to perform enc/dec</param>
        /// <returns>byte array output</returns>
        private byte[] EncryptDecrypt(byte[] inputBytes, bool Encrpyt)
        {
            //get the correct transform
            ICryptoTransform transform = getCryptoTransform(Encrpyt);

            //memory stream for output
            MemoryStream memStream = new MemoryStream();

            try
            {
                //setup the cryption - output written to memstream
                CryptoStream cryptStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);

                //write data to cryption engine
                cryptStream.Write(inputBytes, 0, inputBytes.Length);

                //we are finished
                cryptStream.FlushFinalBlock();

                //get result
                byte[] output = memStream.ToArray();

                //finished with engine, so close the stream
                cryptStream.Close();

                return output;
            }
            catch (Exception e)
            {
                //throw an error
                throw new Exception("Error in symmetric engine. Error : " + e.Message, e);
            }
        }

        /// <summary>
        ///		returns the symmetric engine and creates the encyptor/decryptor
        /// </summary>
        /// <param name="encrypt">whether to return a encrpytor or decryptor</param>
        /// <returns>ICryptoTransform</returns>
        private ICryptoTransform getCryptoTransform(bool encrypt)
        {
            calculateNewKeyAndIV();

            SymmetricAlgorithm SA = selectAlgorithm();
            SA.Key = mKey;
            SA.IV = mIV;
            if (encrypt)
            {
                return SA.CreateEncryptor();
            }
            else
            {
                return SA.CreateDecryptor();
            }
        }
        
        /// <summary>
        ///		returns the specific symmetric algorithm acc. to the cryptotype
        /// </summary>
        /// <returns>SymmetricAlgorithm</returns>
        private SymmetricAlgorithm selectAlgorithm()
        { 
            switch (mCryptoType)
            {
                case CryptoTypes.DES:
                    return DES.Create();
                case CryptoTypes.RC2:
                    return RC2.Create();
                case CryptoTypes.Rijndael:
                    return Rijndael.Create();
                case CryptoTypes.TripleDES_192:
                    SymmetricAlgorithm sa = TripleDES.Create();
                    sa.Mode = CipherMode.CBC;
                    sa.Padding = PaddingMode.Zeros;
                    return sa;
                case CryptoTypes.TripleDES:
                default:
                    return TripleDES.Create();
            }
        }

        /// <summary>
        ///		calculates the key and IV acc. to the symmetric method from the password
        ///		key and IV size dependant on symmetric method
        /// </summary>
        private void calculateNewKeyAndIV()
        {
            if (_CalculateKey)
            {
                //use salt so that key cannot be found with dictionary attack
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(mPassword, SaltByteArray);
                SymmetricAlgorithm algo = selectAlgorithm();
                mKey = pdb.GetBytes(algo.KeySize / 8);
                mIV = pdb.GetBytes(algo.BlockSize / 8);
            }
            else
            {
                if (mCryptoType == CryptoTypes.TripleDES_192)
                {
                    mKey = BytesPadRight(mPassword, 24, '\0');
                    mIV = BytesPadRight(mInitializationVector, 8, '\0');
                }
                else
                {
                    mKey = ASCIIEncoding.ASCII.GetBytes(mPassword);
                    mIV = ASCIIEncoding.ASCII.GetBytes(mInitializationVector);
                }
            }
        }

        private byte[] BytesPadRight(string value, int totalWidth, char paddingChar)
        {
            if (value.Length > totalWidth)
            { return ASCIIEncoding.ASCII.GetBytes(value.Substring(0, totalWidth)); }
            else if (value.Length < totalWidth)
            { return ASCIIEncoding.ASCII.GetBytes(value.PadRight(totalWidth, paddingChar)); }
            else
            { return ASCIIEncoding.ASCII.GetBytes(value); }
        }

        #endregion
    }
}
