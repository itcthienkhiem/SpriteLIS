namespace ASTM
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ASTM.ASTMInterface;
    using System.Reflection;
    using System.Windows.Forms;
    using System.IO;
    using ASTM.SQL;
    using ASTM.IO;
    /// <summary>
    /// this is class creator of factory method 
    /// </summary>
    public class ASTMFactory
    {

        #region Methods
        /// <summary>
        /// get without config
        /// </summary>
        /// <returns></returns>
        public ASTMIOHelper getASTMCreator()
        {

            ASTMIOHelper helper = (ASTMIOHelper)getObjects(ASTMGlobal.getValue("TypeConnect"));
            IResultType type = (IResultType)getObjects(ASTMGlobal.getValue("TypeResult"));
            DataAccessHelper helpSQL = (DataAccessHelper)getObjects(ASTMGlobal.getValue("TypeSQL"));
            helper.setResultType(type);
            helper.setSQLType(helpSQL);
            return helper;
        }
        /// <summary>
        /// get astm with config file 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public ASTMIOHelper getASTMCreator(Dictionary<object, object> config)
        {
            ASTMGlobal global = new ASTMGlobal();
            global.setDicConfig = config;
            return getASTMCreator();
        }

        private object getObjects(String getASTMObject)
        {

            object help = (object)GetInstance(getASTMObject);
            return help;

        }

    

        public object GetInstance(string strFullyQualifiedName)
        {
            try
            {
                string appPath = Path.GetDirectoryName(Application.ExecutablePath);
                string str = strFullyQualifiedName.Split('.').GetValue(0).ToString();
                Assembly testAssembly = Assembly.LoadFile(appPath + @"\" + str + ".dll");
                Type calcType = testAssembly.GetType(strFullyQualifiedName);
                object calcInstance = Activator.CreateInstance(calcType);
                return calcInstance;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        #endregion Methods
    }
}