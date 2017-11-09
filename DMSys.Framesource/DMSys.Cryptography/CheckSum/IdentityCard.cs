using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSys.Cryptography.CheckSum
{
    public class IdentityCard : IDisposable
    {
        private string sIDC = "";
        private string sErrorMsg = "";
        private Int16[] masIDC = new Int16[9];
        private Int16[] masIDC_Values = { 2, 4, 8, 5, 10, 9, 7, 3 }; // тегла по позиции
        private Int32 sumIDC = 0;

        public IdentityCard()
        { }

        /// <summary>
        /// Проверява номера на личната карта
        /// </summary>
        public bool ExecuteCheck(string aIDC)
        {
            // Проверява дължината
            sIDC = aIDC.Trim();
            if (sIDC.Length != 9)
            {
                sErrorMsg = "Въведи 9 символа !";
                return false;
            }
            // Конвертира в числа
            try
            {
                for (int i = 0; i < 9; i++)
                {
                    masIDC[i] = Convert.ToInt16(sIDC.Substring(i, 1));
                }
            }
            catch (Exception ex)
            {
                sErrorMsg = ex.Message;
                return false;
            }
            // Умножава по теглото на позицията и mod 11
            sumIDC = 0;
            for (int i = 0; i < 8; i++)
            {
                sumIDC += FunCS.Mod((masIDC[i] * masIDC_Values[i]), 11);
            }
            // Пресмята сумата
            Int32 iRes = FunCS.Mod(sumIDC, 11);
            if (iRes == masIDC[8])
            {
                return true;
            }
            else
            {
                sErrorMsg = "";
                for (int i = 0; i < 8; i++)
                {
                    sErrorMsg += masIDC[i].ToString();
                }
                sErrorMsg += iRes.ToString();
                if (sErrorMsg.Length != 9)
                    sErrorMsg = "none";
                return false;
            }
        }

        public string ErrorMsg
        {
            get
            {
                return sErrorMsg;
            }
        }

        public void Dispose()
        { }
    }
}
