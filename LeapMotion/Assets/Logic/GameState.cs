using System;

namespace Assets.Logic
{
    public class GameState
    {
        public int HumanPlayerWinCount { get; set; }
        public int AiPlayerWinCount { get; set; }

        public bool GameIsFinished { get; set; }
        public bool RoundIsFinished { get; set; }
        public string WinnerName { get; set; }

        public override string ToString()
        {
            var returner = "Human player Win count: " + HumanPlayerWinCount;
            returner += ", Ai Player Win count: " + AiPlayerWinCount;
            returner += ", Is game finished?: " + GameIsFinished;
            returner += ", Winner name: " + WinnerName;
            return returner;
        }
    }
}