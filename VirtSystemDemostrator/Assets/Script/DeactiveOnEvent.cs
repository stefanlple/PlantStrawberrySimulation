using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveOnEvent : MonoBehaviour, IObserver
{
    [SerializeField] int id;
    public void SubscribeToEvents_Start()
    {
        MainMangment.mainMangment.OnNewStep += DeactiveReacktion;
    }

    public void UnsubscribeToAllEvents()
    {
        MainMangment.mainMangment.OnNewStep -= DeactiveReacktion;
    }
    private void Start()
    {
        SubscribeToEvents_Start();
    }
    private void OnDisable()
    {
        UnsubscribeToAllEvents();
    }
    public void DeactiveReacktion(int i)
    {
        if (id == i)
        {
            gameObject.SetActive(false);
        }
    }

}
