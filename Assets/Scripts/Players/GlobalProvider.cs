using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DirectionInputs {
    public float up;
    public float down;
    public float right;
    public float left;

    public Vector3 GetDirection(){
        return new Vector3(right - left, 0, up - down);
    }

}


public class GlobalProvider : MonoBehaviour
{
    // Start is called before the first frame update

    public DirectionInputs directionInputs;
    public bool isJumping = false;
    public bool isInteracting = false;
    public bool isSwapping = false;
    public bool isDividing = false;
    public bool isShooting = false;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
