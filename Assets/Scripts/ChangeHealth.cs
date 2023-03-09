using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeHealth : MonoBehaviour
{
    public Player player;
    public Slider slider;
    public Button buttonTreatment;
    public Button buttonDamage;
    public float MinHealth = 0;
    public float MaxHealth = 100;
    public float AmountOfChangePerClick = 10;
    public float TimeForChange = 0.5f;

    public void Start()
    {
        slider.value = player.GetHealth();
    }
    public void Update()
    {
        slider.value = Mathf.MoveTowards(slider.value, player.GetHealth(), TimeForChange);
    }

    public void ChangPlayerHealth(int directionOfChange) 
    {
        float currentHealth = player.GetHealth();
        float playerHealth = currentHealth + AmountOfChangePerClick * directionOfChange;  
        player.Sethealth(playerHealth);
        CompareValueWithLimit(buttonTreatment, MaxHealth);
        CompareValueWithLimit(buttonDamage, MinHealth);
    }

    public void CompareValueWithLimit(Button button, float limitValue) 
    {
        float playerHealth = player.GetHealth();

        if(playerHealth == limitValue)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}   


