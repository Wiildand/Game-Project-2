using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push_pullblock : MonoBehaviour
{
    private bool constraintsSet = false;
    public GameObject parent; // need the game object variable of the player
    private bool upArrowPressed = false;
    private bool downArrowPressed = false;
    private bool leftArrowPressed = false;
    private bool rightArrowPressed = false;
    private bool E_ArrowPressed = false;

    // need all the movement key that is currently pressed
    private Rigidbody m_Rigidbody;

    private RigidbodyConstraints originalConstraints;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        upArrowPressed = Input.GetKey(KeyCode.UpArrow);
        downArrowPressed = Input.GetKey(KeyCode.DownArrow);
        leftArrowPressed = Input.GetKey(KeyCode.LeftArrow);
        rightArrowPressed = Input.GetKey(KeyCode.RightArrow);
        E_ArrowPressed = Input.GetKey(KeyCode.E);

        if (E_ArrowPressed == false) {
            this.transform.SetParent(null);
            m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX;
            m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
            constraintsSet = false;
        }
    }

    void StartInteraction(GameObject parent) {
        // Set parenting
        this.transform.SetParent(parent.transform);

        // Get the rigidbody of parent to allow constraints
        m_Rigidbody = parent.GetComponent<Rigidbody>();

        // Save last Rigidbody constraints
        originalConstraints = m_Rigidbody.constraints;

        m_Rigidbody.centerOfMass = Vector3.zero;
        m_Rigidbody.inertiaTensorRotation = Quaternion.identity;

        if (upArrowPressed || downArrowPressed) {
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        }

        if (leftArrowPressed || rightArrowPressed) {
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX;
        }
    }

    void EndInteraction() {
        // Unset parenting
        this.transform.SetParent(null);

        // Reset parent constraints
        m_Rigidbody.constraints = originalConstraints;
    }

    void OnCollisionStay(Collision other) {
        if (other.gameObject.name == "player") {
            if (E_ArrowPressed) {
                this.transform.SetParent(parent.transform);
                if (!constraintsSet && (upArrowPressed || downArrowPressed)) {
                    m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionZ;
                    constraintsSet = true;
                }
                if (!constraintsSet && (leftArrowPressed || rightArrowPressed)) {
                    m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                    m_Rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionX;
                    constraintsSet = true;
                }
            }
        }
    }
}
