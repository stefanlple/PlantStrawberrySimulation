using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSoilAktion : AnimationAndParticalAktion
{
    [SerializeField] GameObject layerToMove;
    int activityInt = 1;

    public int ActivityInt { get => activityInt; set => activityInt = value; }

    public override void Start()
    {
        base.Start();
    }
    public void LayersMoving()
    {
        if (activityInt == 1)
        {
            layerToMove.GetComponent<Animator>().SetTrigger("Start");
        }
        else if (activityInt == 2)
        {
            layerToMove.GetComponent<Animator>().SetTrigger("Start2");
        }
        
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
}
