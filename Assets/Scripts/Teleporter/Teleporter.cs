using System;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    [SerializeField]
    private ChildTrigger teleporterStart;
    [SerializeField]
    private ChildTrigger teleporterEnd;
    [SerializeField]
    private bool canGoBack = true;

    private List<GameObject> _starToEndObject;
    private List<GameObject> _endToStartObjects;


    private void Start() {
        _starToEndObject = new List<GameObject>();
        _endToStartObjects = new List<GameObject>();

        teleporterStart.onTriggerEnter += TeleportToEnd;
        teleporterStart.onTriggerExit += ExitStartTeleporter;


        teleporterEnd.onTriggerEnter += TeleportToStart;
        teleporterEnd.onTriggerExit += ExitEndTeleporter;
    }

    private void TeleportToDestination(Collider other, Vector3 destination) {

        if (other.GetComponent<TeleportableEvent>() != null) {
            other.GetComponent<TeleportableEvent>().Teleported();
        }

        Vector3 finalDestination = new Vector3(destination.x, other.transform.position.y, destination.z);

        other.transform.position = finalDestination;

        // if player
        if (other.GetComponent<Player>() != null && other.GetComponent<Player>().interactable != null) {
            if (other.GetComponent<Player>().interactable.GetComponent<PushPullBlock>() != null) {
                other.GetComponent<Player>().interactable.GetComponent<PushPullBlock>().MoveInFrontOfPlayer();
            }
        }


    }

    private void TeleportToEnd(Collider other) {
        if (other.isTrigger || _endToStartObjects.Contains(other.gameObject)) {
            return;
        }

        TeleportToDestination(other, teleporterEnd.transform.position);
        _starToEndObject.Add(other.gameObject);    
    }

    private void TeleportToStart(Collider other) {
        if (other.isTrigger || !canGoBack || _starToEndObject.Contains(other.gameObject)) {
            return;
        }

        TeleportToDestination(other, teleporterStart.transform.position);
        _endToStartObjects.Add(other.gameObject);
    }

    private void ExitStartTeleporter(Collider other) {
        _endToStartObjects.Remove(other.gameObject);
    }

    private void ExitEndTeleporter(Collider other) {
        _starToEndObject.Remove(other.gameObject);
    }


}
