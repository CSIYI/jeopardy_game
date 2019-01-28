using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.PlayerLoop;

public class JCategory
{
    public string Category;
}    

    public class JQuestion
    {
        public string Question;
        public string Answer;
        public int Value;
        public string Clue;
        public bool isDouble;
        public string ImgPath;
    }

    public static class GameData
    {
        public static string GameName { get; set; }
        public static int Row { get; private set; }
        public static int Column { get; private set; }
        public static List<JCategory> Category { get; set; }
        public static List<List<JQuestion>> Question { get; set; }
        
        public static List<JCategory> DoubleCategory { get; set; }
        public static List<List<JQuestion>> DoubleQuestion { get; set; }
        public static List<string> BlueTeam { get; set; }
        public static List<string> RedTeam { get; set; }
        public static JCategory FinalCategory { get; set; }
        public static JQuestion FinalQuestion { get; set; }

        static GameData()
        {
            Init(6,5);
        }
       
        public static void Init(int col, int row)
        {
            Row = row;
            Column = col;
            Category = new List<JCategory>();
            Question = new List<List<JQuestion>>();
            
            DoubleCategory = new List<JCategory>();
            DoubleQuestion = new List<List<JQuestion>>();
            BlueTeam = new List<string>();
            RedTeam = new List<string>();
            FinalCategory = new JCategory();
            FinalQuestion = new JQuestion();
            
            for (int i = 0; i < Column; i++)
            {
                Category.Add(new JCategory());
                DoubleCategory.Add(new JCategory());
            }
            
            for (int i = 0; i < 10; i++)
            {
                RedTeam.Add("");
                BlueTeam.Add("");
            }
            
            for (int i = 0; i < Column; i++)
            {
                var qset = new List<JQuestion>();
                for (int j = 0; j < Row; j++)
                {
                    qset.Add(new JQuestion());
                }
                Question.Add(qset);
                
                qset = new List<JQuestion>();
                for (int j = 0; j < Row; j++)
                {
                    qset.Add(new JQuestion());
                }
                DoubleQuestion.Add(qset);
            }

            
        }

    }
    
   