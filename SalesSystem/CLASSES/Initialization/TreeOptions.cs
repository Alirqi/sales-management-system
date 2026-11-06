using System.Collections.Generic;

namespace SalesSystem.CLASSES.Initialization
{
    class TreeOption
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }

        public static List<TreeOption> CreateData()
        {
            List<TreeOption> data = new List<TreeOption>();

            data.Add(new TreeOption() { ID = 1, ParentID = 0, Name = "Appearance" });
            data.Add(new TreeOption() { ID = 2, ParentID = 1, Name = "FontStyle" });
            data.Add(new TreeOption() { ID = 3, ParentID = 1, Name = "ThemeStyle" });
            data.Add(new TreeOption() { ID = 4, ParentID = 1, Name = "ScreenDisplay" });
            data.Add(new TreeOption() { ID = 5, ParentID = 1, Name = "Child 2" });
            data.Add(new TreeOption() { ID = 6, ParentID = 1, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 7, ParentID = 1, Name = "Child 2" });
            data.Add(new TreeOption() { ID = 8, ParentID = 1, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 9, ParentID = 1, Name = "Child 2" });
                         
            data.Add(new TreeOption() { ID = 10, ParentID = 0, Name = "ServerSetting" });
            data.Add(new TreeOption() { ID = 11, ParentID = 10, Name = "SetSetting" });
            data.Add(new TreeOption() { ID = 12, ParentID = 10, Name = "Child 2" });
            data.Add(new TreeOption() { ID = 13, ParentID = 10, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 14, ParentID = 10, Name = "Child 2" });
            data.Add(new TreeOption() { ID = 15, ParentID = 10, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 16, ParentID = 10, Name = "Child 2" });
                         
            data.Add(new TreeOption() { ID = 17, ParentID = 0, Name = "System Informations" });
            data.Add(new TreeOption() { ID = 18, ParentID = 17, Name = "Preparation" });
            data.Add(new TreeOption() { ID = 19, ParentID = 17, Name = "Child 2" });
            data.Add(new TreeOption() { ID = 20, ParentID = 17, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 21, ParentID = 17, Name = "Child 2" });
            data.Add(new TreeOption() { ID = 22, ParentID = 17, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 23, ParentID = 17, Name = "Child 2" });
                         
            data.Add(new TreeOption() { ID = 24, ParentID = 0, Name = "LanguageSettings" });
            data.Add(new TreeOption() { ID = 25, ParentID = 24, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 26, ParentID = 24, Name = "Child 2" });
            data.Add(new TreeOption() { ID = 27, ParentID = 24, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 28, ParentID = 24, Name = "Child 2" });
            data.Add(new TreeOption() { ID = 29, ParentID = 24, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 30, ParentID = 24, Name = "Child 2" });
                         
            data.Add(new TreeOption() { ID = 31, ParentID = 0, Name = "Root3" });
            data.Add(new TreeOption() { ID = 32, ParentID = 31, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 33, ParentID = 31, Name = "Child 2" });
            data.Add(new TreeOption() { ID = 34, ParentID = 31, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 35, ParentID = 31, Name = "Child 2" });
            data.Add(new TreeOption() { ID = 36, ParentID = 31, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 37, ParentID = 31, Name = "Child 2" });
                       
            data.Add(new TreeOption() { ID = 38, ParentID = 0, Name = "Root3" });
            data.Add(new TreeOption() { ID = 39, ParentID = 38, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 40, ParentID = 38, Name = "Child 2" });
            data.Add(new TreeOption() { ID = 41, ParentID = 38, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 42, ParentID = 38, Name = "Child 2" });
            data.Add(new TreeOption() { ID = 43, ParentID = 38, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 44, ParentID = 38, Name = "Child 2" });
            
            data.Add(new TreeOption() { ID = 45, ParentID = 0, Name = "Root3" });
            data.Add(new TreeOption() { ID = 46, ParentID = 45, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 47, ParentID = 45, Name = "Child 2" });
            data.Add(new TreeOption() { ID = 48, ParentID = 45, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 49, ParentID = 45, Name = "Child 2" });
            data.Add(new TreeOption() { ID = 50, ParentID = 45, Name = "Child 1" });
            data.Add(new TreeOption() { ID = 51, ParentID = 45, Name = "Child 2" });

            return data;
        }
    }

}
