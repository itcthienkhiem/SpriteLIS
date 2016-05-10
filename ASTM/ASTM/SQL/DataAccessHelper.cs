namespace ASTM.SQL
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface DataAccessHelper
    {
        #region Methods

        int close();

        int connect();

        int delete(Object obj);

        int insert(Object obj);

        object selectAll(String filename);

        object selectALL();

        /// <summary>
        /// input: select object without parameter
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        object selectWithParameter(Object obj);

        int update(Object obj);
        void setContainer(ASTMContainer container);
        void setConnectionString(String connectionstring);
        #endregion Methods
    }
}