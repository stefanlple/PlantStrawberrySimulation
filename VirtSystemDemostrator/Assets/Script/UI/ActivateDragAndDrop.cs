using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDragAndDrop : MonoBehaviour, IObjectAktion
{
    [SerializeField] BoxCollider cover;
    public GameObject place;
    public int checkIndex=6;

    
    
    public void decreaseCheckIndex(){
        checkIndex--;
        if(checkIndex==0){
            DoneWithmyThing();
            place.SetActive(false);
        }
    } 
    public void activateBars(){
        foreach (Transform child in transform) {
            child.GetChild(2).gameObject.SetActive(true);
        }
    } 
    public void deactivateBars(){
        foreach (Transform child in transform) {
            child.GetChild(2).gameObject.SetActive(false);
        }
    } 

    public virtual void Start()
    {
        GetComponent<InteractionObject>().SetObjectAktion(this);
    }

    public virtual void DoyourThing()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        foreach(Transform child in transform)
        {
            child.gameObject.GetComponent<BoxCollider>().enabled=true;
        }
    }
    public  void DoneWithmyThing()
    {
        MainMangment.mainMangment.ChangingforNextStep();
    }

    public void setBarAllZero(){

        foreach (Transform child in transform) {
            child.gameObject.GetComponent<PlantWater>().setBarZero();
            child.gameObject.GetComponent<PlantWater>().setAllCounterZero();
        }
    }
}
