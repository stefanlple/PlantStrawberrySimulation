using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelAktion : AnimationAndParticalAktion //,IObjectAktion
{ 
    [SerializeField] GameObject layerToRemove;
    public override void Start()
    {
        base.Start();
    }
    public void LetGrassDisapir()
    {
        layerToRemove.SetActive(false);
    }
   

    
}
