using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public DamageType type = DamageType.enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public float HealthPoints{

        get{
            return healthPoints;
        }

        set{
            healthPoints = value;

            if(healthPoints <= 0){
                //TODO: Manage player/enemies death
            }
        }
    }

    // Allow configuration of health points from editor
    [SerializeField]
    private float healthPoints = 100.0f;
}
