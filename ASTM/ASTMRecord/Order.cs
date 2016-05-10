using System;
using System.Collections.Generic;

using System.Text;

namespace ASTMRecord
{
    public  class Order
    {
        public string type="O";
        public int seq;
        public string sample_id;
        public string instrument;
        public string test;
        public string priority;
        public DateTime created_at;
        public DateTime sampled_at;
        public string collected_at;
        public string volume;
        public string collector;
        public string action_code;
        public string danger_code;
        public string clinical_info;
        public string delivered_at;
        public string biomaterial;
        public string physician;
        public string physician_phone;
        public string user_field_1;
        public string user_field_2;
        public string laboratory_field_1;
        public string laboratory_field_2;
        public string modified_at;
        public string instrument_charge;
        public string instrument_section;
        public int report_type=0;
        public string reserved;
        public string location_ward;
        public string infection_flag;
        public string specimen_service;
        public string laboratory;

    }
}
