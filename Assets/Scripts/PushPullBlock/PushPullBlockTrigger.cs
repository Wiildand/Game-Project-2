using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPullBlockTrigger : AInteractable
{
    private BoxCollider _collider;
    private void Start() {
        _collider = GetComponent<BoxCollider>();
    }

    override public void OnInteractionStart(Player player) {
        GetComponent<Collider>().enabled = false;
        launchStartActions(player);
    }

    override public void OnInteractionEnd(Player player) {
        launchEndActions(player);
        GetComponent<Collider>().enabled = true;
    }
}
