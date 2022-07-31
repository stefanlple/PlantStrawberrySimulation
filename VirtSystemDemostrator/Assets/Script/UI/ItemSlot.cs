using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public bool isPlanted=false;
    public AudioSource run;
    public void finish(){
       FindObjectOfType<ActivateDragAndDrop>().decreaseCheckIndex();
       gameObject.SetActive(false);
    }

    public void OnTriggerStay(Collider other){
            if(isPlanted!=true && Input.GetMouseButtonDown(1)){
            other.transform.position= transform.position;
            isPlanted=true;
            other.gameObject.GetComponent<DragDrop>().drag=false;
            other.gameObject.GetComponent<DragDrop>().enabled=false;
            other.gameObject.GetComponent<MouseSelectionHighLightOnChilrdren>().highlightMaterial = null;
            finish();
            run.Play();
            }
            

    }

}
