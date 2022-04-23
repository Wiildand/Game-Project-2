using System;
using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {
    public bool startAsActive = true;
    public Color onActive = Color.red;
    public Color onPassive = Color.white;
    public int delayToChangeActivityEverySecond = 5;
    private MeshRenderer _meshRenderer;
    private BoxCollider _boxCollider;

    private void Awake() {
        if (delayToChangeActivityEverySecond < 0)
            throw new Exception("delayToChangeActivity must be a positive number");
        _boxCollider = GetComponent<BoxCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start() {
        if (startAsActive) {
            ToActive();
        } else {
            ToPassive();
        }
        StartCoroutine(ChangeActivityEveryDelay());
    }

    private IEnumerator ChangeActivityEveryDelay() {
        while (true) {
            yield return new WaitForSeconds(delayToChangeActivityEverySecond);
            ToPassive();
            yield return new WaitForSeconds(delayToChangeActivityEverySecond);
            ToActive();
        }
    }

    private void ToPassive() {
        gameObject.tag = "Untagged";
        _meshRenderer.material.color = onPassive;
        _boxCollider.isTrigger = true;
    }

    private void ToActive() {
        gameObject.tag = "Trap";
        _boxCollider.isTrigger = true;
        _meshRenderer.material.color = onActive;
    }
}
