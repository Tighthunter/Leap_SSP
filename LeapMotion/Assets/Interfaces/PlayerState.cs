namespace Assets.Interfaces
{
    public class PlayerState
    {
        public Gesture CurrentGesture { get; set; }
        public bool HasChosenGesture { get; set; }
        public int TimesTried { get; set; } //wie oft rauf und runter

        public override string ToString()
        {
            return "Gesture: " + (CurrentGesture == null ? null : CurrentGesture.gestureName) + ", HasChosenGesture: " + HasChosenGesture +
                   ", Times tried: " + TimesTried;
        }
    }
}