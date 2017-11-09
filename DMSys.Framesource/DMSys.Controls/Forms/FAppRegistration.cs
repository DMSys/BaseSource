using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DMSys.Cryptography;

using System.Net;
using System.IO;
using System.Runtime.Serialization;

namespace DMSys.Controls.Forms
{
    /// <summary>
    /// Форма за проверка на регистрация
    /// </summary>
    public partial class FAppRegistration : Form
    {
        #region Properties

        private string _ProcessorId = "";
        private string _ApplicationID = "";
        public string ApplicationID
        {
            get
            { return _ApplicationID; }
        }

        private string _ApplicationKey = "";
        private string _ApplicationIv = "";
        /// <summary>
        /// Уникален номер на приложението
        /// </summary>
        private string _ApplicationUniqueID = "";
        /// <summary>
        /// Кеширан път до приложението
        /// </summary>
        private string _АpplicationPathHash = "";

        private string _RegistrationNumber = "";
        public string RegistrationNumber
        {
            get
            { return _RegistrationNumber; }
        }

        private bool _IsValid = false;
        public bool IsValid
        {
            get
            { return _IsValid; }
        }

        private string _ValidationMsg = "";

        private DateTime _RegistrationDate = DateTime.MinValue;
        /// <summary>
        /// Валиднолидност на регистрацията
        /// </summary>
        public DateTime RegistrationDate
        {
            get
            { return _RegistrationDate; }
        }

        #endregion Properties

        public FAppRegistration()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Зарежда основните данни за регистрацията
        /// </summary>
        /// <param name="applicationKey">Код на приложението</param>
        /// <param name="applicationIv"></param>
        public void LoadData(string applicationKey, string applicationIv)
        {
            _ApplicationKey = applicationKey;
            _ApplicationIv = applicationIv;
            _IsValid = false;
            // Връзката с PC
            _ProcessorId = DMSys.Systems.Management.GetProcessorId();
            if (_ProcessorId.Length > 16)
            { _ProcessorId = _ProcessorId.Substring(0, 16); }
            if (_ProcessorId == "")
            { throw new Exception("Няма открит ProcessorId"); }

            // Кеширан път до приложението
            _АpplicationPathHash = Hashing.Hash(Application.ExecutablePath, Hashing.HashingTypes.MD5, Hashing.EncodingTypes.ASCII, StringFormats.BIT);
            _ApplicationUniqueID = _ProcessorId + _АpplicationPathHash.Substring(0, 7);

            // Генерира ApplicationID
            _ApplicationID = crypto.Encrypt(_ApplicationUniqueID, applicationKey, _ApplicationIv);
            if (_ApplicationID == "")
            { throw new Exception("Грешка при генериране на ApplicationID"); }
        }

        /// <summary>
        /// Проверява Рег.Номер
        /// </summary>
        /// <param name="registrationNumber">Рег.Номер</param>
        /// <returns></returns>
        public bool Validation(string registrationNumber, DateTime? limiteDate = null)
        {
            if (registrationNumber == "")
            { return false; }
            try
            {
                _IsValid = Validation(registrationNumber
                                    , _ProcessorId
                                    , _ApplicationID
                                    , _ApplicationKey
                                    , _ApplicationIv);
                // Добава лимитиране, ако 'Рег.Номер' е валиден
                if (_IsValid && (limiteDate != null))
                {
                    if (_RegistrationDate > limiteDate)
                    {
                        _RegistrationDate = (DateTime)limiteDate;
                        
                        CryptoSymmetric crypto = new CryptoSymmetric();
                        crypto.CryptoType = CryptoSymmetric.CryptoTypes.TripleDES_192;
                        crypto.StringFormat = StringFormats.HEX;
                        crypto.CalculateKey = false;

                        string processorId = crypto.Decrypt(_ApplicationID, _ApplicationKey, _ApplicationIv);
                        string uniAppId = Hashing.Hash(processorId, Hashing.HashingTypes.MD5, Hashing.EncodingTypes.ASCII, StringFormats.BIT).Substring(0, 15);
                        string validUntil = _RegistrationDate.ToString("yyyyMMdd");
                        _RegistrationNumber = crypto.Encrypt(validUntil + uniAppId, _ApplicationKey, _ApplicationIv);
                    }
                }
            }
            catch
            { _IsValid = false; }
            return _IsValid;
        }

        /// <summary>
        /// Отваря формата за рагистрация
        /// </summary>
        /// <returns></returns>
        public bool ShowForm()
        {
            _IsValid = false;
            tb_ApplicationID.Text = _ApplicationID;
            ShowDialog();
            return _IsValid;
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            try
            {
                _IsValid = false;
                _RegistrationNumber = tb_RegistrationNumber.Text.Trim();
                if (_RegistrationNumber == "")
                { 
                    MessageBox.Show("Enter the registration number.");
                    return;
                }

                _ValidationMsg = "";
                _IsValid = Validation(_RegistrationNumber
                                    , _ProcessorId
                                    , _ApplicationID
                                    , _ApplicationKey
                                    , _ApplicationIv);
                if( (!_IsValid) && (_ValidationMsg!=""))
                {
                    MessageBox.Show("Invalid registration number /" + _ValidationMsg+"/");
                }
            }
            catch(Exception ex)
            {
                _IsValid = false;
                MessageBox.Show(ex.Message); 
            }
            if (_IsValid)
            { Close(); }
        }

        /// <summary>
        /// Проверява рег.номер
        /// </summary>
        /// <param name="registrationNumber"></param>
        /// <param name="processorId"></param>
        /// <param name="applicationId"></param>
        /// <param name="applicationKey"></param>
        /// <returns></returns>
        private bool Validation(string registrationNumber
            , string processorId
            , string applicationId
            , string applicationKey
            , string applicationIv)
        {
            string regValue = "";
            try
            {
                regValue = crypto.Decrypt(registrationNumber, applicationKey, applicationIv);
            }
            catch
            {
                _ValidationMsg = "DRN";
                return false;
            }
            if ( regValue.Length < 8 )
            {
                _ValidationMsg = "L" + regValue.Length.ToString();
                return false; 
            }
            string regDate = regValue.Substring(0, 8);
            string regID = regValue.Substring(8, regValue.Length - 8);

            string uniAppId = Hashing.Hash(_ProcessorId + _АpplicationPathHash.Substring(0, 7), Hashing.HashingTypes.MD5, Hashing.EncodingTypes.ASCII, StringFormats.BIT).Substring(0, 15);
            // Валидира ID
            if (regID != uniAppId)
            {
                _ValidationMsg = "PID";
                return false; 
            }
            // Валидира датата
            try
            {
                _RegistrationDate = new DateTime(Int32.Parse(regDate.Substring(0, 4))
                                      , Int32.Parse(regDate.Substring(4, 2))
                                      , Int32.Parse(regDate.Substring(6, 2)));
            }
            catch
            {
                _ValidationMsg = "RDT";
                return false;
            }
            if (_RegistrationDate < DateTime.Now)
            {
                _ValidationMsg = "ODT";
                return false; 
            }
            // Успешна валидация
            _RegistrationNumber = registrationNumber;
            return true;
        }

        /// <summary>
        /// Регистрация през интернет
        /// </summary>
        public RegistrationRs OnlineRegistration(string requestUrl, int appsTypeId)
        {
            RegistrationRs regRs = null;
            // Формира данните на заявката
            StringBuilder postData = new StringBuilder();
            postData.Append("apps_type_id=" + appsTypeId);
            postData.Append("&application_id=" + _ApplicationID);
            postData.Append("&processor_id=" + DMSys.Systems.Management.GetProcessorId());
            postData.Append("&processor_identifier=" + DMSys.Systems.Management.GetProcessorIdentifier());
            postData.Append("&uuid=" + DMSys.Systems.Management.GetComputerSystemProductUUID());
            postData.Append("&executable_path=" + Application.ExecutablePath);
            postData.Append("&machine_name=" + System.Environment.MachineName);
            postData.Append("&user_name=" + System.Environment.UserName);
            postData.Append("&os_version=" + System.Environment.OSVersion.VersionString);
            postData.Append("&disk_drive=" + DMSys.Systems.Management.GetDiskDriveInfo());
            byte[] postArray = Encoding.UTF8.GetBytes(postData.ToString());
            // Създава заявката
            WebRequest request = WebRequest.Create(requestUrl);
            request.Timeout = 1000;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postArray.Length;
            // Добавя данните към заявката
            using (Stream dataStreamRq = request.GetRequestStream())
            {
                dataStreamRq.Write(postArray, 0, postArray.Length);
                dataStreamRq.Close();
            }
            // Изпраща заявката
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (Stream dataStreamRs = response.GetResponseStream())
                {
                    try
                    {
                        string stringRs = String.Empty;
                        // Валедира отговора
                        using (StreamReader readRs = new StreamReader(dataStreamRs))
                        {
                            stringRs = readRs.ReadToEnd();

                            int responseLength = stringRs.IndexOf('}');
                            stringRs = stringRs.Substring(0, responseLength + 1);
                        }
                        // Десериализиране отговора
                        using (var memoryStreamRs = new MemoryStream(Encoding.Unicode.GetBytes(stringRs)))
                        {
                            System.Runtime.Serialization.Json.DataContractJsonSerializer jsonSerializer
                                = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(RegistrationRs));

                            regRs = (RegistrationRs)jsonSerializer.ReadObject(memoryStreamRs);
                        }
                    }
                    catch
                    { }
                    dataStreamRs.Close();
                }
                response.Close();
            }
            return regRs;
        }

        [DataContract]
        public class RegistrationRs
        {
            [DataMember]
            public int status;

            [DataMember]
            public string message;
        }
    }
}
