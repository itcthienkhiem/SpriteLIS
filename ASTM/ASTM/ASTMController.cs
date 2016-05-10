namespace ASTM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ASTM.IO;

    public class ASTMController
    {
        #region Fields

        public object ConfigXML;
        public List<Dictionary<object, object>> lstConfig;
        public List<ASTMIOHelper> lstSerialPort = new List<ASTMIOHelper>();

        #endregion Fields

        #region Constructors

        public ASTMController()
        {
            ConfigXML = ASTMConfig.ReadConfigXML();
               setControll();
        }

        #endregion Constructors

        #region Methods
        /// <summary>
        /// close connect to serial port with id
        /// </summary>
        /// <param name="id"></param>
        public void close(int id)
        {
            lstSerialPort[id].close();
        }


        /// <summary>
        /// this is function create serial connection 
        /// 
        /// </summary>
        public void connect()
        {
            for (int i = 0; i < lstConfig.Count - 1;i++ )
               {
               ASTMFactory astmFactory = new ASTMFactory();
               ASTMIOHelper help = astmFactory.getASTMCreator(lstConfig[i]);
               help.connect();
               lstSerialPort.Add(help);

               }
        }
        public void start()
        {
            for (int i = 0; i < lstSerialPort.Count; i++)
                  lstSerialPort[i].start();

        }
        public void listenner()
        {
            for (int i = 0; i < lstSerialPort.Count; i++)
                lstSerialPort[i].Eval(""); 

        }
        public void close()
        {
            for (int i = 0; i < lstSerialPort.Count; i++)
                close(i);

        }
        public void getOpeningPort(ref List<string>lstOpeningPort )
        {
            lstOpeningPort = new List<string>();
            for (int i = 0; i < lstSerialPort.Count; i++)
                if (lstSerialPort[i].checkUsePort() == 1)
                {
                    lstOpeningPort.Add(lstSerialPort[i].getInfomationDevice());
                }

        }
        public void setControll()
        {
            lstConfig = new List<Dictionary<object, object>>();
               var itemConfig = ConfigXML as Xml2CSharp.Configuration;
               foreach (var itemSetting in itemConfig.AppSettings)
               {

               Dictionary<object,object> dcConfig = new Dictionary<object,object>();
               foreach (var itemAdd in itemSetting.Add)
               {
                   dcConfig.Add(itemAdd.Key.ToUpper(), itemAdd.Value);
               }

               lstConfig.Add(dcConfig);
               }
               Dictionary<object, object> dcCfs = new Dictionary<object, object>();

               foreach (var itemcfs in itemConfig.Config.Add)
               {

               dcCfs.Add(itemcfs.Key.ToUpper(), itemcfs.Value);

               }

               lstConfig.Add(dcCfs);
        }

        #endregion Methods
    }
}