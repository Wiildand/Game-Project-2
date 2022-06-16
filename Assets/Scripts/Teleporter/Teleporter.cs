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


        Vector3 finalDestination = new Vector3(destination.x, other.transform.position.y, destination.z);

        if (other.attachedRigidbody != null) {
            other.attachedRigidbody.MovePosition(finalDestination);
        } else {
            other.transform.position = finalDestination;
        }

    }

    private void TeleportToEnd(Collider other) {
        Debug.Log("TeleportToEnd");
        //Debug.Break();

        if (other.isTrigger || _endToStartObjects.Contains(other.gameObject)) {
            return;
        }

        // if other have rigidbody then moce it with MovePosition
        if (other.GetComponent<TeleportableEvent>() != null) {
            other.GetComponent<TeleportableEvent>().Teleported();
        }
        _starToEndObject.Add(other.gameObject);    
        TeleportToDestination(other, teleporterEnd.transform.position);
    }

    private void TeleportToStart(Collider other) {
        Debug.Log("TeleportToStart");
        // debug _starToEndObject
        for (int i = 0; i < _starToEndObject.Count; i++) {
            Debug.Log(_starToEndObject[i].name);
            Debug.Log(i);
        }

        if (other.isTrigger || !canGoBack || _starToEndObject.Contains(other.gameObject)) {
            Debug.Log("return");
            return;
        }
        if (other.GetComponent<TeleportableEvent>() != null) {
            other.GetComponent<TeleportableEvent>().Teleported();
        }
        _endToStartObjects.Add(other.gameObject);
        TeleportToDestination(other, teleporterStart.transform.position);
    }

    private void ExitStartTeleporter(Collider other) {
        Debug.Log("ExitStartTeleporter");
        //Debug.Break();
        _endToStartObjects.Remove(other.gameObject);
    }

    private void ExitEndTeleporter(Collider other) {
        Debug.Log("ExitEndTeleporter");
        //Debug.Break();
        _starToEndObject.Remove(other.gameObject);
    }


}
