using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver 
{
    public void SubscribeToEvents_Start();
    public void UnsubscribeToAllEvents(); //On Diable Benutzten ansonsten könnte es zu Exception kommen
}

