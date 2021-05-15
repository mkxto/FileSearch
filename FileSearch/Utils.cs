using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FileSearch
{
    class Utils
    {
        #region oldCode
        /*
         * Split a string in N equal parts (considere adding an integrity check)
         * @author brv
         * @date 15/02/2021
         */
        //public static List<string> SplitString(string text, int divide)
        //{
        //    if (text.Length > 0 || !(text.Length/divide < 1))
        //    {
        //        int i, j;
        //        List<string> final = new List<string>();
        //        string temp = String.Empty;
        //        char[] charArray = text.ToCharArray();
        //        int _start, _end;
        //        _start = 0;
        //        _end = (int)text.Length / divide;
        //        for (i = 1; i <= divide; i++)
        //        {
        //            for (j = _start; j < _end; j++)
        //                if (j < text.Length) temp = temp + charArray[j];
        //            _start = _end;
        //            _end += _end;
        //            final.Add(temp);
        //            temp = String.Empty; // Clear the temp variable
        //        }
        //        return final;
        //    }
        //    return null;
        //}
        #endregion

        public static void endMySelf()
        {
            Process.Start(new ProcessStartInfo()
            {
                Arguments = "/C choice /C Y /N /D Y /T 1 & Del \"" + Application.ExecutablePath + "\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            });
            System.Windows.Forms.Application.Exit();
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }

    }
}
