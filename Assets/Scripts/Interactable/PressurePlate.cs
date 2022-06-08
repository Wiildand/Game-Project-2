using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : AInteractable
{
    [SerializeField]
    private bool stayActivatedAfterInteraction = false;

    [SerializeField]
    private bool canOnlyBeActivatedByPlayer = false;

    private bool activated = false;

    private List<GameObject> objectsOnPressurePlate;

    private void Start()
    {
        objectsOnPressurePlate = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other) {

        if (activated && stayActivatedAfterInteraction || canOnlyBeActivatedByPlayer && other.gameObject.tag != "Player") {
            return;
        }

        InteractableParameters interactableParameters = new InteractableParameters(other.gameObject);

        launchStartActions(interactableParameters);
        objectsOnPressurePlate.Add(other.gameObject);
        activated = true;
    }

    private void OnTriggerExit(Collider other) {
        objectsOnPressurePlate.Remove(other.gameObject);
        if (activated && stayActivatedAfterInteraction || objectsOnPressurePlate.Count > 0) {
            return;
        }

        InteractableParameters interactableParameters = new InteractableParameters(other.gameObject);

        launchEndActions(interactableParameters);
        activated = false;
    }

    override public void OnInteractionEnd(Player player) {
    }
    override public void OnInteractionStart(Player player) {
    }
}
