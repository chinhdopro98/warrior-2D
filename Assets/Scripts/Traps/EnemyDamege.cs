using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamege : MonoBehaviour
{
    [SerializeField] protected float damege;

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag  == "Player"){
            collider.GetComponent<Health>().TakeDamage(damege);
        }
    }
}
