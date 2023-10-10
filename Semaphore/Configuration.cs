using Semaphore.Models;
using System;

namespace Semaphore
{
    internal class Configuration
    {
        public static string AppDataFolder => System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
        public static string ConfigurationFolder => System.IO.Path.Combine(AppDataFolder, "SemaphoreTrayServiceMonitor");
        public static string ConfigurationFile => System.IO.Path.Combine(ConfigurationFolder, "semaphore.config.json");

        public static ConfigurationModel DefaultConfiguration()
        {
            return new ConfigurationModel { Interval = 60, Services = new System.Collections.Generic.List<ServiceModel>() };
        }

        public bool Restore(out string backupFileName)
        {
            var datetime = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            var random = Guid.NewGuid().ToString("N");
            backupFileName = System.IO.Path.Combine(ConfigurationFolder, $"semaphore.configBackup-{datetime}-{random}.json");

            var oldExist = System.IO.File.Exists(ConfigurationFile);
            if (oldExist) System.IO.File.Copy(ConfigurationFile, backupFileName);
            Data = DefaultConfiguration();
            Save();
            return oldExist;
        }

        public ConfigurationModel Data { get; set; }

        public Configuration(out string message)
        {
            message = null;
            if (!System.IO.Directory.Exists(ConfigurationFolder)) System.IO.Directory.CreateDirectory(ConfigurationFolder);
            if (!System.IO.File.Exists(ConfigurationFile)) Restore(out var _);

            try
            {
                var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(ConfigurationModel));
                using (var stream = new System.IO.FileStream(ConfigurationFile, System.IO.FileMode.Open))
                {
                    Data = serializer.ReadObject(stream) as ConfigurationModel;
                }
            } catch (Exception ex)
            {
                Restore(out var backupFileName);
                message = $"Fail to load configuration file, restore to default configuration.\n\n{ex.Message}\n\nOld configuration file has been backup to {backupFileName}";
            }
        }

        public void Save()
        {
            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(ConfigurationModel));
            using (var stream = new System.IO.FileStream(ConfigurationFile, System.IO.FileMode.Create))
            {
                serializer.WriteObject(stream, Data);
            }
        }
    }
}
