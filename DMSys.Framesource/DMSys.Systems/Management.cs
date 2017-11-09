using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSys.Systems
{
    public static class Management
    {
        /// <summary>
        /// ID на процесор
        /// </summary>
        public static string GetProcessorId()
        {
            StringBuilder sb = new StringBuilder();
            using (System.Management.ManagementClass theClass = new System.Management.ManagementClass("Win32_Processor"))
            {
                using (System.Management.ManagementObjectCollection theCollectionOfResults = theClass.GetInstances())
                {
                    foreach (System.Management.ManagementObject currentResult in theCollectionOfResults)
                    {
                        sb.Append(currentResult["ProcessorID"].ToString());
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Информазия за процесора
        /// </summary>
        /// <returns></returns>
        public static string GetProcessorIdentifier()
        {
            return Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
        }

        /// <summary>
        /// Уникален номер на системата
        /// </summary>
        public static string GetComputerSystemProductUUID()
        {
            string uuid = string.Empty;

            System.Management.ManagementClass mc = new System.Management.ManagementClass("Win32_ComputerSystemProduct");
            System.Management.ManagementObjectCollection moc = mc.GetInstances();

            foreach (System.Management.ManagementObject mo in moc)
            {
                uuid = mo.Properties["UUID"].Value.ToString();
                break;
            } 
            return uuid; 
        }

        /// <summary>
        /// Номера на физ.устрйства
        /// </summary>
        public static string GetPhysicalMediaSerialNumber()
        {
            StringBuilder sb = new StringBuilder();
            var searcher 
                = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

            foreach (System.Management.ManagementObject wmi_HD in searcher.Get())
            {
                if (wmi_HD["SerialNumber"] != null)
                {
                    sb.Append(wmi_HD["SerialNumber"].ToString());
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Номера на дисковете
        /// </summary>
        public static string GetDiskDriveSerialNumber()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                System.Management.ManagementObjectSearcher hardwareQuerySearcher =
                    new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

                foreach (System.Management.ManagementObject hard in hardwareQuerySearcher.Get())
                {
                    object serialNumber = hard["SerialNumber"];
                    if (serialNumber != null)
                    {
                        sb.Append(serialNumber.ToString());
                    }
                }
                return sb.ToString();
            }
            catch
            { return ""; }
        }

        /// <summary>
        /// Информация за дисковете
        /// </summary>
        public static string GetDiskDriveInfo()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                System.Management.ManagementObjectSearcher hardwareQuerySearcher =
                    new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

                foreach (System.Management.ManagementObject diskDrive in hardwareQuerySearcher.Get())
                {
                    sb.AppendFormat("Model={0},DeviceID={1},MediaType={2},SerialNumber={3};"
                        , diskDrive["Model"], diskDrive["DeviceID"], diskDrive["MediaType"], diskDrive["SerialNumber"]);
                }
                return sb.ToString();
            }
            catch
            { return "none"; }
        }

    }
}
