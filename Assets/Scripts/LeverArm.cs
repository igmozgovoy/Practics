using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverArm : MonoBehaviour
{
    [SerializeField] private Animator animator;
    

    private Finish _finish;
    void Start()
    {
        _finish = GameObject.FindGameObjectWithTag("Finish").GetComponent<Finish>();
    }

    public void ActivateLeverArm()
    {
        Debug.Log("124r23q4");
        animator.SetTrigger("LeverArmOn");
        _finish.Activate();
    }
}
