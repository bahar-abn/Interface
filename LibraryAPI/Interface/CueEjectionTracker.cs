
namespace LibraryAPI.Interface
{
    public class CueEjectionTracker : ICueEjectionTracker
    {
        private int totalCueEjects = 0;

        public void EjectCue()
        {
            totalCueEjects++;
        }

        public int GetTotalCueEjects()
        {
            return totalCueEjects;
        }
    }



}
