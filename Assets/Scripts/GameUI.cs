using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Base class for all UI components

public class GameUI : MonoBehaviour
{
    public Image healthSprite;
    public GameObject healthParent;

    public void UpdateHealthUI(int changeAmount)
    {
        if (changeAmount < 0)
        {
            // Destroy will remove the GameObject from the hierarchy
            Destroy(healthParent.transform.GetChild(healthParent.transform.childCount - 1).gameObject);
        }
        else
        {
            // Instantiate will create a new GameObject
            Instantiate(healthSprite, healthParent.transform);
        }
    }
}
