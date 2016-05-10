using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ASTM.IO
{
   public class ASTMCell3200:ASTMSerial 
    {

       public override void Eval(string str)
       {
           //TextWriter tw = new StreamWriter("date.txt",true);

           //// write a line of text to the file
           //tw.WriteLine(str);

           //// close the stream
           //tw.Close();


           this.Save(str);
           //
           // 2. The file now has a newline at the end, so write another line.
           //
           //    base.Eval(str);
       }
    }
}
