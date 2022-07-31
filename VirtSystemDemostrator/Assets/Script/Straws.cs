using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straws : AnimationAktion
{
    [SerializeField] Animator Layer;
    [SerializeField] BoxCollider AltnertiveCollider;
    int activityInt = 1;

    public int ActivityInt { get => activityInt; set => activityInt = value; }

    public override void Start()
    {
        base.Start();
    }

    public void MoveFloor()
    {
        Layer.SetTrigger("Start");
    }
    public void ReMoveFloor()
    {
        Layer.SetTrigger("Start2");
    }
    public override void DoyourThing()
    {
        if (activityInt == 1)
        {
            animator.SetTrigger("Start");
        }
        else if (activityInt == 2)
        {

            animator.SetTrigger("Start2");
        }


    }
    public void SetOtherBox()
    {
        AltnertiveCollider.enabled = true;
    } 
    public void SetOtherBoxFalse()
    {
        AltnertiveCollider.enabled = false;
    } 
}
