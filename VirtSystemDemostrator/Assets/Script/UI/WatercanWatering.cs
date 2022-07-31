using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatercanWatering : MonoBehaviour, IObjectAktion
{
    public bool active=false;
    public float speed= 0.02f;
    private Vector3 defaultPosition= new Vector3(-12.83f, 18.093f, -16.1f);
    public ParticleSystem wateringParticles;
    public void playWatering(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            wateringParticles.Play();
        }
    }
    public void watering(){
            wateringParticles.Play();
    }
    public int checkIndex1=6;
    
    public void decreaseCheckIndex1(){
        checkIndex1--;
        if(checkIndex1==0){
            transform.position=defaultPosition;
            active=false;
            DoneWithmyThing();
        }
    } 
    public void activateMovementCan(){
        active=true;
    }
    public virtual void DoyourThing()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        foreach(Transform child in transform)
        {
            child.gameObject.GetComponent<BoxCollider>().enabled=true;
        }
    }
    public void repeatWatering(){
        checkIndex1=6;
        Debug.Log("Index set to" +checkIndex1);
    }
    public  void DoneWithmyThing()
    {
        MainMangment.mainMangment.ChangingforNextStep();
    }
            

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active==true){
        playWatering();
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection= Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(zDirection,0.0f,-xDirection);
        transform.position += moveDirection *speed;
        }
    }
}
