using System;

namespace Data
{
    [System.Serializable]
    public class Player
    {
        public string playerName;
        public int goldMedals;
        public int silverMedals;
        public int bronzeMedals;
        public int participationMedals;
        public bool computer = false;
    }
}
