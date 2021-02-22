using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float walkDistance = 6f;
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float timeToWait = 5f;
    [SerializeField] private float timeToChase = 3f;
    [SerializeField] private float minDistanceToPlayer = 1.5f;

    private Rigidbody2D _rb;
    private Transform _playerTransform;
    private Vector2 _leftBoundaryPosition;
    private Vector2 _rightBoundaryPosition;
    private Vector2 _nextPoint;

    private bool _isFacingRight = true;
    private bool _isWait = false;
    private float _waitTime;
    private float _chaseTime;
    private bool _isChasingPlayer = false;
    
    public bool IsFacingRight => _isFacingRight;

    public void StartChasingPlayer()
    {
        _isChasingPlayer = true;
    }

    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        _leftBoundaryPosition = transform.position;
        _rightBoundaryPosition = _leftBoundaryPosition + Vector2.right * walkDistance;
        _waitTime = timeToWait;
        _chaseTime = timeToChase;
    }

    void Update()
    {
        if (_isChasingPlayer)
            StartChasingTimer();

        if (_isWait && !_isChasingPlayer)
            StartWaitTimer();

        if (ShouldWait())
            _isWait = true;
    }

    void FixedUpdate()
    {
        _nextPoint = Vector2.right * walkSpeed * Time.fixedDeltaTime;

        if (_isChasingPlayer && Mathf.Abs(DistanceToPlayer()) < minDistanceToPlayer)
            return;

        if (_isChasingPlayer)
            ChasePleyer();

        if (!_isWait && !_isChasingPlayer)
            Patrol();
    }

    void Patrol()
    {
        if (!_isFacingRight)
            _nextPoint.x *= -1;
        _rb.MovePosition((Vector2)transform.position + _nextPoint);  // fixedDeltaTime?
    }
    void ChasePleyer()
    {
        float distance = DistanceToPlayer();

        if (distance < 0)
            _nextPoint *= -1;

        if (distance > 0.2f && !_isFacingRight)
            Flip();
        else if (distance < 0f && _isFacingRight)
            Flip();

        _rb.MovePosition((Vector2)transform.position + _nextPoint);
    }
    float DistanceToPlayer()
    {
        return _playerTransform.position.x - transform.position.x;
    }
    // Работа с подсказками
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_leftBoundaryPosition, _rightBoundaryPosition);
    }

    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    void StartWaitTimer()
    {
        _waitTime -= Time.deltaTime;
        if (_waitTime < 0f)
        {
            _waitTime = timeToWait;
            _isWait = false;
            Flip();
        }
    }

    void StartChasingTimer()
    {
        _chaseTime -= Time.deltaTime;
        if (_chaseTime < 0f)
        {
            _isChasingPlayer = false;
            _chaseTime = timeToChase;
        }
    }
    
    bool ShouldWait()
    {
        bool isOutOfRightBoundary = _isFacingRight && transform.position.x >= _rightBoundaryPosition.x;  // враг выходит за правую границу
        bool isOutOfLeftBoundary = !_isFacingRight && transform.position.x <= _leftBoundaryPosition.x;   // враг выходит за левую границу 
        return isOutOfRightBoundary || isOutOfLeftBoundary;
    }

    


}
