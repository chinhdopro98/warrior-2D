using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOffFlashes;
    private SpriteRenderer spriteRend;

    [Header("Death sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }

    [Header("Components")]
    [SerializeField] private Behaviour[] components;

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }
        else
            if (!dead)
        {
            anim.SetTrigger("die");
            //Player
            // if (GetComponent<PlayerMovement>() != null)
            //     GetComponent<PlayerMovement>().enabled = false;
            // //Enemy
            // if (GetComponentInParent<EnemyPatrol>() != null)
            //     GetComponentInParent<EnemyPatrol>().enabled = false;
            // if (GetComponent<MeleeEnemy>() != null)
            //     GetComponent<MeleeEnemy>().enabled = false;
            foreach (Behaviour component in components)
            {
                component.enabled = false;
            }
            SoundManager.instance.PlaySound(deathSound);
            dead = true;
        }
    }

    public void plusHealth(float _health)
    {
        currentHealth = Mathf.Clamp(currentHealth + _health, 0, startingHealth);
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < numberOffFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOffFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOffFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }
}
