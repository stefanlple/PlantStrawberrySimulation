using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct InterActionContainer 
{
    public InteractionObject interaction;
    public UnityEvent StepSetupBeforeClick;
    public UnityEvent StepSetup;
    public UnityEvent AfterSetpUpdate;
  

    public InteractionObject InteractionObject()
    {
        return interaction;
    }
}
