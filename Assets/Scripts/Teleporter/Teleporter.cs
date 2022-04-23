using System;
using UnityEngine;

public class Teleporter : MonoBehaviour {
    public GameObject player;
    public GameObject pointToReach;

    private void Awake() {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material.color = Color.green;

        MeshRenderer ptrMeshRenderer = pointToReach.GetComponent<MeshRenderer>();
        ptrMeshRenderer.material.color = Color.green;
    }

    private void OnTriggerEnter(Collider other) {
        player.transform.position = pointToReach.transform.position;
    }
}
