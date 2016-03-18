using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace CertifiTrack.Model {
    internal class ExcelData {
        public static List<DeathCertificate> GetCertificates(string filePath) {
            var certList = new List<DeathCertificate>();

            ExcelPackage package = new ExcelPackage();

            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            package.Load(file);

            ExcelWorksheet worksheet = package.Workbook.Worksheets["2016 DC Info"];

            certList.Clear();

            for (int row = 3; row <= worksheet.Dimension.End.Row; row++) {
                if (worksheet.Cells[row, 1].Value == null) continue;

                DeathCertificate cert = new DeathCertificate(
                    Convert.ToDouble(worksheet.Cells[row, 1].Value),
                    worksheet.Cells[row, 2].Value,
                    worksheet.Cells[row, 3].Value,
                    worksheet.Cells[row, 4].Value,
                    worksheet.Cells[row, 5].Value,
                    worksheet.Cells[row, 6].Value,
                    worksheet.Cells[row, 7].Value,
                    worksheet.Cells[row, 8].Value,
                    worksheet.Cells[row, 9].Value,
                    worksheet.Cells[row, 10].Value,
                    worksheet.Cells[row, 11].Value,
                    worksheet.Cells[row, 12].Value
                    );

                if ((cert.Notes == null) ||
                    (!cert.Notes.Contains("Done") && !cert.Notes.Contains("Out of State") && !cert.Notes.Contains("Rental") &&
                     !cert.Notes.Contains("No DC")))
                    certList.Add(cert);
            }

            package.Dispose();

            return certList;
        }

        public static string FormatDisplayString(string date, string name, string status, bool isApproved, bool isElectronic,
            string doctor) {
            string text = "";

            for (int i = 0; i < 150; i++) {
                text += " ";
            }

            string approved = isApproved ? "Y" : "N";
            string dcType = isElectronic ? "E" : "P";

            text = text.Insert(0, $"{date}");
            text = text.Insert(13, $"{name}");
            text = text.Insert(50, $"{status}");
            text = text.Insert(80, $"{approved}");
            text = text.Insert(90, $"{dcType}");
            text = text.Insert(95, "\n");
            text = text.Insert(109, $"{doctor}");

            return text;
        }
    }
}