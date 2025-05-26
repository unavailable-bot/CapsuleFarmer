using UnityEngine;

namespace Characters
{
    public abstract class Person : MonoBehaviour
    {
        private float health = 100f;
        internal static string Name => "Farmer Grisha";

        internal float Health
        {
            get => health;
            set => CalculateHealth(value);
        }

        private void CalculateHealth(float value)
        {
            health = value;
            
            if (health <= 0)
            {
                health = 0;
                Debug.Log("No health");
                return;
            }
            
            if (health >= 100)
            {
                health = 100;
                Debug.Log("Health is full");
            }
        }
        
        internal abstract void TakeDamage(int damageValue);

        internal virtual void ShowState()
        {
            Debug.Log(name);
        }
    }
}
