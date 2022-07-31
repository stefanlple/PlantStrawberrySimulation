using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationAktion : MonoBehaviour, IObjectAktion
{

    protected Animator animator;
    public virtual void Start()
    {
        GetComponent<InteractionObject>().SetObjectAktion(this);
        animator = GetComponent<Animator>();

    }
    public virtual void DoyourThing()
    {
        print("Start Ani");
        animator.SetTrigger("Start");
    }
    public  void DoneWithmyThing()
    {
        print("" + gameObject.name + ":ImDone");
        MainMangment.mainMangment.ChangingforNextStep();
    }
}
  
