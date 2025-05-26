using UnityEngine;
using UnityEngine.SceneManagement;

namespace Characters.Player
{
    public class Player : Person
    {
        internal static float Experience => 0f;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.name == "Dragon")
            {
                Health -= 30;
                if (Health <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }

        internal override void ShowState()
        {
            Debug.Log(Name);
            Debug.Log(Experience);
        }

        internal override void TakeDamage(int damageValue)
        {
            Debug.Log($"My name is {Name}: After hitting with force: {damageValue} I have {Health} health");
        }
    }
}
