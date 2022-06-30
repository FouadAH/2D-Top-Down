using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Image healthSprite;
    public GameObject healthParent;

    public void Damage(int damageAmount) 
    {
        for(int i = 0; i < damageAmount; i++)
        {
            // Destroy will remove the GameObject from the hierarchy
            Destroy(healthParent.transform.GetChild(healthParent.transform.childCount - 1).gameObject);
        }
    }

    public void Heal(int healAmount)
    {
        for (int i = 0; i < healAmount; i++)
        {
            // Instantiate will create a new GameObject
            Instantiate(healthSprite, healthParent.transform);
        }
    }
}
