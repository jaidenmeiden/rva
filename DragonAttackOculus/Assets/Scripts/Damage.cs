using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType{
    player,
    enemy
}

public class Damage : MonoBehaviour
{
    public DamageType type = DamageType.enemy;
    public float damage = 10.0f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Health>()!= null){
            if(other.GetComponent<Health>().type != type){
                // Damage type that we do is different from who we are damaging
                float currentDamage = damage;

                if(other.GetComponent<Weapons>()!=null){
                    // Another collider carries weapons and shields
                    if(other.GetComponent<Weapons>().shieldActive){
                        // Another collider has the shield activated
                        currentDamage /= 5;
                    }
                }

                other.GetComponent<Health>().HealthPoints -= currentDamage;
            }
        }
    }
}
