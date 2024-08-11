using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float InitialHealth;
    public float currentHealth;


    private void Awake()
    {
        currentHealth = InitialHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if(currentHealth <0)
        {
            DestroyEnemy();
        }
    }

    void DestroyEnemy()
    {
        EnemyEvents.RaiseEnemyKilledEvent(GetComponent<EnemyData>());

        Destroy(gameObject);
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        EnemyEvents.RaiseEnenmyDamagedEvent(this, damage);
        //DisplaydamageNumbers(damage);
    }

    void DisplaydamageNumbers(int num)
    {
        //distance from object center to base
        float dist = Mathf.Abs(Vector3.Distance(transform.position, GetComponent<EnemyData>().Base.position));
        Vector3 offset = new Vector3(0f,dist,0f);
        DynamicTextManager.CreateText(transform.position + offset, num.ToString(), DynamicTextManager.defaultData);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
    /* private void OnDestroy()
     {
         Currency.AddCurrency(GetComponent<EnemyData>().CurrencyafterDeath);
     }*/
}
