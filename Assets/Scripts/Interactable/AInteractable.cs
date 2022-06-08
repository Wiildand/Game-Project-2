using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

public class InteractableParameters 
{
    public Player player;
    public GameObject gameObject;

    public InteractableParameters(GameObject gameObject)
    {
        this.gameObject = gameObject;
        this.player = null;

        if (gameObject.tag == "Player")
        {
            Player player = gameObject.GetComponent<Player>();
            this.player = player;
        }
    }

    public InteractableParameters(Player player)
    {
        this.gameObject = player.gameObject;
        this.player = player;
    }
}

public abstract class AInteractable : MonoBehaviour
{

    public UnityEvent<InteractableParameters> startActions;
    public UnityEvent<InteractableParameters> endActions;

    protected void launchStartActions(InteractableParameters param)
    {
        startActions.Invoke(param);
    }

    protected void launchEndActions(InteractableParameters param)
    {
        endActions.Invoke(param);
      
    }


    public virtual void OnInteractionStart(Player player) {
        Debug.Log("Interaction Start");
        
        launchStartActions( new InteractableParameters(player) );
    }

    public virtual void OnInteractionEnd(Player player) {
        Debug.Log("Interaction End");

        launchEndActions( new InteractableParameters(player) );
    }
}
