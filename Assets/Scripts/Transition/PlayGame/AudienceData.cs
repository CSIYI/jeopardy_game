using System;
using System.Collections.Generic;

namespace Model
{
    public class AudienceData
    {

        private static AudienceData uniqueInstance;

        private int redScore;
        private int blueScore;

        private int redIndex;
        private int blueIndex;
        private List<string> redTeams;
        private List<string> blueTeams;

        private int addRedScore;
        private int addBlueScore;

        private int questionType; //0 jeo //1 double //3 final 
        private int questionLine;
        private int questionRow;


        private AudienceData()
        {

        }

        public static AudienceData GetInstance()
        {
            if(uniqueInstance == null)
            {
                uniqueInstance = new AudienceData();
            }
            return uniqueInstance;
        }

        public void SetTeamInformation(List<string> redTeams, List<string> blueTeams)
        {
            this.redTeams = redTeams;
            this.blueTeams = blueTeams;
        }


        public void SetTeamsIndex(int redIndex, int blueIndex)
        {
            this.redIndex = redIndex;
            this.blueIndex = blueIndex;
        }

        public void SetTeamsScore(int redScore, int blueScore)
        {
            this.redScore = redScore;
            this.blueScore = blueScore;
        }

        public void SetRedTeamScore(int score)
        {
            this.redScore = score;
        }

        public void SetBlueTeamScore(int score)
        {
            this.blueScore = score;
        }

        public void SetQuestion(int type, int line, int row)
        {
            this.questionType = type;
            this.questionLine = line;
            this.questionRow = row;
        }


        public string GetRedTeamName()
        {
            return redTeams[redIndex];
        }

        public string GetBlueTeamName()
        {
            return blueTeams[blueIndex];
        }

        public int GetRedScore()
        {
            return redScore;
        }

        public int GetBlueScore()
        {
            return blueScore;
        }

        public List<string> GetRedTeams()
        {
            return redTeams;
        }

        public List<string> GetBlueTeams()
        {
            return blueTeams;
        }

        public int GetCurrentRedIndex()
        {
            return redIndex;
        }

        public int GetCurrentBlueIndex()
        {
            return blueIndex;
        }

        public void SetAddRedScore(int score)
        {
            this.addRedScore = score;
        }

        public void SetAddBlueScore(int score)
        {
            this.addBlueScore = score;
        }

        public int GetAddRedScore()
        {
            return addRedScore;
        }

        public int GetAddBlueScore()
        {
            return addBlueScore;
        }

        public int GetQuestionType()
        {
            return questionType;
        }

        public int GetQuestionLine()
        {
            return questionLine;
        }

        public int GetQuestionRow()
        {
            return questionRow;
        }
    }
}
