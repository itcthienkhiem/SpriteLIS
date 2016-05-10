namespace ASTMDatabase
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class  ASTMContainer
    {
        #region Fields

        private Dictionary<Object, object> lstFileNameData = new Dictionary<object, object>();

        #endregion Fields

        #region Constructors

        public ASTMContainer()
        {
            GetAllFileDir();
        }

        #endregion Constructors

        #region Properties

        public Dictionary<Object, object> LstFileNameData
        {
            get { return lstFileNameData; }
            set { lstFileNameData = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// this is func for read all astm exec sql command 
        /// </summary>
        public void GetAllFileDir()
        {
            //string wanted_path = System.AppDomain.CurrentDomain.BaseDirectory;

            string startupPath = Environment.CurrentDirectory;

            DirectoryInfo d = new DirectoryInfo(startupPath + ASTMConfig.ASTMGlobal.getValue("pathSQL"));//.ToUpper()].ToString());
            FileInfo[] Files = d.GetFiles(ASTMConfig.ASTMGlobal.getValue("FileType"));//.ToUpper()].ToString());
            foreach (FileInfo file in Files)
            {
                lstFileNameData.Add(file.Name, ReadFile(file.FullName));
            }
        }

        private object ReadFile(string FileName)
        {
            string[] lines = System.IO.File.ReadAllLines(FileName);

            return string.Join("", lines);
        }
        /// <summary>
        /// get data from list filename  
        /// filename path in ASTM\TestMessage\bin\Debug\ASTMDBStore
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public String getFileName(string fileName)
        {
            return LstFileNameData[fileName.ToUpper()].ToString();
        }
        #endregion Methods
    }
}