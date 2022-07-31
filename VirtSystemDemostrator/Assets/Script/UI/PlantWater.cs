using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantWater : MonoBehaviour
{
    public int maxThirst=3;

    public int currentThirst;

    public Bars thirstBar;

    public int counter=0;
    
    
    public void setBar(ref int currentNumber, int number, Bars bar){
        currentNumber=number;
        bar.setMaxValue(number);
        bar.setValue(0);
    }

    public void changeBar(Bars bar,int damage, ref int currentNumber,string operations){

        currentNumber= operations.Equals("plus") ? currentNumber+=damage : currentNumber-=damage;
        bar.setValue(currentNumber);
    }

    public void OnTriggerStay(Collider other){
        if(other.CompareTag("WaterDrop")){
            if(Input.GetKeyDown(KeyCode.Mouse0)){
            changeBar(thirstBar,1, ref currentThirst,"plus");
            }
        }
    }
    public void finish1(){
       FindObjectOfType<WatercanWatering>().decreaseCheckIndex1();
       Debug.Log(FindObjectOfType<WatercanWatering>().checkIndex1);
    }

    public void setAllCounterZero(){
        counter=0;
    }
    
    public void setBarZero(){
        currentThirst=0;
        thirstBar?.setValue(0);
        thirstBar?.setMaxValue(maxThirst);
    }
    void Start()
    {
        setBarZero();
    }

    // Update is called once per frame
    void Update()
    {
     if (currentThirst ==3 && counter==0){
        finish1();
        counter++;
    }  
    }
}
