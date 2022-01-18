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

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public float HealthPoints{

        get{
            return healthPoints;
        }

        set{
            healthPoints = value;

            if(healthPoints <= 0){
                //TODO: gestionar la muerte del personaje / enemigo
            }
        }
    }

    [SerializeField]
    private float healthPoints = 100.0f;
}
