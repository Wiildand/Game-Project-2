using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class GlobalProvider : MonoBehaviour
{
    // Start is called before the first frame update

    private GameInputs _inputs;

    public InputAction mouse;
    public InputAction menu;
    public InputAction retry;
    private Dictionary<Inputs, InputAction> inputsPlayerMapAction;

    void Awake()
    {
        _inputs = new GameInputs();       

        // Player
        inputsPlayerMapAction = new Dictionary<Inputs, InputAction>();

        _inputs.Player.Forward.Enable();
        _inputs.Player.Backward.Enable();
        _inputs.Player.Left.Enable();
        _inputs.Player.Right.Enable();
        _inputs.Player.Interact.Enable();
        _inputs.Player.Divide.Enable();
        _inputs.Player.Swap.Enable();
        _inputs.Player.Jump.Enable();
        _inputs.Player.Fire.Enable();

        inputsPlayerMapAction.Add(Inputs.MOVE_FORWARD, _inputs.Player.Forward);
        inputsPlayerMapAction.Add(Inputs.MOVE_BACKWARD, _inputs.Player.Backward);
        inputsPlayerMapAction.Add(Inputs.MOVE_LEFT, _inputs.Player.Left);
        inputsPlayerMapAction.Add(Inputs.MOVE_RIGHT, _inputs.Player.Right);
        inputsPlayerMapAction.Add(Inputs.INTERACT, _inputs.Player.Interact);
        inputsPlayerMapAction.Add(Inputs.DIVIDE, _inputs.Player.Divide);
        inputsPlayerMapAction.Add(Inputs.SWAP, _inputs.Player.Swap);
        inputsPlayerMapAction.Add(Inputs.JUMP, _inputs.Player.Jump);
        inputsPlayerMapAction.Add(Inputs.SHOOT, _inputs.Player.Fire);

        // Other
        _inputs.Other.Mouse.Enable();
        mouse = _inputs.Other.Mouse;

        _inputs.Other.Retry.Enable();
        retry = _inputs.Other.Retry;

    }

    private void Update() {
    }

    public void SubscribeInputOnPerformed(Inputs input, Action<CallbackContext> action){
        inputsPlayerMapAction[input].performed += action;
    }

    public void SubscribeInputOnStarted(Inputs input, Action<CallbackContext> action){
        inputsPlayerMapAction[input].started += action;
    }

    public void SubscribeInputOnCanceled(Inputs input, Action<CallbackContext> action){
        inputsPlayerMapAction[input].canceled += action;
    }
    
}
