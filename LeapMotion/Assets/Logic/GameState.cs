namespace Assets.Logic
{
    public class GameState
    {
        public int PlayerOneWinCount { get; set; }
        public int PlayerTwoWinCount { get; set; }

        public bool GameIsFinished { get; set; }
        public string WinnerName { get; set; }
    }
}