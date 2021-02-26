﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float totalHealth = 100f;
    [SerializeField] private Animator _animator;

    private float _health;

    void Start()
    {
        _health = totalHealth;
        InitHealth();
    }


    public void ReduceHealth(float damage)
    {
        _health -= damage;
        InitHealth();
        _animator.SetTrigger("takeDamage");
        if (_health <= 0)
            Die();
    }

    void InitHealth()
    {
        healthSlider.value = _health / totalHealth;
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
