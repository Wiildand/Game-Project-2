using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public abstract class AInteractable : MonoBehaviour
{

    public UnityEvent<Player> startActions;
    public UnityEvent<Player> endActions;

    protected void launchStartActions(Player player)
    {
        startActions.Invoke(player);
    }

    protected void launchEndActions(Player player)
    {
        endActions.Invoke(player);
      
    }


    public virtual void OnInteractionStart(Player player) {
        launchStartActions(player);
        Debug.Log("Interaction Start");
        // nothing's here, override with your own code
        // the player will call this method when the interaction starts
    }

    public virtual void OnInteractionEnd(Player player) {
        Debug.Log("Interaction End");

        launchEndActions(player);
        // nothing's here, override with your own code
        // the player will call this method when the interaction end
    }
}
