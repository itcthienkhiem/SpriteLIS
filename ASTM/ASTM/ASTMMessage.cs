namespace ASTM
{
    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Threading;
    using System.Windows.Forms;

    public class ASTMMessage
    {
        #region Fields

        public static string ack = char.ConvertFromUtf32(6);
        public static string cr = char.ConvertFromUtf32(13);
        public static string enq = char.ConvertFromUtf32(5);
        public static string eot = char.ConvertFromUtf32(4);
        public static string etb = char.ConvertFromUtf32(23);
        public static string etx = char.ConvertFromUtf32(3);
        public static string lf = char.ConvertFromUtf32(10);
        public static string nack = char.ConvertFromUtf32(21);
        public static string soh = char.ConvertFromUtf32(1);
        public static string stx = char.ConvertFromUtf32(2);

        const char caret = '^';
        const char pipe = '|';

        string delimiterDef = @"|\^&";
        string host = "host";
        string instrument = @"H7600^1";
        char recordType;
        private int _barcode;

        #endregion Fields

        #region Constructors

        public ASTMMessage(int barcode)
        {
            _barcode = barcode;
        }

        public ASTMMessage()
        {
        }

        #endregion Constructors

        #region Properties

        public int Barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }

        #endregion Properties

        #region Methods

        public string Header()
        {
            string record;
            recordType = 'H';

            record = "1" + recordType + delimiterDef + new String(pipe, 3) + instrument + new String(pipe, 5) + host + new String(pipe, 2) + "P" + pipe + "1";
            record = record + cr + etx;
            record = stx + record;
            return record;
        }

        //instrumentSpecimenID
        //comes with the query string was sent
        //<Sample No>^<Rack ID>^<Position No>^^<RackType>^<Container Type>
        public virtual string Order(int barcode, List<string> tests)
        {
            string record;
            string testRecord = "";
            recordType = 'O';

            foreach (string test in tests)
            {
                testRecord+= test + @"\";
            }

            if (testRecord!="")
            {
                testRecord = testRecord.Substring(0, testRecord.Length - 1); //trim the last backslash
            }

            record = "3" + recordType + pipe + "1" + pipe + barcode + pipe + pipe + testRecord + pipe + "R" /*priority {R, S}*/+
                 new String(pipe, 6) + "N" + //action code {N, new C, cancel}
                 new String(pipe, 14) + "O" + //order record
                 new String(pipe, 5);

            record = record + cr + etx;
            record = stx + record;
            return record;
        }

        public string Patient(int barcode, int age, char sex)
        {
            string record;
            recordType = 'P';

            record = "2" + recordType + pipe + "1" + new String(pipe, 2) + barcode.ToString() + new String(pipe, 5) + sex + new String(pipe, 6) + age.ToString() + caret + "Y";
            record = record + cr + etx;
            record = stx + record;
            return record;
        }

        public string Request_Data()
        {
            return new ASTMRecord.Request().getRequest();
        }

        public string[] SendOrder(List<string> tests)
        {
            string[] send = new string[6];

            send[0] = enq;
            send[1] = Header();
            send[2] = Patient(_barcode, 30, 'M');
            send[3] = Order(_barcode, tests);
            send[4] = Terminator();
            send[5] = eot;

            return send;
        }

        public string[] sendQuery()
        {
            string[] send = new string[5];
            send[0] = enq;
            send[1] = @"H|\^&";
            send[2] = @"Q|1|^ALL|||||||||F";
            send[3] = Terminator();
            send[4] = eot;
            return send;
        }

        /// <summary>
        /// 1: header 
        /// 2: query
        /// 3: L
        /// </summary>
        /// <returns></returns>
        public string[] SendRequest()
        {
            string[] send = new string[4];
            send[0] = enq;
            send[1] = Request_Data();
            send[2] = Terminator();
            send[3] = eot;
            return send;
        }

        public string Terminator()
        {
            string record;
            recordType = 'L';

            record = "4" + "L" + pipe + "1" + pipe + "N";
            record = record + cr + etx; //no checksum.. add [##+cr+lf] if you want...
            record = stx + record;
            return record;
        }

        #endregion Methods
    }
}