using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType
{
    Physical,
    Fire,
    Ice,
    Lightning,
    Poison,
}

public class Damage : MonoBehaviour
{
    public float damage;
    [SerializeField] DamageType myType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag == "Player")
    //    {
    //        collision.GetComponent<SlimeStats>().DealDamage(damage, myType);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<SlimeStats>().DealDamage(damage, myType);
        }
    }
}
