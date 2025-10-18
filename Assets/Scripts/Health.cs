using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    float currentHealth, minHealth = 0, maxHealth = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    { 
        return maxHealth; 
    }

    public void ApplyDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth < minHealth)
        {
            currentHealth = minHealth;            
        }

        if (currentHealth == minHealth)
        {
            gameObject.SetActive(false);
        }
    }

    public void ApplyDamage(float damage, GameObject origin)
    {
        currentHealth -= damage;

        if (currentHealth < minHealth)
        {
            currentHealth = minHealth;
        }

        if (currentHealth == minHealth)
        {
            gameObject.SetActive(false);
        }

        SendMessageUpwards("CharacterDamaged", origin);
    }

    public void HealDamage(float damage, GameObject origin)
    {
        currentHealth += damage;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
