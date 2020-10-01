using System;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class Player
    {
        public const int MAX_MEDALS = 50000000;
        public const int MIN_MEDALS = 0;

        private int gold = 0;
        private int silver = 0;
        private int bronze = 0;
        private int participation = 0;

        public string playerName;
        public int goldMedals{
            get {
                return gold;
            }
            set {
                gold = Mathf.Clamp(value, MIN_MEDALS, MAX_MEDALS);
            }
        }
        public int silverMedals{
            get {
                return silver;
            }
            set {
                silver = Mathf.Clamp(value, MIN_MEDALS, MAX_MEDALS);
            }
        }
        public int bronzeMedals{
            get {
                return bronze;
            }
            set {
                bronze = Mathf.Clamp(value, MIN_MEDALS, MAX_MEDALS);
            }
        }
        public int participationMedals{
            get {
                return participation;
            }
            set {
                participation = Mathf.Clamp(value, MIN_MEDALS, MAX_MEDALS);
            }
        }
        public bool computer = false;
    }
}
