using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ToDo.Model
{
    class ListBoxLeft
    {
        private static List<string> AddListItems()
        {
            List<string> outListItems = new List<string>();
            outListItems.Add("Важно");
            outListItems.Add("Задачи");
            outListItems.Add("ДЗ");
            outListItems.Add("Просто сделай это");
            outListItems.Add("По важности");
            outListItems.Add("Конспекты");

            return outListItems;
        }

        static string Path = "Setting.json";
        public ListBoxLeft Read()
        {
            if (File.Exists(Path))
            {
                string json;
                using (StreamReader sr = new StreamReader(Path))
                {
                    json = sr.ReadToEnd();
                }
                return JsonSerializer.Deserialize<ListBoxLeft>(json);
            }
            else
                return new ListBoxLeft();
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(this);
            using (StreamWriter sw = new StreamWriter(Path))
            {
                sw.WriteLine(json);
            }
        }

        public List<string> listItems = AddListItems();
    }
}
