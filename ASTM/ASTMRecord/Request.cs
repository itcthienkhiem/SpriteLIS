using System;
using System.Collections.Generic;

using System.Text;

namespace ASTMRecord
{
  public  class Request
    {
      private String type;

      public int seq;
      public string practice_id;
      public string start_laboratory_id;

      public string end_laboratory_id;
      public string nature_time;
      public string begin_request_resuls;
      public string end_request_resuls;
      public string request_physician_name;
      public string request_physician_telephone;
      public string user_field_1;
      public string user_field_2;
      public string request_info_status;
      


        public String Type
        {
          get { return type; }
          set {
      
              type = "H"; }
        }
        public string getRequest()
        {
            return @"Q|1|Pat ID||||||||||D<CR>";
        }
    }
}
