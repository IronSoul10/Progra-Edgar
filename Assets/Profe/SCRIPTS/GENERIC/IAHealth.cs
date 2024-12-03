using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAHealth : MonoBehaviour,IDamageable
{
    [SerializeField, Range(0,100)] private int actualHealth;
    [SerializeField] private int maxHealth;

    [SerializeField] private ParticleSystem blood;
    private Animator animator;
    private GameObject[] drops;

    public void TakeDamage(int damage)
    {
        Debug.Log("El personaje " + name + " recibio daño");
        actualHealth -= damage;

        if (actualHealth < 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("Mataste a " + name);
        Destroy(gameObject);
    }

}