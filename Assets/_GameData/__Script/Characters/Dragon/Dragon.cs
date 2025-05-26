using System;
using UnityEngine;

namespace Characters.Dragon
{
    public class Dragon : Person
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.name == "Hand")
            {
                int damage = 40;
                Health -= damage;
                TakeDamage(damage);
                if (Health <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }

        internal override void TakeDamage(int damageValue)
        {
            Debug.Log($"I, the mighty dragon, have lost: {damageValue} hit-points from a hunter's shot");
        }
    }
}
