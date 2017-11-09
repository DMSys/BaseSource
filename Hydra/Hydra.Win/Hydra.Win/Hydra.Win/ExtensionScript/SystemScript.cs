using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hydra.Win.ExtensionScript
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class SystemScript
    {        
        public void Close()
        {
            // _Owner.Close();
            // MessageBox.Show("Close 123");
        }

        public void ShowMessageBox(string text = "", string caption = "")
        {
            MessageBox.Show( text, caption);
        }

        public string TestArray(string value)
        {
            int[] intArray = ConvertToIntArray(value);
            return ConvertToString(intArray);
        }

        private int[] ConvertToIntArray(string value)
        {
            string[] strArray = value.Split(',');
            int[] intArray = new int[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                Int32 intValue = 0;
                if (Int32.TryParse(strArray[i], out intValue))
                {
                    intArray[i] = intValue;
                }
            }
            return intArray; 
        }

        private string ConvertToString(int[] value)
        {
            if (value == null)
            { return ""; }
            if (value.Length == 0)
            { return ""; }
            StringBuilder sb = new StringBuilder();
            sb.Append(value[0].ToString());
            for (int i = 1; i < value.Length; i++ )
            {
                sb.Append("," + value[i].ToString());
            }
            return sb.ToString();
        }
    }

}
