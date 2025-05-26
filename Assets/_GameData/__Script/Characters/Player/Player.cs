using UnityEngine;

namespace Characters.Player
{
    public class Player : Person
    {
        private float experience = 0f;
        public float Experience { get => experience; }

        internal override void ShowState()
        {
            Debug.Log(Name);
            Debug.Log(experience);
        }
    }
}
