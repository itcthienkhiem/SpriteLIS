namespace ASTM
{
    using System;
    using System.Collections.Generic;
   // using System.Configuration;
    using System.IO.Ports;
    using System.Reflection;
    using System.Text;

    //using Be.MikeBevers.Logging;
    using System.Xml;
    using System.IO;
    using System.Xml.Serialization;
    using Xml2CSharp;
    using System.Windows.Forms;
    using System.Configuration;
    //using System.Configuration;
    
    /// <summary>
    /// method log 
    /// </summary>
    public class ASTMGlobal
    {
        #region Fields

        private static Dictionary<Object, Object> dicConfig = null;
       
        public Dictionary<Object, Object> setDicConfig
        {
            get { return dicConfig; }
            set { dicConfig = value; }
        }
        /// <summary>
        /// update to auto config dynamic app.config
        /// 
        /// </summary>
        private static ILogger logger = new Logger();

        #endregion Fields

        #region Constructors

        static ASTMGlobal()
        {
            try
            {
               

            }
            catch (Exception ex)
            {
                logger.LogException(ex);
            }
        }
       
        public static void setConfigDefault()
        {
            if (dicConfig == null)
                dicConfig = ReadConfigFile();
        }

        #endregion Constructors

        #region Properties

        public static ILogger Logger
        {
            get { return ASTMGlobal.logger; }
            set { ASTMGlobal.logger = value; }
        }

        #endregion Properties

        #region Methods

        public static Object getValueAsObject(string str)
        {
            return dicConfig[str.ToUpper()];
        }

        public static string getValue(string str)
        {
            return getValueAsObject(str) .ToString();
        }

        private static Dictionary<Object, Object> ReadConfigFile()
        {
            Dictionary<Object, Object> dicGlobal = new Dictionary<object, object>();
            foreach (string key in ConfigurationManager.AppSettings)
            {
                {
                    string value = ConfigurationManager.AppSettings[key];
                    dicGlobal.Add(key.ToUpper(), value);
                }
            }
            return dicGlobal;
           // return null;
        }
        

        #endregion Methods
    }
}