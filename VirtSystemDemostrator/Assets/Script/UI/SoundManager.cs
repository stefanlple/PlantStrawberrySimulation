using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume",1);
            load();
        }else{
            load();
        }
    }
    public void changeVolume()
    {
        AudioListener.volume= volumeSlider.value;
        save();
    }

    private void load(){
        volumeSlider.value= PlayerPrefs.GetFloat("musicVolume");

    }
    private void save(){
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

}
