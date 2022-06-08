using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsVisibility : MonoBehaviour
{
    private PlayerManager _playerManager;

    [SerializeField]
    private GameObject Jump;
    [SerializeField]
    private GameObject Shoot;
    [SerializeField]
    private GameObject Interact;

    [SerializeField]
    private GameObject Divide;
    [SerializeField]
    private GameObject MoveForward;
    [SerializeField]
    private GameObject MoveBackward;
    [SerializeField]
    private GameObject MoveLeft;
    [SerializeField]
    private GameObject MoveRight;

    private Dictionary<Inputs, GameObject> inputsReference;
    void Start()
    {
        inputsReference = new Dictionary<Inputs, GameObject>()
        {
            { Inputs.JUMP, Jump },
            { Inputs.SHOOT, Shoot },
            { Inputs.INTERACT, Interact },
            { Inputs.DIVIDE, Divide },
            { Inputs.MOVE_FORWARD, MoveForward },
            { Inputs.MOVE_BACKWARD, MoveBackward },
            { Inputs.MOVE_LEFT, MoveLeft },
            { Inputs.MOVE_RIGHT, MoveRight }
        };

    }

    public void SetInputsVisibility(bool visible, Inputs input)
    {
        if (inputsReference.ContainsKey(input))
        {
            inputsReference[input].SetActive(visible);
        }
    }

    public void PressInput(Inputs input) {
        // make the input opacity 0.5
        if (inputsReference.ContainsKey(input))
        {
            inputsReference[input].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.5f);
        }
    }

    public void ReleaseInput(Inputs input) {
        // make the input opacity 1
        if (inputsReference.ContainsKey(input))
        {
            inputsReference[input].GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        }
    }
}
