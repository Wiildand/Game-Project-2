using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Mouse {
    public InputAction move;
    public InputAction deltaMove;
    public InputAction leftClick;
    public InputAction scroll;
    public UnityEvent<Vector2> dragEvent;
    private Vector2 dragOldValue;
    private Vector2 _dragThreshold;
    private bool _isHoldingLeftClick;

    private void OnLeftClick(CallbackContext context) {
        if (context.started) {
            _isHoldingLeftClick = true;
        } else if (context.canceled) {
            _isHoldingLeftClick = false;
        }
    }

    private void OnDrag(CallbackContext context) {
        Vector2 delta = context.ReadValue<Vector2>();

        if (_isHoldingLeftClick) {
            float x =  Mathf.Abs(delta.x) < _dragThreshold.x ? 0 : delta.x;
            float y =  Mathf.Abs(delta.y) < _dragThreshold.y ? 0 : delta.y;
            dragEvent.Invoke(new Vector2(x, y));
        } else {
            dragEvent.Invoke(Vector2.zero);
        }
    }

    public Mouse(InputAction move,
                 InputAction deltaMove,
                 InputAction leftClick,
                 InputAction scroll,
                 Vector2 dragThreshold) {
        this.move = move;
        this.deltaMove = deltaMove;
        this.leftClick = leftClick;
        this.scroll = scroll;
        _isHoldingLeftClick = false;

        this.deltaMove.started += OnDrag;
        this.deltaMove.performed += OnDrag;
        this.deltaMove.canceled += OnDrag;

        this.leftClick.started += OnLeftClick;
        this.leftClick.canceled += OnLeftClick;

        this.dragEvent = new UnityEvent<Vector2>();
        _dragThreshold = dragThreshold;
    }

}

public class GlobalProvider : MonoBehaviour
{
    // Start is called before the first frame update

    private GameInputs _inputs;

    [Header("Mouse")]
    [SerializeField]
    private Vector2 dragThreshold = new Vector2(0.1f, 0.1f);

    [HideInInspector]
    public Mouse mouse;
    [HideInInspector]
    public InputAction menu;
    [HideInInspector]
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

        // MOUSE
        
        _inputs.Other.Mouse.Enable();
        _inputs.Other.MouseDelta.Enable();
        _inputs.Other.LeftClick.Enable();
        _inputs.Other.Scroll.Enable();

        mouse = new Mouse(  _inputs.Other.Mouse, 
                            _inputs.Other.MouseDelta, 
                            _inputs.Other.LeftClick, 
                            _inputs.Other.Scroll,
                            dragThreshold
                        );

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

    public void UnSubscribeInputOnPerformed(Inputs input, Action<CallbackContext> action){
        inputsPlayerMapAction[input].performed -= action;
    }

    public void UnSubscribeInputOnStarted(Inputs input, Action<CallbackContext> action){
        inputsPlayerMapAction[input].started -= action;
    }

    public void UnSubscribeInputOnCanceled(Inputs input, Action<CallbackContext> action){
        inputsPlayerMapAction[input].canceled -= action;
    }

    void OnDestroy() {
        _inputs.Player.Forward.Disable();
        _inputs.Player.Backward.Disable();
        _inputs.Player.Left.Disable();
        _inputs.Player.Right.Disable();
        _inputs.Player.Interact.Disable();
        _inputs.Player.Divide.Disable();
        _inputs.Player.Swap.Disable();
        _inputs.Player.Jump.Disable();
        _inputs.Player.Fire.Disable();

        _inputs.Other.Mouse.Disable();
        _inputs.Other.Retry.Disable();

        _inputs.Dispose();
        _inputs = null;
    }
    
}
