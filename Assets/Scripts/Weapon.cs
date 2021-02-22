using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float damage = 20f;


    private AttackController _attackController;

    void Start()
    {
        _attackController = transform.root.GetComponent<AttackController>();
    }


    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null && _attackController.IsAttack)
        {
            enemyHealth.ReduceHealth(damage);
        }
    }
}
