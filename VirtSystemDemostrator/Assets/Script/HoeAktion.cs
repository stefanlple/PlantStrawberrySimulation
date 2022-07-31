using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoeAktion : AnimationAktion
{
    // Start is called before the first frame update
    [SerializeField] GameObject Layer;
    [SerializeField] int activityID = 1;
    [SerializeField] Animator forWeedremoveAni;
    public override void Start()
    {
        base.Start();
    }

    public void NiceFloor() //  
    {
        Layer.GetComponent<Animator>().SetTrigger("Start");
    }
    public override void DoyourThing()
    {
        if (activityID == 1)
        {
            base.DoyourThing();
        }
        else if (activityID == 2)
        {
            animator.SetTrigger("Start2");
        }
    }
    public void SetActivity(int id)
    {
        activityID = id;

    }
}
