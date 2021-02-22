using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private float damage = 10f;
    [SerializeField] private float timeToDamage = 1f;


    private float _timeDamage;
    private bool _isDamage = true;


    void Start()
    {
        _timeDamage = timeToDamage;
    }

    void Update()
    {
        if (!_isDamage)
        {
            _timeDamage -= Time.deltaTime;
            if (_timeDamage < 0f)
            {
                _isDamage = true;
                _timeDamage = timeToDamage;
            }
        }

    }
    void OnCollisionStay2D(Collision2D other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null && _isDamage)
        {
            Debug.Log("HitEnemy");
            playerHealth.ReduceHealth(damage);
            _isDamage = false;
        }
    }




}
