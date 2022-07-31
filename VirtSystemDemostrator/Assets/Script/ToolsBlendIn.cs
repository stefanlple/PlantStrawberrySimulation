using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsBlendIn : MonoBehaviour,IObserver
{
    [SerializeField] int id;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        SubscribeToEvents_Start();
        ani = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnimationReacktion(int i)
    {
        if (id == i)
        {
            MoveIn();
        }
    }
    public void MoveIn()
    {
        ani.SetTrigger("Move");
    }
    public void MoveOut()
    {

    }


    public void SubscribeToEvents_Start()
    {
       // MainMangment.mainMangment.OnNewStep += AnimationReacktion;
    }

    public void UnsubscribeToAllEvents()
    {
      // MainMangment.mainMangment.OnNewStep -= AnimationReacktion;
    }
    private void OnDisable()
    {
      //  UnsubscribeToAllEvents();
    }
}
