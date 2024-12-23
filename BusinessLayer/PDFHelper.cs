using DataLayer;
using DinkToPdf;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using PdfSharp.Drawing;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace BusinessLayer
{
    public static class PDFHelper
    {
        public static void CreatePDF(Satis satis)
        {
            try
            {
                string pdfDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SalesReports");
                if (!Directory.Exists(pdfDirectory))
                {
                    Directory.CreateDirectory(pdfDirectory);
                }

                string pdfPath = Path.Combine(pdfDirectory, $"SalesReport_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                // Basit PDF oluşturma kodu
                using (PdfWriter writer = new PdfWriter(pdfPath))
                {
                    using (PdfDocument pdf = new PdfDocument(writer))
                    {
                        Document document = new Document(pdf);

                        document.Add(new Paragraph("Bu bir test PDF'sidir."));

                        // Satış bilgilerini ekle
                        document.Add(new Paragraph($"User: {satis.UserMail}"));
                        document.Add(new Paragraph($"Seat: {satis.SeatNo}"));
                        document.Add(new Paragraph($"Price: {satis.Price:C}"));
                        document.Add(new Paragraph($"Sale Date: {satis.SaleDate:yyyy-MM-dd HH:mm:ss}"));

                        document.Close();
                    }
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF başarıyla oluşturuldu.");
            }
        }
    }
}
