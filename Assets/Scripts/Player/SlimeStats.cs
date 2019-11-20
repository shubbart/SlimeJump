using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStats : MonoBehaviour
{
    static public SlimeStats insance;
    [Header("Base Stats")]
    public float health;
    // Defense = physical, MagicDefense is base magical protection, Elemental defenses are magic defense multipliers
    public float jumpForce, defense, magicDefense, fireDefense, iceDefense, lightningDefense, poisonDefense;
    [Header("Modifiers")]
    public float jumpForceModifier = 1;
    public float healthModifier = 1, defenseModifier = 1, mDefenseModifier = 1, fDefenseModifier = 1, iDefenseModifier = 1, lDefenseModifier = 1, pDefenseModifier = 1;

    void Awake()
    {
        if (!insance)
            insance = this;
        else
            Destroy(gameObject);
    }


    void Update()
    {
        
    }

    public void DealDamage(float damage, DamageType damageType)
    {       
        switch(damageType)
        {
            case DamageType.Physical:                      
                if (CalculatePhysicalDamage(damage) > 1)
                    health -= CalculatePhysicalDamage(damage);
                else
                    health -= 1;
                break;
            case DamageType.Fire:        
                if (CalculateFireDamage(damage) > 1)
                    health -= CalculateFireDamage(damage);
                else
                    health -= 1;
                break;
            case DamageType.Ice:
                if (CalculateIceDamage(damage) > 1)
                    health -= CalculateIceDamage(damage);
                else
                    health -= 1;
                break;
            case DamageType.Lightning:
                if (CalculateLightningDamage(damage) > 1)
                    health -= CalculateLightningDamage(damage);
                else
                    health -= 1;
                break;
            case DamageType.Poison:
                if (CalculatePoisonDamage(damage) > 1)
                    health -= CalculatePoisonDamage(damage);
                else
                    health -= 1;
                break;
        }


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
        return damage - (defense * defenseModifier);
    }

    float CalculateFireDamage(float damage)
    {
        return damage - (fireDefense * fDefenseModifier) * (magicDefense * mDefenseModifier);
    }

    float CalculateIceDamage(float damage)
    {
        return damage - (iceDefense * iDefenseModifier) * (magicDefense * mDefenseModifier);
    }

    float CalculateLightningDamage(float damage)
    {
        return damage - (lightningDefense * lDefenseModifier) * (magicDefense * mDefenseModifier);
    }

    float CalculatePoisonDamage(float damage)
    {
        return damage - (poisonDefense * pDefenseModifier) * (magicDefense * mDefenseModifier);
    }
}
