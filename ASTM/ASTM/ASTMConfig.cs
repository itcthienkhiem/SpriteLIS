namespace ASTM
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Serialization;

    public class ASTMConfig
    {
        #region Fields

        public static object global = null;
        private static Xml2CSharp.Configuration config;
        public Xml2CSharp.Configuration Config
        {
            get { return config; }
            set { config = value; }
        }
        #endregion Fields

        #region Methods

        /// <summary>
        /// read config xml with path default in app.config
        /// </summary>
        /// <returns></returns>
        public static object ReadConfigXML()
        {
            string value = ConfigurationManager.AppSettings["configFileName"];
            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\" + value;
            return ASTMConfig.ReadConfigXML(path);
        }

        public static object ReadConfigXML(string path)
        {
            Dictionary<Object, Object> dicGlobal = new Dictionary<object, object>();
               Xml2CSharp.Configuration customer = ReadFromXmlFile<Xml2CSharp.Configuration>(path);
               return customer;
        }

        /// <summary>
        /// Reads an object instance from an XML file.
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object to read from the file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the XML file.</returns>
        public static T ReadFromXmlFile<T>(string filePath)
            where T : new()
        {
            TextReader reader = null;
               try
               {
               var serializer = new XmlSerializer(typeof(T));
               reader = new StreamReader(filePath);
               return (T)serializer.Deserialize(reader);
               }
               finally
               {
               if (reader != null)
                   reader.Close();
               }
        }

        /// <summary>
        /// write config xml with path default
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int WriteConfigXML(Xml2CSharp.Configuration obj)
        {
            string value = ConfigurationManager.AppSettings["configFileName"];
               string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\" + value;
               return ASTMConfig.WritedConfigXML(obj,path);
        }
        public static void setObjectConfig()
        {
            Xml2CSharp.Configuration conf = new Xml2CSharp.Configuration();

            List<Xml2CSharp.AppSettings> settings = new List<Xml2CSharp.AppSettings>();
           {
                Xml2CSharp.AppSettings setting = new Xml2CSharp.AppSettings();
                List<Xml2CSharp.Add> adds = new List<Xml2CSharp.Add>();

                {
                    Xml2CSharp.Add add0 = new Xml2CSharp.Add();
                    add0.Key = "SerialPort";
                    add0.Value = "COM2";
                    adds.Add(add0);
                    Xml2CSharp.Add add1 = new Xml2CSharp.Add();
                    add1.Key = "BaudRate";
                    add1.Value = "9600";
                    adds.Add(add1);
                    Xml2CSharp.Add add2 = new Xml2CSharp.Add();
                    add2.Key = "DataBits";
                    add2.Value = "8";
                    adds.Add(add2);
                    Xml2CSharp.Add add3 = new Xml2CSharp.Add();
                    add3.Key = "StopBits";
                    add3.Value = "1";
                    adds.Add(add2);
                    Xml2CSharp.Add add4 = new Xml2CSharp.Add();
                    add4.Key = "Parity";
                    add4.Value = "None";
                    adds.Add(add4);

                }
                setting.Add = adds;
                settings.Add(setting);

                Xml2CSharp.AppSettings setting1 = new Xml2CSharp.AppSettings();
                List<Xml2CSharp.Add> adds1 = new List<Xml2CSharp.Add>();
                Xml2CSharp.Add add01 = new Xml2CSharp.Add();
                add01.Key = "SerialPort";
                add01.Value = "COM2";
                adds1.Add(add01);
                setting1.Add = adds1;
                settings.Add(setting1);
            }
            conf.AppSettings = settings;

        }
        public static int WritedConfigXML( String path)
        {
            return WritedConfigXML(config, path);

        }
        /// <summary>
        /// write data to xml
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        /// 

        public static int WritedConfigXML(Xml2CSharp.Configuration obj, String path)
        {
            //   List<Xml2CSharp.Configuration> lst = new List<Xml2CSharp.Configuration>();

            WriteToXmlFile<Xml2CSharp.Configuration>(path, obj);
            return 1;
        }

        /// <summary>
        /// Writes the given object instance to an XML file.
        /// <para>Only Public properties and variables will be written to the file. These can be any type though, even other classes.</para>
        /// <para>If there are public properties/variables that you do not want written to the file, decorate them with the [XmlIgnore] attribute.</para>
        /// <para>Object type must have a parameterless constructor.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the file.</typeparam>
        /// <param name="filePath">The file path to     write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        public static void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false)
            where T : new()
        {
            TextWriter writer = null;
               try
               {
               var serializer = new XmlSerializer(typeof(T));
               writer = new StreamWriter(filePath, append);
               serializer.Serialize(writer, objectToWrite);
               }
               finally
               {
               if (writer != null)
                   writer.Close();
               }
        }

        #endregion Methods
    }
}