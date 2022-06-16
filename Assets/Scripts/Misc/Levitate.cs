using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{

    private float initalY;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float distance;

    void Start()
    {
        initalY = transform.position.y;
    }

    private void FixedUpdate() {
          transform.position = new Vector3(
            transform.position.x, 
            initalY + Mathf.Abs(Mathf.Sin(Time.time * speed)) * 0.1f * distance,
            transform.position.z);    
    }

    
}
