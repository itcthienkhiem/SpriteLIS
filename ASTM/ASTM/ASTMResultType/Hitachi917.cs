namespace ASTM.ASTMInterface
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Hitachi917 : IResultType
    {
        #region Methods

        public List<object> getResult(object results)
        {
            List<object> testResults = new List<object>();

            foreach (var data in (List<string>)results)
            {
                String result = data;
                string[] strArr = result.Split('\r');
                string lastResult = string.Empty;
                strArr[0] = string.Format("{0}{1}", lastResult, strArr[0]);
                for (int i = 0; i < strArr.Length - 1; i++)
                {
                    result = strArr[i];
                    int istart = result.IndexOf('\x02');
                    int iEnd = result.IndexOf('\x03');
                    if (istart != 0) continue;
                    if (istart < 0 || iEnd < 0) continue;

                    TestResult_Hitachi917 testResult = new TestResult_Hitachi917();
                    testResult.STX = result[0];
                    testResult.Receiver = result[1];
                    testResult.Sender = result[2];
                    testResult.PakageNum = result[3];
                    testResult.Frame = result[4];
                    testResult.FunctionCode = result[5];
                    testResult.SampleClass = result[6];
                    testResult.SampleNum = result.Substring(7, 5);
                    testResult.DiskNum = result.Substring(12, 5);
                    testResult.PositionNum = result.Substring(17, 3);
                    testResult.SampleCup = result.Substring(20, 1);
                    testResult.IDNum = result.Substring(21, 13);
                    testResult.Age = result.Substring(34, 3);
                    testResult.AgeUnit = result.Substring(37, 1);
                    testResult.Sex = result.Substring(38, 1);
                    testResult.CollectionDate = result.Substring(39, 6);
                    testResult.CollectionTime = result.Substring(45, 4);
                    testResult.OperatorID = result.Substring(49, 6);
                    int resultCount = Convert.ToInt32(result.Substring(55, 3));

                    for (int j = 0; j < resultCount; j++)
                    {
                        Result_Hitachi917 r = new Result_Hitachi917();

                        r.TestNum = Convert.ToInt32(result.Substring((58 + j * 10), 3));
                        r.Result = result.Substring(61 + j * 10, 6);
                        r.AlarmCode = result.Substring(67 + j * 10, 1);
                        testResult.Results.Add(r);
                    }

                    testResults.Add(testResult);
                }

            }
            return testResults;
        }
        
        #endregion Methods
    }
}