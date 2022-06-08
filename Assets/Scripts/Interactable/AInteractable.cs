using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public abstract class AInteractable : MonoBehaviour
{

    public UnityEvent startActions;
    public UnityEvent endActions;

    protected void launchStartActions()
    {
        startActions.Invoke();
    }

    protected void launchEndActions()
    {
        endActions.Invoke();
      
    }


    public virtual void OnInteractionStart(Player player) {
        Debug.Log("Interaction Start");
        
        launchStartActions();
    }

    public virtual void OnInteractionEnd(Player player) {
        Debug.Log("Interaction End");

        launchEndActions();
    }
}

public abstract class AInteractableWithParam<T> : AInteractable
{

    public UnityEvent<T> startActionsWithParam;
    public UnityEvent<T> endActionsWithParam;

    protected void launchStartActions(T arg)
    {
        startActionsWithParam.Invoke(arg);
    }

    protected void launchEndActions(T arg)
    {
        endActionsWithParam.Invoke(arg);
      
    }

}

