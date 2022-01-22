using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BarType
{
    health,
    mana
}
public class MenuBar : MonoBehaviour
{
    Slider _slider;
    public GameObject target;
    public BarType barType;
    
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();

        switch (barType)
        {
            case BarType.health:
                _slider.maxValue = target.GetComponent<Health>().HealthPoints;
                break;
            case BarType.mana:
                _slider.maxValue = Weapons.MAGIC_COOLDOWN_TIME;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (barType)
        {
            case BarType.health:
                _slider.value = target.GetComponent<Health>().HealthPoints;
                break;
            case BarType.mana:
                _slider.value = target.GetComponent<Weapons>().magicCooldown;
                break;
        }
    }
}
