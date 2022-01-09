using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;

    void Start(){
       // Slider.transform.position = new Vector3(1.15f,3.0f,0.0f);
        
    }

    public void SetHealth(float health, float maxHealth){
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low,High, Slider.normalizedValue);

    }
    void Update()
    {
        //Debug.Log(transform.position);
       // Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
