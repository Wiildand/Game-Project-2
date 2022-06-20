using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : AInteractable
{
    [SerializeField]
    private float delayAfterDisabled = 0.5f;

    private float delayAfterDisabledCounter = 0.0f;
    private bool hasInteracted = false;

    private void Update() {
        if (!hasInteracted) {
            return;
        }

        if (delayAfterDisabledCounter > 0) {
            delayAfterDisabledCounter -= Time.deltaTime;
        } else {
            launchEndActions();
            hasInteracted = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        delayAfterDisabledCounter = delayAfterDisabled;
        hasInteracted = true;
        launchStartActions();
    }
    override public void OnInteractionEnd(Player player) {
    }
    override public void OnInteractionStart(Player player) {
    }
}
