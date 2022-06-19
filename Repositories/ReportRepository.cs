using System;
using System.Collections.Generic;
using System.IO;
using TravelAgencyCRM.Models;
using Word = Microsoft.Office.Interop.Word;

namespace TravelAgencyCRM.Repositories
{
    public static class ReportRepository
    {
        private static AgencyModel model = new AgencyModel();
        public static void ContractPeriod(List<Track> tracks,DateTime start,DateTime end)
        {
            var application = new Word.Application();
            Word.Document document = application.Documents.Open(Environment.CurrentDirectory + @"\Шаблон1.docx");
            document.Bookmarks["start"].Select();
            application.Selection.TypeText($"{start:dd.MM.yyyy}");
            document.Bookmarks["end"].Select();
            application.Selection.TypeText($"{end:dd.MM.yyyy}");
            int total = 0;

            var dataRange = document.Bookmarks["reportTable"].Range;
            Word.Paragraph tableparag = document.Paragraphs.Add();
            Word.Range tablerange = dataRange;
            Word.Table WardsTable = document.Tables.Add(tablerange, tracks.Count + 1, 6);
            WardsTable.Borders.InsideLineStyle = WardsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            Word.Range cellrange;
            cellrange = WardsTable.Cell(1, 1).Range;
            cellrange.Text = "№ договора";

            cellrange = WardsTable.Cell(1, 2).Range;
            cellrange.Text = "Имя сотрудника";

            cellrange = WardsTable.Cell(1, 3).Range;
            cellrange.Text = "Имя клиента";

            cellrange = WardsTable.Cell(1, 4).Range;
            cellrange.Text = "Город тура";

            cellrange = WardsTable.Cell(1, 5).Range;
            cellrange.Text = "Дата заключения";

            cellrange = WardsTable.Cell(1, 6).Range;
            cellrange.Text = "Сумма";
            
            WardsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            int j = 0;
            for (int i = 2; i < tracks.Count + 2; i++)
            {
                WardsTable.Cell(i, 1).Range.Text = tracks[j].ID.ToString();
                WardsTable.Cell(i, 2).Range.Text = tracks[j].Staff.FullName;
                WardsTable.Cell(i, 3).Range.Text = tracks[j].Clients.FullName;
                WardsTable.Cell(i, 4).Range.Text = tracks[j].Tours.City;
                WardsTable.Cell(i, 5).Range.Text = (tracks[j].ContractDate).Value.Date.ToShortDateString();
                WardsTable.Cell(i, 6).Range.Text = tracks[j].TotalCost.ToString();
                total += (int)tracks[j].TotalCost;
                j++;
            }
            document.Bookmarks["total"].Select();
            application.Selection.TypeText($"{total}");
            application.Visible = true;

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\Отчёты"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\Отчёты");
            }
            document.SaveAs2(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\Отчёты\\Отчёт о продажах за период {start:dd.MM.yyyy}-{end:dd.MM.yyyy} сформирован {DateTime.Now:dd.MM.yyyy}.docx");
        }
        public static void ContractPeriodStaff(List<Track> tracks,Staff staff, DateTime start, DateTime end)
        {
            var application = new Word.Application();
            Word.Document document = application.Documents.Open(Environment.CurrentDirectory + @"\Шаблон2.docx");
            document.Bookmarks["start"].Select();
            application.Selection.TypeText($"{start:dd.MM.yyyy}");
            document.Bookmarks["end"].Select();
            application.Selection.TypeText($"{end:dd.MM.yyyy}");
            document.Bookmarks["staff"].Select();
            application.Selection.TypeText($"{staff.FullName}");
            int total = 0;

            var dataRange = document.Bookmarks["reportTable"].Range;
            Word.Paragraph tableparag = document.Paragraphs.Add();
            Word.Range tablerange = dataRange;
            Word.Table WardsTable = document.Tables.Add(tablerange, tracks.Count + 1, 5);
            WardsTable.Borders.InsideLineStyle = WardsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            Word.Range cellrange;
            cellrange = WardsTable.Cell(1, 1).Range;
            cellrange.Text = "№ договора";

            cellrange = WardsTable.Cell(1, 2).Range;
            cellrange.Text = "Имя клиента";

            cellrange = WardsTable.Cell(1, 3).Range;
            cellrange.Text = "Город тура";

            cellrange = WardsTable.Cell(1, 4).Range;
            cellrange.Text = "Дата заключения";

            cellrange = WardsTable.Cell(1, 5).Range;
            cellrange.Text = "Сумма";

            WardsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            int j = 0;
            for (int i = 2; i < tracks.Count + 2; i++)
            {
                WardsTable.Cell(i, 1).Range.Text = tracks[j].ID.ToString();
                WardsTable.Cell(i, 2).Range.Text = tracks[j].Clients.FullName;
                WardsTable.Cell(i, 3).Range.Text = tracks[j].Tours.City;
                WardsTable.Cell(i, 4).Range.Text = (tracks[j].ContractDate).Value.Date.ToShortDateString();
                WardsTable.Cell(i, 5).Range.Text = tracks[j].TotalCost.ToString();
                total += (int)tracks[j].TotalCost;
                j++;
            }
            document.Bookmarks["total"].Select();
            application.Selection.TypeText($"{total}");
            application.Visible = true;

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\Отчёты"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\Отчёты");
            }
            document.SaveAs2(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\Отчёты\\Отчёт о продажах {staff.FullName} за период {start:dd.MM.yyyy}-{end:dd.MM.yyyy} сформирован {DateTime.Now:dd.MM.yyyy}.docx");
        }
    }
}