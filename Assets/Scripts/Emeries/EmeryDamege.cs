using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmeryDamege : MonoBehaviour
{
    [SerializeField] private float damege;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag  == "Player"){
            collider.GetComponent<Health>().TakeDamage(damege);
        }
    }
}
