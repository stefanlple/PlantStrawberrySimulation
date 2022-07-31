using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamStateSetter : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetState(int i)
    {
        animator.SetInteger("CamIndex", i);
    }
}
