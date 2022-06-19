using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TravelAgencyCRM.Models;
using Word = Microsoft.Office.Interop.Word;

namespace TravelAgencyCRM.Repositories
{
    public static class TrackRepository
    {
        private static AgencyModel model = new AgencyModel();
        private static List<Clients> wardClients = new List<Clients>();
        public static IEnumerable<Track> GetAllTrack()
        {
            var list = model.Track
                .Where(x => x.IsExists == 1);
            return list;
        }

        public static void AddTrack(Track track)
        {
            model.Track.Add(track);
            Tours tour = model.Tours.Where(x => x.ID == track.TourID).First();
            tour.Tickets -= track.TicketsAmount;
          
            model.Entry(tour).State = System.Data.Entity.EntityState.Modified;
            model.SaveChanges();
        }

        private static bool Ward(Track track)
        {
            if (track.Ward != null)
            {
                string[] wardID = track.Ward.Split('|');
                int id;
                for (int i = 0; i < wardID.Length; i++)
                {
                    if (wardID[i] != "")
                    {
                        id = int.Parse(wardID[i]);
                        var ward = model.Clients.Where(x => x.ID == id).First();
                        wardClients.Add(ward);
                    }
                }
                return true;
            }
            else
                return false;
        }

        public static void FormContract(Track track)
        {
            var application = new Word.Application();
            Word.Document document = application.Documents.Open(Environment.CurrentDirectory + @"\договор.docx");
            document.Bookmarks["Date"].Select();
            application.Selection.TypeText($"{DateTime.Today:dd.MM.yyyy}");
            Staff staff = model.Staff.Where(x => x.ID == track.StaffID).First();
            Clients client = model.Clients.Where(x => x.ID == track.ClientID).First();
            
            // Если в договоре фигурируют дети:
            if (Ward(track))
            {
                document.Bookmarks["Ward1"].Select();
                application.Selection.TypeText($"\n8.3. Турист, берет под свою ответственность граждан, указанных в таблице 1.\nТаблица 1");
                var dataRange = document.Bookmarks["Wards"].Range;
                Word.Paragraph tableparag = document.Paragraphs.Add();
                Word.Range tablerange = dataRange;
                Word.Table WardsTable = document.Tables.Add(tablerange, wardClients.Count + 1, 2);
                WardsTable.Borders.InsideLineStyle = WardsTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                Word.Range cellrange;
                cellrange = WardsTable.Cell(1, 1).Range;
                cellrange.Text = "ФИО";
                cellrange = WardsTable.Cell(1, 2).Range;
                cellrange.Text = "Серия и номер свидетельства о рождении";
                WardsTable.Rows[1].Range.Bold = 1;
                WardsTable.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                int j = 0;
                for (int i = 2; i < wardClients.Count + 2; i++)
                {
                    WardsTable.Cell(i, 1).Range.Text = wardClients[j].FullName;
                    WardsTable.Cell(i, 2).Range.Text = wardClients[j].BirthCertificateNumber;
                    j++;
                    WardsTable.Rows[i].Range.Bold = 0;
                }
            }

            document.Bookmarks["ClientFullName"].Select();
            application.Selection.TypeText($"{client.FullName}");
            document.Bookmarks["ClientFullName2"].Select();
            application.Selection.TypeText($"{client.FullName}");

            document.Bookmarks["ClientAddress"].Select();
            application.Selection.TypeText($"{client.Address}");
            document.Bookmarks["ClientAddress1"].Select();
            application.Selection.TypeText($"{client.Address}");

            document.Bookmarks["ClientMSISDN"].Select();
            application.Selection.TypeText($"{client.Msisdn}");

            document.Bookmarks["ClientPassportS"].Select();
            application.Selection.TypeText($"{client.PassportS}");
            document.Bookmarks["ClientPassportS2"].Select();
            application.Selection.TypeText($"{client.PassportS}");

            document.Bookmarks["ClientPassportN"].Select();
            application.Selection.TypeText($"{client.PassportN}");
            document.Bookmarks["ClientPassportN2"].Select();
            application.Selection.TypeText($"{client.PassportN}");

            document.Bookmarks["ClientPassportWhom"].Select();
            application.Selection.TypeText($"{client.Whom}");
            document.Bookmarks["ClientPassportWhom2"].Select();
            application.Selection.TypeText($"{client.Whom}");

            document.Bookmarks["ClientTakedDay"].Select();
            application.Selection.TypeText($"{client.TakedDay:dd.MM.yyyy}");
            document.Bookmarks["ClientTakedDay2"].Select();
            application.Selection.TypeText($"{client.TakedDay:dd.MM.yyyy}");

            document.Bookmarks["ContractTotalSum"].Select();
            application.Selection.TypeText($"{track.TotalCost}");

            document.Bookmarks["TenProcentFromTotalSum"].Select();
            application.Selection.TypeText($"{track.TotalCost/10}");
            application.Visible = true;

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\Договора"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\Договора");
            }
            //document.SaveAs2(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\Отчёты\\Отчёт о продажах {staff.FullName} за период {start:dd.MM.yyyy}-{end:dd.MM.yyyy} сформирован {DateTime.Now:dd.MM.yyyy}");


            document.SaveAs2(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"\\Договора\\Договор №{track.ID}");
        }
    }
}