using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private Slider healthSlider; 
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource hurtSound;
    [SerializeField] private float totalHealth = 200f;
    
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
        animator.SetTrigger("takeDamage");
        hurtSound.Play();
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
        gameOverCanvas.SetActive(true);
    }
}
