using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Lever : AInteractable {

    private bool activated = false;

    override public void OnInteractionStart(Player player) {
        if (activated) {
            launchStartActions(new InteractableParameters(player));
            activated = false;
        } else {
            launchEndActions(new InteractableParameters(player));
            activated = true;
        }
    }

    override public void OnInteractionEnd(Player player) {
    }

}