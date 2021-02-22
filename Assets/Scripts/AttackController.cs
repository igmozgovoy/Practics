using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool _isAttack = false;

    public bool IsAttack => _isAttack;

    public void FinishAttack()
    {
        _isAttack = false;
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isAttack = true;
            animator.SetTrigger("attack");
        }
    }
}
