using UnityEngine;

namespace Characters
{
    public class Person : MonoBehaviour
    {
        private float health = 100f;
        private string name = "Farmer Grisha";

        public string Name { get => name; }
        
        public float Health
        {
            get => health;
            set
            {
                GetDamage(value);
            }
        }

        private void GetDamage(float value)
        {
            if (health <= 0)
            {
                health = 0;
                Debug.Log("No health");
                return;
            }
            
            health = value;
            
            if (health >= 100)
            {
                health = 100;
                Debug.Log("Health is full");
            }
        }

        internal virtual void ShowState()
        {
            Debug.Log(name);
        }
    }
}
