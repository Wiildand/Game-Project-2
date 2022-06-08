using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : AInteractableWithParam<Player>
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

    private void Press(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            launchStartActions(player);
        } else {
            launchStartActions();
        }

    }

    private void Release(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            launchEndActions(player);
        } else {
            launchEndActions();
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (activated && stayActivatedAfterInteraction || canOnlyBeActivatedByPlayer && other.gameObject.tag != "Player") {
            return;
        }

        launchStartActions();

        objectsOnPressurePlate.Add(other.gameObject);
        activated = true;
    }

    private void OnTriggerExit(Collider other) {
        objectsOnPressurePlate.Remove(other.gameObject);
        if (activated && stayActivatedAfterInteraction || objectsOnPressurePlate.Count > 0) {
            return;
        }
        launchEndActions();
        activated = false;
    }

    override public void OnInteractionEnd(Player player) {
    }
    override public void OnInteractionStart(Player player) {
    }
}
