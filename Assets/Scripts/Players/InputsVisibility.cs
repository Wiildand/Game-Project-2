using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsVisibility : MonoBehaviour
{
    private PlayerManager _playerManager;

    [SerializeField]
    private Player _player;


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
    // Start is called before the first frame update
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
    // private void changeInputsVisibility(List<Inputs> playerInput)
    // {
    //     // go throught inputsReference and set the corresponding gameobject visibility
    //     foreach (var input in inputsReference)
    //     {
    //         if (playerInput.Contains(input.Key))
    //         {
    //             input.Value.SetActive(true);
    //         }
    //         else
    //         {
    //             input.Value.SetActive(false);
    //         }
    //     }
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
