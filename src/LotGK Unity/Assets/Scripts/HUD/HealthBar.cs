using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
 //When the player takes damage, it calls the SetHealth() function from this class
 //to update the HUD healthbar.   
    public void SetHealth(int health) {

        slider.value = health;
    }
}
