using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStats : MonoBehaviour
{

    public float health, jumpForce;
    // Defense = physical, MagicDefense is base magical protection, Elemental defenses are magic defense multipliers
    public float defense, magicDefense, fireDefense, iceDefense, lightningDefense, poisonDefense;

    void Start()
    {
        Debug.Log("Health: " + health);
        GetComponent<SlimeJump>().maxForce = jumpForce;
    }


    void Update()
    {
        
    }

    public void DealDamage(float damage, DamageType damageType)
    {       
        if(damageType == DamageType.Physical)
        {
            if (CalculatePhysicalDamage(damage) > 1)
                health -= CalculatePhysicalDamage(damage);
            else
                health -= 1;
        }
        if (damageType == DamageType.Fire)
        {
            if (CalculateFireDamage(damage) > 1)
                health -= CalculateFireDamage(damage);
            else
                health -= 1;
        }
        if (damageType == DamageType.Ice)
        {
            if (CalculateIceDamage(damage) > 1)
                health -= CalculateIceDamage(damage);
            else
                health -= 1;
        }
        if (damageType == DamageType.Lightning)
        {
            if (CalculateLightningDamage(damage) > 1)
                health -= CalculateLightningDamage(damage);
            else
                health -= 1;
        }
        if (damageType == DamageType.Poison)
        {
            if (CalculatePoisonDamage(damage) > 1)
                health -= CalculatePoisonDamage(damage);
            else
                health -= 1;
        }
        Debug.Log("Health: " + health);

        if (health <= 0)
            DoDeath();
    }

    void DoDeath()
    {
        Debug.Log("Player Died!");
        Destroy(gameObject);
    }

    float CalculatePhysicalDamage(float damage)
    {
        return damage - defense;
    }

    float CalculateFireDamage(float damage)
    {
        return damage - fireDefense * magicDefense;
    }

    float CalculateIceDamage(float damage)
    {
        return damage - iceDefense * magicDefense;
    }

    float CalculateLightningDamage(float damage)
    {
        return damage - lightningDefense * magicDefense;
    }

    float CalculatePoisonDamage(float damage)
    {
        return damage - poisonDefense * magicDefense;
    }
}
