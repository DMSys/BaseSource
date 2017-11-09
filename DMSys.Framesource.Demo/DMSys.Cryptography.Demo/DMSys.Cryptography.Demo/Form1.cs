using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DMSys.Cryptography;

namespace DMSys.Cryptography.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Encrypt3DES192_Click(object sender, EventArgs e)
        {
            try
            {
                string csText = tb_Text.Text;
                string csPassword = tb_Password.Text;
                string csIV = tb_InitializationVector.Text;

                CryptoSymmetric crypto = new CryptoSymmetric();
                crypto.CryptoType = CryptoSymmetric.CryptoTypes.TripleDES_192;
                crypto.StringFormat = StringFormats.HEX;
                crypto.CalculateKey = false;

                string encryptText = crypto.Encrypt(csText, csPassword, csIV);
                tb_EncryptText.Text = encryptText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_Encrypt3DES_Click(object sender, EventArgs e)
        {
            try
            {
                string csText = tb_Text.Text;
                string csPassword = tb_Password.Text;

                CryptoSymmetric crypto = new CryptoSymmetric();
                crypto.CryptoType = CryptoSymmetric.CryptoTypes.TripleDES;
                crypto.StringFormat = StringFormats.HEX;

                string encryptText = crypto.Encrypt(csText, csPassword);
                tb_EncryptText.Text = encryptText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Decrypt3DES192_Click(object sender, EventArgs e)
        {
            string encryptText = tb_EncryptText.Text;
            string csPassword = tb_Password.Text;
            string csIV = tb_InitializationVector.Text;

            CryptoSymmetric crypto = new CryptoSymmetric();
            crypto.CryptoType = CryptoSymmetric.CryptoTypes.TripleDES_192;
            crypto.StringFormat = StringFormats.HEX;
            crypto.CalculateKey = false;

            string decryptText = crypto.Decrypt(encryptText, csPassword, csIV);
            tb_DecryptText.Text = decryptText;
        }

        private void btn_Decrypt3DES_Click(object sender, EventArgs e)
        {
            string encryptText = tb_EncryptText.Text;
            string csPassword = tb_Password.Text;

            CryptoSymmetric crypto = new CryptoSymmetric();
            crypto.CryptoType = CryptoSymmetric.CryptoTypes.TripleDES;
            crypto.StringFormat = StringFormats.HEX;

            string decryptText = crypto.Decrypt(encryptText, csPassword);
            tb_DecryptText.Text = decryptText;
        }

    }
}
