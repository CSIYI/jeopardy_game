using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;

    public static class GameDataManager
    {
        private static string SubFolderName = "Save";
        private static string SaveFileName = "Test.json";
 
        private static string FileName { get { return Path.Combine(FolderName, SaveFileName);} }
        private static string FolderName { get { return Path.Combine(Application.persistentDataPath, SubFolderName); } }

        public static void InitDemo()
        {
            GameData.Init(6, 5);
            for (int i = 0; i < 6; i++)
            {
                GameData.Category[i].Category = "Test Category S" + i;
                GameData.DoubleCategory[i].Category = "Test Category D" + i;
                for (int j = 0; j < 5; j++)
                {
                    GameData.Question[i][j].Question = "Test Question " + i + "-" +  j;
                    GameData.Question[i][j].Answer = "Test Answer";
                    GameData.Question[i][j].Clue = "Test Clue";
                    GameData.Question[i][j].Value = i * 100 + 100;
                    GameData.Question[i][j].isDouble = false;
                    
                    GameData.DoubleQuestion[i][j].Question = "Test Question D" + i + "-" +  j;
                    GameData.DoubleQuestion[i][j].Answer = "Test Answer";
                    GameData.DoubleQuestion[i][j].Clue = "Test Clue";
                    GameData.DoubleQuestion[i][j].Value = (i * 100 + 100)*2;
                    GameData.DoubleQuestion[i][j].isDouble = false;

                    if(i == 0 && j == 0)
                    {
                       GameData.Question[i][j].isDouble = true;
                       GameData.DoubleQuestion[i][j].isDouble = true;

                    }
                 }
            }

            GameData.FinalCategory.Category = "Final Category";

            for (int i = 0; i < 10; i++)
            {
                GameData.RedTeam[i] = "RedTeam " + i;
                GameData.BlueTeam[i] = "BlueTeam " + i;
            }

            GameData.GameName = "TestGame";
        }
        
        public static void LoadData() {
            Debug.Log(FileName);
            Debug.Log(FolderName);

            if(!Directory.Exists(FolderName)) {
                Directory.CreateDirectory(FolderName);
            }
            
            if(File.Exists(FileName)) {
                FileStream fs = new FileStream(FileName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                JsonData data = JsonMapper.ToObject(sr.ReadToEnd());
                int row = (int) data["Row"];
                int col = (int) data["Column"];
                GameData.Init(col, row);
                
                GameData.BlueTeam = JsonMapper.ToObject<List<string>>(data["BlueTeam"].ToJson());
                GameData.RedTeam = JsonMapper.ToObject<List<string>>(data["RedTeam"].ToJson());

                GameData.Category = JsonMapper.ToObject<List<JCategory>>(data["Category"].ToJson());
                GameData.DoubleCategory = JsonMapper.ToObject<List<JCategory>>(data["DoubleCategory"].ToJson());
                GameData.Question = JsonMapper.ToObject<List<List<JQuestion>>>(data["Question"].ToJson());
                GameData.DoubleQuestion = JsonMapper.ToObject<List<List<JQuestion>>>(data["DoubleQuestion"].ToJson());
 
                GameData.FinalCategory = JsonMapper.ToObject<JCategory>(data["FinalCategory"].ToJson());
                GameData.FinalQuestion = JsonMapper.ToObject<JQuestion>(data["FinalQuestion"].ToJson());
                
                fs.Close();
                sr.Close();
            }
   
        }
        
        public static void SaveData() {
            Dictionary<string, object> gamedata = new Dictionary<string, object>();
            foreach (var info in typeof(GameData).GetProperties())
            {
                gamedata.Add(info.Name, info.GetValue(null, null));
            }
            
            string values = JsonMapper.ToJson(gamedata);
            Debug.Log(values);
            
            if(!Directory.Exists(FolderName)) {
                Directory.CreateDirectory(FolderName);
            }

            SaveFileName = GameData.GameName;
            FileStream file = new FileStream(FileName, FileMode.Create);
            byte[] bts = System.Text.Encoding.UTF8.GetBytes(values);
            file.Write(bts,0,bts.Length);
            if(file != null) {
                file.Close();
            }
        }
    }