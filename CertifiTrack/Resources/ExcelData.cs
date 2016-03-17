using CertifiTrack.Properties;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace CertifiTrack
{
    class ExcelData
    {
        public static List<DeathCertificate> GetCertificates(string filePath)
        {
            List<DeathCertificate> certList = new List<DeathCertificate>();

            ExcelPackage package = new ExcelPackage();

            FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            package.Load(file);

            ExcelWorksheet worksheet = package.Workbook.Worksheets["2016 DC Info"];

            certList.Clear();

            for (var row = 3; row <= worksheet.Dimension.End.Row; row++)
            {
                if (worksheet.Cells[row, 1].Value != null)
                {
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

                    if ((cert._Notes != null) && ((cert._Notes.ToString().Contains("Done")) || (cert._Notes.ToString().Contains("Out of State")) || (cert._Notes.ToString().Contains("Rental")) || (cert._Notes.ToString().Contains("No DC"))))
                    {
                            
                    }
                    else
                    {
                        certList.Add(cert);
                    }
                }
            }

            package.Dispose();

            return certList;
            
        }

        public static string FormatDisplayString(string date, string name, string status, bool isApproved, bool isElectronic, string doctor)
        {
            string text = "";

            for (var i = 0; i < 150; i++)
            {
                text += " ";
            }

            string approved;
            string dcType;

            if (isApproved)
            {
                approved = "Y";
            }
            else
            {
                approved = "N";
            }

            if (isElectronic)
            {
                dcType = "E";
            }
            else
            {
                dcType = "P";
            }

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
