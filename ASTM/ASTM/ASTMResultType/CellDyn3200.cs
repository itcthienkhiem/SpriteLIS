namespace ASTM.ASTMInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CellDyn3200 : IResultType
    {
        #region Methods

        public List<object> getResult(Object results)
        {
            //TestResult_CellDyn3200
            List<object> testResults = new List<object>();
            // string result = "\"   \",\"CD3200C\",\"------------\",3280,0,0,\"AVER124     \",\"BUI THI NGHIA TD            \",\"----------------\",\"F\",\"--/--/----\",\"----------------------\",\".  \",\"04/14/2012\",\"17:38\",\"--/--/----\",\"--:--\",\"----------------\",06.34,04.12,01.59,0.307,0.218,0.096,04.36,012.0,038.0,087.0,027.5,031.6,012.7,00254,06.53,0.166,016.7,065.1,025.1,04.85,03.45,01.51,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,00000,00000,00000,00000,00000,00000,00000,00000,-----,06.34,1,0,0,0,0,0,0,70\"   \",\"CD3200C\",\"------------\",3280,0,0,\"AVER124     \",\"BUI THI NGHIA TD            \",\"----------------\",\"F\",\"--/--/----\",\"----------------------\",\".  \",\"04/14/2012\",\"17:38\",\"--/--/----\",\"--:--\",\"----------------\",06.34,04.12,01.59,0.307,0.218,0.096,04.36,012.0,038.0,087.0,027.5,031.6,012.7,00254,06.53,0.166,016.7,065.1,025.1,04.85,03.45,01.51,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,00000,00000,00000,00000,00000,00000,00000,00000,-----,06.34,1,0,0,0,0,0,0,70 ";
            string result =(results as string).Replace("\"", "");
            string[] strArr = result.Split("".ToCharArray());
            if (strArr != null && strArr.Length > 0)
            {
               
                for (int i = 0; i < strArr.Length - 1; i++)
                {
                    TestResult_CellDyn3200 testResult = new TestResult_CellDyn3200();
                    result = strArr[i];
                    string[] arrResult = result.Split(",".ToCharArray(), StringSplitOptions.None);
                    if (arrResult == null || arrResult.Count() == 0) continue;

                    testResult.KetQuaXetNghiem.MessageType = arrResult[0].Trim().Substring(1);
                    testResult.KetQuaXetNghiem.InstrumentType = arrResult[1].Trim();
                    testResult.KetQuaXetNghiem.SerialNum = arrResult[2].Trim();
                    testResult.KetQuaXetNghiem.SequenceNum = Convert.ToInt32(arrResult[3].Trim());
                    testResult.KetQuaXetNghiem.SpareField = arrResult[4].Trim();
                    testResult.KetQuaXetNghiem.SpecimenType = Convert.ToInt32(arrResult[5].Trim());
                    if (testResult.KetQuaXetNghiem.SpecimenType != 0) continue;

                    testResult.KetQuaXetNghiem.SpecimenID = arrResult[6].Trim();
                    testResult.KetQuaXetNghiem.SpecimenName = arrResult[7].Trim();
                    testResult.KetQuaXetNghiem.PatientID = arrResult[8].Trim();
                    testResult.KetQuaXetNghiem.SpecimenSex = arrResult[9].Trim();
                    if (testResult.KetQuaXetNghiem.SpecimenSex == "-") testResult.KetQuaXetNghiem.SpecimenSex = string.Empty;

                    testResult.KetQuaXetNghiem.SpecimenDOB = arrResult[10].Trim();
                    if (testResult.KetQuaXetNghiem.SpecimenDOB == "--/--/----") testResult.KetQuaXetNghiem.SpecimenDOB = string.Empty;

                    testResult.KetQuaXetNghiem.DrName = arrResult[11].Trim();
                    testResult.KetQuaXetNghiem.OperatorID = arrResult[12].Trim();

                    testResult.KetQuaXetNghiem.NgayXN = DateTime.ParseExact(string.Format("{0} {1}", arrResult[13].Trim(), arrResult[14].Trim()),
                            "MM/dd/yyyy HH:mm", null);

                    testResult.KetQuaXetNghiem.CollectionDate = arrResult[15].Trim();
                    testResult.KetQuaXetNghiem.CollectionTime = arrResult[16].Trim();
                    testResult.KetQuaXetNghiem.Comment = arrResult[17].Trim();

                    //WBC
                    ChiTietKetQuaXetNghiem_CellDyn3200 ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "WBC";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[18].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //NEU
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "Neu";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[19].Trim());
                    ctkqxn.TestPercent = Convert.ToDouble(arrResult[35].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //NEU%
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "Neu%";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[35].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //LYM
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "Lym";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[20].Trim());
                    ctkqxn.TestPercent = Convert.ToDouble(arrResult[36].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //LYM%
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "Lym%";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[36].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //MONO
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "Mono";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[21].Trim());
                    ctkqxn.TestPercent = Convert.ToDouble(arrResult[37].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //MONO%
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "Mono%";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[37].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //EOS
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "Eos";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[22].Trim());
                    ctkqxn.TestPercent = Convert.ToDouble(arrResult[38].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //EOS%
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "Eos%";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[38].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //BASO
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "Baso";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[23].Trim());
                    ctkqxn.TestPercent = Convert.ToDouble(arrResult[39].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //BASO%
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "Baso%";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[39].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //RBC
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "RBC";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[24].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //HGB
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "Hb";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[25].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //HCT
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "Hct";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[26].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //MCV
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "MCV";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[27].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //MCH
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "MCH";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[28].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //MCHC
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "MCHC";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[29].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //RDW
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "RDW";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[30].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //PLT
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "PLT";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[31].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //MPV
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "MPV";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[32].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //PCT
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "PCT";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[33].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    //PDW
                    ctkqxn = new ChiTietKetQuaXetNghiem_CellDyn3200();
                    ctkqxn.TenXetNghiem = "PDW";
                    ctkqxn.TestResult = Convert.ToDouble(arrResult[34].Trim());
                    testResult.ChiTietKetQuaXetNghiem.Add(ctkqxn);

                    testResults.Add(testResult);
                
                }
            }
            return  testResults;
        }

        #endregion Methods


        public string getEqual(string str)
        {
            throw new NotImplementedException();
        }
    }
}