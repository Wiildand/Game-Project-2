using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformMovable : MonoBehaviour {
    public float speed = 5;
    public List<Transform> listPoint;
    private bool goToLastPoint = true;
    private Transform pointToReach = null;
    private int indexToPoint = 0;

    private void Awake() {
        pointToReach = listPoint[indexToPoint];
    }

    private void Update() {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, pointToReach.position, step);
        CheckForNextPoint();
    }

    private void CheckForNextPoint() {
        if (transform.position != pointToReach.position) {
            return;
        }

        if (goToLastPoint) {
            indexToPoint++;
            if (indexToPoint == listPoint.Count) {
                indexToPoint--;
                goToLastPoint = false;
            }
        } else {
            indexToPoint--;
            if (indexToPoint == -1) {
                indexToPoint++;
                goToLastPoint = true;
            }
        }

        pointToReach = listPoint[indexToPoint];
    }
}
