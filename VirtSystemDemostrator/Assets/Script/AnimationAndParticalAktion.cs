using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AanimationAndParticalAktion : MonoBehaviour, IObjectAktion
{
    Animator animator;
    [SerializeField] ParticleSystem particalSystem;
    [SerializeField] GameObject layerToRemove;
    void Start()
    {
        GetComponent<InteractionObject>().SetObjectAktion(this);
        animator = GetComponent<Animator>();
    }
    public void DoyourThing()
    {

        animator.SetTrigger("Start");
    }
    public void StartParticles()
    {
        particalSystem.Play();
    }
    public void StopParticles()
    {
        particalSystem.Stop();
    }
    public void LetGrassDisapir()
    {
        layerToRemove.SetActive(false);
    }
    public void DoneWithmyThing()
    {
        MainMangment.mainMangment.ChangingforNextStep();
    }


}
