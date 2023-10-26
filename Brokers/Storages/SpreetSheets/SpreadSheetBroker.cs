//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using OfficeOpenXml;
using Tarteeb.Importer.Models.Clients;

namespace Tarteeb.Importer.Brokers.Storages.SpreetSheets
{
    internal class SpreadSheetBroker
    {
        internal async Task SaveToExcel(FileInfo fileInfo, params Client[] clients)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using ExcelPackage package = new ExcelPackage(fileInfo);

            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Mai");


            worksheet.Cells["A1"].LoadFromCollection(clients, true, OfficeOpenXml.Table.TableStyles.Medium1);

            await package.SaveAsync();

        }
    }
}
