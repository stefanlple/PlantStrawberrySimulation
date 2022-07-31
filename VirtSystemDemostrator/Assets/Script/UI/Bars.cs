using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    public void setValue(int hunger){
        slider.value = hunger;
    }

    public void setMaxValue(int hunger){
        slider.maxValue= hunger;
        slider.value= 0;
    }
 
}