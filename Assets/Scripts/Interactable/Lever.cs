using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Lever : AInteractable {

    private bool activated = false;

    override public void OnInteractionStart(Player player) {
        if (!activated) {
            launchStartActions();
            activated = true;
        } else {
            launchEndActions();
            activated = false;
        }
    }

    override public void OnInteractionEnd(Player player) {
    }

}