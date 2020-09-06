using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ExemDesignPattern
{
    class TaskReadandWriteModule : Ireadable, IWriteable
    {

        public ObservableCollection<TaskTodo> ReadFromHistoryFile()
        {
            var result = new ObservableCollection<TaskTodo>();
            if (File.Exists("Histor.bin"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream("Histor.bin", FileMode.Open))
                {
                    result = (ObservableCollection<TaskTodo>)bf.Deserialize(fs);
                }
            }
                return result;
        }

        public ObservableCollection<TaskTodo> ReadFromUserFile(string Path)
        {
            var Result = new ObservableCollection<TaskTodo>();
            var text=pdftextExtractor(Path);
            var Sentence = text.Split('\n');
            string name="", Desc="", Tag="", Prior="", Date="", Fin="";
            for (int i = 0; i < Sentence.Length; ++i) {
                if (Sentence[i].Contains("Name of Task : ")) {
                    name = SentenceUnpacking(Sentence[i]);
                }
                else if (Sentence[i].Contains("Description of Task : ")) {
                    Desc = SentenceUnpacking(Sentence[i]);
                }
                else if (Sentence[i].Contains("Tag of Task : ")) {
                    Tag = SentenceUnpacking(Sentence[i]);
                }
                else if (Sentence[i].Contains("Priority Level  of Task : "))
                {
                    Prior = SentenceUnpacking(Sentence[i]);
                }
                else if (Sentence[i].Contains("Due To date : "))
                {
                    Date = SentenceUnpacking(Sentence[i]);
                }
                else if (Sentence[i].Contains("Finished status of Task : "))
                {
                    Fin = SentenceUnpacking(Sentence[i]);
                    var time1 = new DateTime();
                    DateTime.TryParse(Date, out time1);
                    Result.Add(new TaskTodo() { Name = name, Description = Desc, Tag = Tag, Prioriti = int.Parse(Prior), Finished = bool.Parse(Fin), DueTo = time1 });
                    name =Desc = Tag=Prior=Fin=Date = "";
                }
                
            }
            return Result;
        }

        public void WriteTaskListToUserFile(string path, ObservableCollection<TaskTodo> ListofTasks)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();
            doc.AddHeader("TodoList", " ");
            foreach (var task in ListofTasks)
            {
                doc.Add(new iTextSharp.text.Phrase("Name of Task : " + task.Name+"\n"));
                doc.Add(new iTextSharp.text.Phrase("Description of Task : " + task.Description + "\n"));
                doc.Add(new iTextSharp.text.Phrase("Tag of Task : " + task.Tag + "\n"));
                doc.Add(new iTextSharp.text.Phrase("Priority Level  of Task : " + task.Prioriti + "\n"));
                doc.Add(new iTextSharp.text.Phrase("Due To date : " + task.DueTo.ToString("d") + "\n"));
                doc.Add(new iTextSharp.text.Phrase("Finished status of Task : " + task.Finished + "\n"));
                doc.Add(new iTextSharp.text.Phrase("\n"));
            }
            doc.AddAuthor("Dudchak A.V.");
            doc.Close();
            
            


        }

        public void WriteToStoryFile(ObservableCollection<TaskTodo> ListofTasks)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("Histor.bin", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, ListofTasks);

            }
            
        }
        private string pdftextExtractor(string path) {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(path))
            {

                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }

            return text.ToString();

        }
        private string SentenceUnpacking(string Sentence)
        {
            int j = 0;
            bool FindPlace = false;
            string result = string.Empty;
            do
            {
                if (FindPlace)
                {
                    result += Sentence[j];
                }
                if (Sentence[j] == ':')
                {
                    FindPlace = true;
                }
                else if (Sentence[j] == '\n')
                {
                    break;
                }
                j++;
            } while (j < Sentence.Length);
            return result;

        }
    }
}
