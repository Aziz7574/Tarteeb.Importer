//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using Google.Apis.Sheets.v4.Data;
using OfficeOpenXml;

namespace Tarteeb.Importer
{
    internal class Program
    {
        static async Task Main()
        {
          string path = "D:\\dbExcel.xlsx";

            if (File.Exists(path))
            {
                using SpreadsheetDocument spreadsheet = new  SpreadsheetDocument(path,SpreadsheetDocumentType.Workbook,);
            }
        }


        public static DateTimeOffset CreateRandomTime()
        {
            Random random = new Random();
            int year = random.Next(1940, DateTimeOffset.Now.Year - 1);
            int month = random.Next(1, 12);
            int day = random.Next(1, 30);

            return new DateTime(year, month, day);

        }
    }
}