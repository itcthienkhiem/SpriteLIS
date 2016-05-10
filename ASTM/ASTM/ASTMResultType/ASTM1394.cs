using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTM.ASTMInterface
{
    public class ASTM1394 : IResultType
    {


        public List<object> getResult(Object results)
        {
            List<object> result = new List<object>();
            Parser.parse((String)results, ref result);
            return result;
        }

    }
}
