using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedX = 1f; // Благодаря этому, поле появится в Scripte Unity
    [SerializeField] private Animator animator;

    private Rigidbody2D _rb;
    private Finish _finish;
    private LeverArm _leverArm;
    

    private float _horizontal = 0f;

    private bool _isGround = false;
    private bool _isJump = false;
    private bool _isFacingRight = true;
    private bool _isFinish = false;
    private bool _isLeverArm = false;
    
    const float speedXMultiplier = 100f; 

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();     // Ищет только у объекта Finish
        _leverArm = FindObjectOfType<LeverArm>();                                        // Ищет по всей сцене
    }

    // Эта функция вызывается каждый кадр.
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal"); // -1 : 1 

        animator.SetFloat("speedX", Mathf.Abs(_horizontal));

        if (Input.GetKey(KeyCode.W) && _isGround)
            _isJump = true;

        if (Input.GetKeyUp(KeyCode.F))
        {
            if (_isFinish)
                _finish.FinishLevel();                           // Убираем объект со сцены    
            if (_isLeverArm)
                _leverArm.ActivateLeverArm();
        }
    }

    // Эта функция вызывается 1 раз в заданный интервал(у меня 0.02 сек)
    void FixedUpdate()
    {
        _rb.velocity = new Vector2(_horizontal * speedX * speedXMultiplier * Time.fixedDeltaTime, _rb.velocity.y);     // fixedDeltaTime ?
        
        // Прыжок
        if (_isJump)
        {
            _rb.AddForce(new Vector2(0f, 450f));
            _isGround = false;
            _isJump = false;
        }

        // Напраяление взгляда персонажа
        if (_horizontal > 0f && !_isFacingRight)
            Flip();
        else if (_horizontal < 0f && _isFacingRight)
            Flip();

    }

    // Изменение значения scale для разворота 
    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
            _isGround = true;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        LeverArm leverArmTemp = other.GetComponent<LeverArm>();

        if (other.CompareTag("Finish"))
           _isFinish = true;

        if (leverArmTemp != null)
        {
            Debug.Log("LeverArm Worked");
            _isLeverArm = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        LeverArm leverArmTemp = other.GetComponent<LeverArm>();

        if (other.CompareTag("Finish"))
            _isFinish = false;

        if (leverArmTemp != null)
        {
            _isLeverArm = false;
        }
    } 
   
}
