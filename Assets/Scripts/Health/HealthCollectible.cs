using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Health sound")]
    [SerializeField] private AudioClip healthSound;
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().plusHealth(healthValue);
            SoundManager.instance.PlaySound(healthSound);
            gameObject.SetActive(false);
        }
    }
}
