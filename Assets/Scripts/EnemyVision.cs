using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private GameObject currentHitobject;
    [SerializeField] private float circleRadius;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerMask;

    private Vector2 _origin;        // точка окружности
    private Vector2 _direction;     // направление
    private EnemyController _enemyController;

    private float _currentHitDistance;      
    
    
    
    void Start()
    {
        _enemyController = GetComponent<EnemyController>();
    }

    void Update()
    {
        _origin = transform.position;

        if (_enemyController.IsFacingRight)
            _direction = Vector2.right;
        else
            _direction = Vector2.left;

        RaycastHit2D hit = Physics2D.CircleCast(_origin, circleRadius, _direction, maxDistance, layerMask);

        if (hit)
        {
            currentHitobject = hit.transform.gameObject;        //Игровой объект который столкнулся с hit
            _currentHitDistance = hit.distance;
            if (currentHitobject.CompareTag("Player"))
            {
                _enemyController.StartChasingPlayer();   
            }
        } else
        {
            currentHitobject = null;
            _currentHitDistance = maxDistance;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_origin, _origin + _direction * _currentHitDistance);
        Gizmos.DrawWireSphere(_origin + _direction * _currentHitDistance, circleRadius);
    }
}
