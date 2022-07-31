using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornMealAktion : AnimationAndParticalAktion
{
    int activityInt = 1;

    public int ActivityInt { get => activityInt; set => activityInt = value; }

    public override void Start()
    {
        base.Start();

    }
    public override void StartParticles() // weil durch irgenteingrund die Reference verschwindet
    {
        if (particalSystem == null)
        {
            particalSystem = transform.GetChild(2).GetChild(0).GetComponent<ParticleSystem>();
        }
      
        particalSystem.Play();
    }
    public override void StopParticles() //  weil durch irgenteingrund die Reference verschwindet
    {
        if (particalSystem == null)
        {
            particalSystem = transform.GetChild(2).GetChild(0).GetComponent<ParticleSystem>();
        }
        particalSystem.Stop();
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
