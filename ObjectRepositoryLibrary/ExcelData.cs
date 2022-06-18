using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ObjectRepositoryLibrary
{
    public class ExcelData
    {

       static Excel.Application xlApp;

        static Excel.Workbook xlWorkBook;

        static Excel.Worksheet xlWorkSheet;

       static Excel.Range x1range;

        /// <summary>
        /// Get the Excel Data
        /// </summary>
        /// <returns></returns>
        public static string[,] getData()
        {            
            string[,] data=new string[8,3];            
            xlApp = new Excel.Application();           

            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\GlintsMailBoxFrameWork\\bin\\Debug\\", "");
            string path2 = path1 + "\\ObjectRepositoryLibrary\\TestData\\RegisterInputs.xlsx";
            xlWorkBook = xlApp.Workbooks.Open(path2);     
           xlWorkSheet = xlWorkBook.Sheets[1];
            x1range = xlWorkSheet.UsedRange;
            int noOfRows = x1range.Rows.Count;
            int noOfCols = x1range.Columns.Count;           
            try
            {
                for ( int rCnt = 1; rCnt <= noOfRows; rCnt++)
                {
                    for ( int cCnt = 1; cCnt <= noOfCols; cCnt++)
                    {
                        data[rCnt, cCnt] = (string)(x1range.Cells[rCnt, cCnt] as Excel.Range).Value2;
                        if (data[rCnt, cCnt].ToString().Contains("Mob "))
                        {
                            string[] phone = data[rCnt, cCnt].ToString().Split(' ');
                            data[rCnt, cCnt] = phone[1];
                        }

                    }

                }
            }
            catch (Exception ex) {  }
            finally { xlApp.Quit(); }
            
            return data;
        }
    }
}
