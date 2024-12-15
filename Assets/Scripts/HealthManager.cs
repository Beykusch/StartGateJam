using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;

    public float healthAmount;
    
    void Start()
    {
        healthAmount = 100;
    }

    // Update is called once per frame
    void Update()
    {


        if (healthAmount <= 0)
        {
            SceneManager.LoadScene("Cyber");
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(5);
        }

        healthBar.fillAmount = healthAmount / 100f;
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
    }
}
