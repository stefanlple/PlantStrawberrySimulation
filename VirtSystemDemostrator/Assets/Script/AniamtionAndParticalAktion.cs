using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationAndParticalAktion : AnimationAktion, IObjectAktion
{
  
  
    [SerializeField] public ParticleSystem particalSystem;
    public override void Start()
    {
        base.Start();
    }
   
    public virtual void StartParticles()
    {
        
        particalSystem.Play();
    }
    public virtual void StopParticles()
    {
        particalSystem.Stop();
    }
   


}
