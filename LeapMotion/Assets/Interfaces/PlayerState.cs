namespace Assets.Interfaces
{
    public class PlayerState
    {
        public Gesture CurrentGesture { get; set; }
        public bool HasChosenState { get; set; }
        public int TimesTried { get; set; } //wie oft rauf und runter
    }
}