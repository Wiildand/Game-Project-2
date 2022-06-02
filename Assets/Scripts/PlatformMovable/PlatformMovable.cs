using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformMovable : MonoBehaviour {

    [SerializeField]
    private Rigidbody platformRb;
    [SerializeField]
    private GameObject listPointContainter;
    [Space]
    [Header("Movement")]
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private bool backTracking = true;

    [SerializeField]
    private bool isSticky = false;

    private List<Transform> steps;
    private int currentSteps;

    private bool hasTouchedThePlatform = false;


    private void Awake() {

        Transform[] listPoint = listPointContainter.GetComponentsInChildren<Transform>();
        
        steps = new List<Transform>(listPoint);
        steps.RemoveAt(0);        

        if (steps.Count < 2)
            throw new Exception("You must have at least 2 points");

        if (backTracking && steps.Count > 2) {
            List<Transform> reverse = new List<Transform>(steps);
            reverse.RemoveAt(reverse.Count - 1);
            reverse.Reverse();
            steps.AddRange(reverse);
        }

        currentSteps = 0;
        // get Childtrigger from platform
        ChildTrigger childTrigger = platformRb.GetComponent<ChildTrigger>();
        childTrigger.onTriggerStay += OnPlatformTriggerStay;
        childTrigger.onTriggerExit += checkIfPlayerHasExitPlatform;
        platformRb.transform.position = steps[currentSteps].position;

    }

    public void checkIfPlayerHasExitPlatform(Collider other) {
        if (other.gameObject.tag == "Player") {
            hasTouchedThePlatform = false;
        } else {

        }
    }

    public void checkForPlayerOnPlatform(Collider other) {
        Player player = other.gameObject.GetComponent<Player>();
        if (player.IsGrounded()) {
            hasTouchedThePlatform = true;
        } else if (other.attachedRigidbody == null) {
            other.transform.parent = platformRb.transform;
        }
    }

    public void OnPlatformTriggerStay(Collider other) {
        if (!isSticky)
            return;

        if (other.gameObject.tag == "Player") {
            
            if (hasTouchedThePlatform) {
                other.attachedRigidbody.AddForce(platformRb.velocity, ForceMode.VelocityChange);
            } else {
                checkForPlayerOnPlatform(other);
            }

        } else {

            if (other.attachedRigidbody != null) {
                other.attachedRigidbody.velocity = new Vector3( platformRb.velocity.x,
                                                                other.attachedRigidbody.velocity.y,
                                                                platformRb.velocity.z);
            } else {
                other.transform.parent = platformRb.transform;
            }

        }

    }

    private void Update() {
        // move toward position with forces
        Vector3 position = Vector3.MoveTowards(platformRb.position, steps[currentSteps].position, speed * Time.deltaTime);
        platformRb.MovePosition(position);
        
        // if the position is reached, go to the next step
        if (platformRb.position == steps[currentSteps].position) {
            currentSteps++;
            if (currentSteps >= steps.Count) {
                currentSteps = 0;
            }
        }

    }

}
