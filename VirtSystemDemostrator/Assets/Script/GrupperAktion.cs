using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrupperAktion : AnimationAktion
{
    [SerializeField] GameObject Layer;
    int activityInt = 1;
    [SerializeField] Transform otherpos;

    public int ActivityInt { get => activityInt; set => activityInt = value; }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

    }

    public void StartFloor()
    {
        print("StartFlorr");
        Layer.GetComponent<Animator>().SetTrigger("Start2");
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
    public void ChangingPos() // aus unbaknnten Gründen nicht funktional 
    {

        transform.localPosition = new Vector3(otherpos.localPosition.x, otherpos.localPosition.y, otherpos.localPosition.z);
        transform.localRotation = otherpos.rotation;
      
    }
}
