//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace ASTMConfig
//{
//    public abstract class SettingsBase
//    {
//        public string SettingsPath { get; set; }
//        public string EncryptionKey { get; set; }

//        public SettingsBase()
//        {
//            // These properties must be set by derived class
//            SettingsPath = null;
//            EncryptionKey = null;
//        }

//        /// <summary>
//        /// Loads user settings from the specified file. The file should
//        /// have been created using this class' Save method.
//        /// 
//        /// You must implement ReadSettings for any data to be read.
//        /// </summary>
//        public void Load()
//        {
//            UserSettingsReader reader = new UserSettingsReader(EncryptionKey);
//            reader.Load(SettingsPath);
//            ReadSettings(reader);
//        }

//        /// <summary>
//        /// Saves the current settings to the specified file.
//        /// 
//        /// You must implement WriteSettings for any data to be written.
//        /// </summary>
//        public void Save()
//        {
//            UserSettingsWriter writer = new UserSettingsWriter(EncryptionKey);
//            WriteSettings(writer);
//            writer.Save(SettingsPath);
//        }

//        // Abstract methods
//        public abstract void ReadSettings(UserSettingsReader reader);
//        public abstract void WriteSettings(UserSettingsWriter writer);
//    }
//}
