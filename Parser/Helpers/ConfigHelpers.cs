using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Parser.Helpers
{
    class ConfigHelpers
    {
        public static string LocalFolder = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Parser\\";
        public static string LocalConfig = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Parser\\data.json";
        private static void FileSetup(string Path, bool IsDirectory)
        {
            try
            {
                if (IsDirectory)
                    if (!Directory.Exists(Path))
                        Directory.CreateDirectory(Path);
                if (!IsDirectory)
                    if (!File.Exists(Path))
                        File.WriteAllText(Path, "");
            }
            catch (Exception x) { MessageBox.Show("Exeception Occured: " + x); }
        }
        public static void JsonFileSetup(string Path, object Type)
        {
            try
            {
                if (!File.Exists(Path))
                    File.WriteAllText(Path, JsonConvert.SerializeObject(Type, Formatting.Indented));
            }
            catch (Exception x) { MessageBox.Show("Exeception Occured: " + x); }
        }
        public void SetupFiles()
        {
            FileSetup(LocalFolder, true);
            JsonFileSetup(LocalConfig, new Data());
        }

    }
    public class Data
    {
        public string UserId { get; set; }
        public string SessionId { get; set; }
        public bool IsAuto { get; set; }

        public List<string> IdBlackList = new List<string>();
    }
}
