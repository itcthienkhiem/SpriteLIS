using System;
using System.Collections.Generic;
using ASTM;
using System.Text;
using System.Text.RegularExpressions;

namespace ASTMRecord
{
    public class Header
    {

        string type = "H";// (str) – Record Type ID. Always H.

        public string Type
        {
            get { return "H"; }
            set { type = "H"; }
        }
        private string delimeter;// (str) – Delimiter Definition. Always \^&.

        public string Delimeter
        {
            get { return   @"\^&"; }
            set { delimeter = @"\^&"; }
        }
        public string message_id;//(None) – Message Control ID. Not used.
        public string password;//(None) ;//– Access Password. Not used.
        public string sender;// (Sender) – Information about sender. Optional.
        public string address;// (None) – Sender Street Address. Not used.
        public string reserved;// (None) – Reserved Field. Not used.
        public string phone;// (None) – Sender Telephone Number. Not used.
        public string chars;// (None) – Sender Characteristics. Not used.
        public string receiver;//(None) – Information about receiver. Not used.
        private string comments;// (None) – Comments. Not used.

        public string Comments
        {
            get { return comments; }
            set {
                if (string.Equals(value, "Meas", StringComparison.OrdinalIgnoreCase)==false &&
                    string.Equals(value, "QC", StringComparison.OrdinalIgnoreCase) == false &&
                    string.Equals(value, "PQ", StringComparison.OrdinalIgnoreCase) == false
                    )
                {
                    Logger log = new Logger();
                    log.LogWarningMessage("Header value not have "+ value);
                    
                }
                else
                    comments = value; }
        }
        private string processing_id = "P";// (str) – Processing ID. Always P.

        public string Processing_id
        {
            get { return processing_id; }
           
        }
        private string version = "1394-97";// (str) – ASTM Version Number. Always E 1394-97.

        public string Version
        {
            get { return version; }
           
        }
        private string timestamp = DateTime.Now.ToString("YYYYMMDDHHMMSS");// Format=YYYYMMDDHHMMSS (datetime.datetime) – Date and Time of Message
        private static readonly Regex boxNumberRegex = new Regex(@"^\d-\d{5}$");

        public string Timestamp
        {
            get { return timestamp; }
            set { 
                if(VerifyBoxNumber(value)==true)    
                    timestamp = value; 
            
            }
        }
        public static bool VerifyBoxNumber(string boxNumber)
        {
            return boxNumberRegex.IsMatch(boxNumber);
        }
    }
}
