using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ChildTrigger : MonoBehaviour
{
    public UnityAction<Collider> onTriggerEnter;
    public UnityAction<Collider> onTriggerExit;
    public UnityAction<Collider> onTriggerStay;
    public UnityAction<Collision> onCollisionEnter;
    public UnityAction<Collision> onCollisionExit;
    public UnityAction<Collision> onCollisionStay;

    // each fonction called his own event
    private void OnTriggerEnter(Collider other) {
        onTriggerEnter?.Invoke(other);
    }

    private void OnTriggerExit(Collider other) {
        onTriggerExit?.Invoke(other);
    }

    private void OnTriggerStay(Collider other) {
        onTriggerStay?.Invoke(other);
    }

    private void OnCollisionEnter(Collision other) {
        onCollisionEnter?.Invoke(other);
    }

    private void OnCollisionExit(Collision other) {
        onCollisionExit?.Invoke(other);
    }

    private void OnCollisionStay(Collision other) {
        onCollisionStay?.Invoke(other);
    }
    
}
