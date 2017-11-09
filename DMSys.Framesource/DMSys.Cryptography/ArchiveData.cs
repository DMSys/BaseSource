using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using DMSys.Cryptography;
using DMSys.Cryptography.Zip;

namespace DMSys.Cryptography
{
    public partial class ArchiveData : Component
    {
        public ArchiveData()
        {
            InitializeComponent();
        }

        public ArchiveData(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region Properties Data

        /// <summary>
        /// �� �� ��������� �� ��������� � ������
        /// </summary>
        private bool _IsCrypted = false;

        /// <summary>
        /// ��������� �� ������ � ����������
        /// </summary>
        private bool _IsDirArch = true;

        private string _FileNameZip = "";
        [Category("Data")]
        [Description("��� �� �������� ����")]
        public string FileNameZip
        {
            get { return _FileNameZip; }
            set { _FileNameZip = value.Trim(); }
        }

        private string _FileNameSrcRoot = "";
        private string _FileNameSource = "";
        [Category("Data")]
        [Description("��� �� ���������� ��� �� ����")]
        public string FileNameSource
        {
            get { return _FileNameSource; }
            set { _FileNameSource = value.Trim(); }
        }

        #endregion Properties Data

        /// <summary>
        /// �������� ���� ��� ����������
        /// </summary>
        public void Archive()
        {
            if (_FileNameZip.Equals(""))
            { throw new Exception("������ ��� �� �������� ���� !"); }

            if (_FileNameSource.Equals(""))
            { throw new Exception("���� ������� �������� �� ���������� !"); }
            //
            _IsDirArch = IsDirArch();

            // �������� ����������
            if (_IsDirArch)
            {
                FileStream outputFileStream = new FileStream(_FileNameZip, FileMode.Create);
                using (ZipOutputStream zipStream = new ZipOutputStream(outputFileStream))
                {
                    AddDirectories(zipStream, _FileNameSource, GetZipFileName(_FileNameSource));
                }
            }
            
            // �������� ����
            else
            {
                FileStream outputFileStream = new FileStream(_FileNameZip, FileMode.Create);
                using (ZipOutputStream zipStream = new ZipOutputStream(outputFileStream))
                {
                    AddFile(zipStream, _FileNameSource, GetZipFileName(_FileNameSource));
                }
            }
        }

        /// <summary>
        /// �������� ������ �� ������� ��� ����������
        /// </summary>
        public void Archive(List<ArchiveFileInfo> aArchiveList)
        {
            if (_FileNameZip.Equals(""))
                throw new Exception("������ ��� �� �������� ���� !");

            using (FileStream outputFileStream = new FileStream(_FileNameZip, FileMode.Create))
            {
                using (ZipOutputStream zipStream = new ZipOutputStream(outputFileStream))
                {
                    foreach (ArchiveFileInfo afi in aArchiveList)
                    {
                        if (afi.IsFile)
                        { AddFile(zipStream, afi.FileName, afi.FileZip); }
                        else
                        { AddDirectory(zipStream, afi.FileZip); }
                    }
                }
                outputFileStream.Close();
            }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public void Extract(string aZipFile, string aDstPath)
        {
            _FileNameZip = aZipFile;
            _FileNameSource = aDstPath;
            // �����������
            Extract();
        }

        /// <summary>
        /// �����������
        /// </summary>
        public void Extract()
        {
            FileStream fileStreamIn = new FileStream(_FileNameZip, FileMode.Open, FileAccess.Read);
            ZipInputStream zipInStream = new ZipInputStream(fileStreamIn);
            ZipEntry entry = zipInStream.GetNextEntry();
            while (zipInStream.CanDecompressEntry)
            {
                if (entry.IsDirectory)
                { Directory.CreateDirectory(_FileNameSource + "\\" + entry.Name); }
                else if (entry.IsFile)
                { Extract_File(zipInStream, entry); }
                entry = zipInStream.GetNextEntry();
            }
            zipInStream.Close();
            fileStreamIn.Close();
        }

        private void Extract_File(ZipInputStream zipInStream, ZipEntry aEntry)
        {
            FileStream fileStreamOut = new FileStream(_FileNameSource + @"\" + aEntry.Name, FileMode.Create, FileAccess.Write);
            int size;
            byte[] buffer = new byte[aEntry.Size];
            do
            {
                size = zipInStream.Read(buffer, 0, buffer.Length);
                fileStreamOut.Write(buffer, 0, size);
            } while (size > 0);
            fileStreamOut.Close();
        }

        #region Tools

        /// <summary>
        /// �������� ���� ���� �� ��������� �� ������ /���� ��� ����������/
        /// </summary>
        private bool IsDirArch()
        {
            if (File.Exists(_FileNameSource))
            {
                _FileNameSrcRoot = Path.GetDirectoryName(_FileNameSource)+Path.DirectorySeparatorChar;
                return false;
            }
            else if (Directory.Exists(_FileNameSource))
            {
                _FileNameSrcRoot = Path.GetDirectoryName(_FileNameSource) + Path.DirectorySeparatorChar;
                if (!_FileNameSource.EndsWith(Path.DirectorySeparatorChar.ToString()))
                { _FileNameSource = _FileNameSource + Path.DirectorySeparatorChar; }
                return true;
            } 
            else
            {
                throw new Exception("���� ������� �������� �� ���������� !");
            }
        }

        /// <summary>
        /// ���� ��� ����� �� ������
        /// </summary>
        private string GetZipFileName(string aFileName)
        {
            return aFileName.Substring(_FileNameSrcRoot.Length, aFileName.Length - _FileNameSrcRoot.Length).Replace(Path.DirectorySeparatorChar, '/');;
        }

        /// <summary>
        /// ���� ��� ������������ �� ������
        /// </summary>
        private string GetZipDirectory(string aFileName)
        {
            string sFileName = aFileName.Substring(_FileNameSrcRoot.Length, aFileName.Length - _FileNameSrcRoot.Length).Replace(Path.DirectorySeparatorChar, '/');

            if (!sFileName.EndsWith("/"))
            { sFileName += "/"; }

            return sFileName;
        }

        #endregion Tools

        #region Tools Archive

        /// <summary>
        /// ������ ���� ��� �������� ����
        /// </summary>
        private void AddFile(ZipOutputStream zipStream, string FileName, string FileZip)
        {
            try
            {
                Stream inputStream = inputStream = new FileStream(FileName, FileMode.Open);
                ZipEntry zipEntry = new ZipEntry(FileZip);

                zipEntry.IsVisible = true;
                zipEntry.IsCrypted = _IsCrypted;
                zipEntry.CompressionMethod = CompressionMethod.Deflated;
                zipStream.PutNextEntry(zipEntry);

                CopyStream(inputStream, zipStream);
                inputStream.Close();
                zipStream.CloseEntry();
            }
            catch (Exception ex)
            {
                throw new Exception("������ ��� �������� �� ���� ��� �����.\n" + ex.Message);
            }
        }

        /// <summary>
        /// ������ ���������� ��� �������� ����
        /// </summary>
        private void AddDirectory(ZipOutputStream zipStream, string FileZip)
        {
            // ��� ��� ��� �� ������
            if (!FileZip.Equals(""))
            {
                // ������ ��� ������
                try
                {
                    ZipEntry zipEntry = new ZipEntry(FileZip);
                    zipEntry.IsVisible = true;
                    zipEntry.IsCrypted = _IsCrypted;
                    zipEntry.CompressionMethod = CompressionMethod.Deflated;

                    zipStream.PutNextEntry(zipEntry);
                    zipStream.CloseEntry();
                }
                catch (Exception ex)
                {
                    throw new Exception("������ ��� �������� �� ���������� ��� ������.\n" + ex.Message);
                }
            }
        }

        /// <summary>
        /// ������ ���������� ��� �������� ����
        /// </summary>
        private void AddDirectories(ZipOutputStream zipStream, string FileName, string FileZip)
        {
            // ��� ��� ��� �� ������
            if (!FileZip.Equals(""))
            {
                // ������ ��� ������
                AddDirectory(zipStream, FileZip);
            }
            // ������ ���������������
            foreach (string sDir in Directory.GetDirectories(FileName))
            {
                AddDirectories(zipStream, sDir, GetZipDirectory(sDir));
            }
            // ������ ��������� �� ���.
            foreach (string sFile in Directory.GetFiles(FileName))
            {
                AddFile(zipStream, sFile, GetZipFileName(sFile));
            }
        }

        /// <summary>
        /// ������ ����� ��� �������� ����
        /// </summary>
        private void CopyStream(Stream source, Stream destination)
        {
            byte[] buffer = new byte[4096];
            int countBytesRead;
            while ((countBytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                destination.Write(buffer, 0, countBytesRead);
            }
        }

        #endregion Tools Archive
    }

    /// <summary>
    /// ���������� �� ����� �� ����������
    /// </summary>
    public class ArchiveFileInfo
    {
        public ArchiveFileInfo()
        {
        }

        public ArchiveFileInfo(string aFileName, string aFileZip)
        {
            FileName = aFileName;
            FileZip = aFileZip;
        }

        /// <summary>
        /// ��� �� ����� �� ����������
        /// </summary>
        public string FileName = "";

        /// <summary>
        /// ��� �� ����� � ������
        /// </summary>
        public string FileZip = "";

        /// <summary>
        /// true - ����
        /// false - ����������
        /// </summary>
        public bool IsFile = false;
    }
}
