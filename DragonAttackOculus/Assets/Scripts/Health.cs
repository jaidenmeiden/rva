using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public DamageType type = DamageType.enemy;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Animator>() != null)
        {
            animator = GetComponent<Animator>();
            animator.SetFloat("health", HealthPoints);
        }
    }
    
    public float HealthPoints{

        get{
            return healthPoints;
        }

        set{
            healthPoints = value;

            if (animator != null)
            {
                animator.SetFloat("health", healthPoints);
            }

            if(healthPoints <= 0){
                // Manage player/enemies death
                GetComponent<Rigidbody>().useGravity = true;
                if (type == DamageType.enemy)
                {
                    Destroy(gameObject, 7.0f);
                }
            }
        }
    }

    // Allow configuration of health points from editor
    [SerializeField]
    private float healthPoints = 100.0f;
}
