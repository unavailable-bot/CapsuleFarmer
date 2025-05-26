using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Characters.Player
{
    public class Player : Person
    {
        internal static float Experience => 0f;

        private void Start()
        {
            ShowState();
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.name == "Dragon")
            {
                if (other.contacts.Any(contact => contact.thisCollider.name == "Hand"))
                {
                    return;
                }
                
                int damage = 30;
                Health -= damage;
                TakeDamage(damage);
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
