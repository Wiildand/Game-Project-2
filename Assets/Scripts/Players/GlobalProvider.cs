using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

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

    private GameInputs _inputs;

    private Dictionary<Inputs, InputAction> inputsPlayerMapAction;

    void Awake()
    {
        _inputs = new GameInputs();       
        inputsPlayerMapAction = new Dictionary<Inputs, InputAction>();
        
        _inputs.Player.Forward.Enable();
        inputsPlayerMapAction.Add(Inputs.MOVE_FORWARD, _inputs.Player.Forward);
        
        _inputs.Player.Backward.Enable();
        inputsPlayerMapAction.Add(Inputs.MOVE_BACKWARD, _inputs.Player.Backward);
        
        _inputs.Player.Left.Enable();
        inputsPlayerMapAction.Add(Inputs.MOVE_LEFT, _inputs.Player.Left);
        
        _inputs.Player.Right.Enable();
        inputsPlayerMapAction.Add(Inputs.MOVE_RIGHT, _inputs.Player.Right);
        
        _inputs.Player.Interact.Enable();
        inputsPlayerMapAction.Add(Inputs.INTERACT, _inputs.Player.Interact);
        
        _inputs.Player.Divide.Enable();
        inputsPlayerMapAction.Add(Inputs.DIVIDE, _inputs.Player.Divide);
        
        _inputs.Player.Swap.Enable();
        inputsPlayerMapAction.Add(Inputs.SWAP, _inputs.Player.Swap);
        
        _inputs.Player.Jump.Enable();
        inputsPlayerMapAction.Add(Inputs.JUMP, _inputs.Player.Jump);
        
        _inputs.Player.Fire.Enable();
        inputsPlayerMapAction.Add(Inputs.SHOOT, _inputs.Player.Fire);
        
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
