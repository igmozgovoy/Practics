﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    private Animator _animator;



    public void ReduceHealth(float damage)
    {
        health -= damage;
        _animator.SetTrigger("takeDamage");
        if (health <= 0)
            Die();
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
