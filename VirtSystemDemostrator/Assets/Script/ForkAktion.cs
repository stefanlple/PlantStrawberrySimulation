using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkAktion :AnimationAndParticalAktion
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
