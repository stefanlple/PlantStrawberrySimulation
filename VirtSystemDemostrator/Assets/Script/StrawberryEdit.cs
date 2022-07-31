using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberryEdit : MonoBehaviour,IObjectAktion
{

    [SerializeField] Animator animator;
    [SerializeField] int Activity_id = 1;

    [SerializeField] Animator CamsControl;

    [SerializeField] InteractionObject[] applyObjects;

    public int Activity_id1 { get => Activity_id; set => Activity_id = value; }

    // Start is called before the first frame update
    public virtual void Start()
    {
        foreach (InteractionObject TO in applyObjects)
        {
            TO.SetObjectAktion(this);
        }
     
        
    }

    public void DoneWithmyThing()
    {
        MainMangment.mainMangment.ChangingforNextStep();
    }

    public void DoyourThing()
    {
        if (Activity_id == 1)
        {
            animator.SetTrigger("Start");
        }
        else if (Activity_id == 2)
        {
            animator.SetTrigger("Start2");
        }
    }
    public void CamPos(int i)
    {
        CamsControl.SetInteger("CamIndex", i);
    }
             
       
       
}
