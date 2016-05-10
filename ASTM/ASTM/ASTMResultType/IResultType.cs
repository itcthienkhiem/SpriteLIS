using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASTM.ASTMInterface
{
   public interface IResultType
    {
       List<object> getResult(Object result);
       
    }
}
