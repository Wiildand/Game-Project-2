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

    private List<Collider> _starToEndColliders;
    private List<Collider> _endToStartColliders;


    private void Start() {
        _starToEndColliders = new List<Collider>();
        _endToStartColliders = new List<Collider>();

        teleporterStart.onTriggerEnter += OnTeleporterStartTriggerEnter;
        teleporterStart.onTriggerExit += OnTeleporterStartTriggerExit;


        teleporterEnd.onTriggerEnter += OnTeleporterEndTriggerEnter;
        teleporterEnd.onTriggerExit += OnTeleporterEndTriggerExit;
    }

    private void TeleportToDestination(Collider other, Vector3 destination) {
        // if other have rigidbody then moce it with MovePosition
        destination += new Vector3(0, other.transform.position.y, 0);
        if (other.attachedRigidbody != null) {
            other.attachedRigidbody.MovePosition(destination);
        } else {
            other.transform.position = destination;
        }

        if (other.GetComponent<TeleportableEvent>() != null) {
            other.GetComponent<TeleportableEvent>().Teleported();
        }
    }

    private void OnTeleporterStartTriggerEnter(Collider other) {
        if (_endToStartColliders.Contains(other)) {
            return;
        }
        TeleportToDestination(other, teleporterEnd.transform.position);
        _starToEndColliders.Add(other);    
    }

    private void OnTeleporterStartTriggerExit(Collider other) {
        _endToStartColliders.Remove(other);
    }

    private void OnTeleporterEndTriggerEnter(Collider other) {
        if (!canGoBack || _starToEndColliders.Contains(other)) {
            return;
        }
        TeleportToDestination(other, teleporterStart.transform.position);
        _endToStartColliders.Add(other);

    }

    private void OnTeleporterEndTriggerExit(Collider other) {
        _starToEndColliders.Remove(other);
    }


}
