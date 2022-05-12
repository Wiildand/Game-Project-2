using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InputsOwnerShip{
    private Player _player;
    private UnityAction<Player> _action;
    public KeyCode KEY; 

    public InputsOwnerShip(UnityAction<Player> fctToCall, KeyCode key, Player player = null){
        _player = player;
        KEY = key;
        _action = fctToCall;
    }

    public void changePlayerOwnerShip(Player player){
        _player = player;
    }

    public void InvokeEvent(){
        if (_player != null)
            _action(_player);
    }
}





public class InputsManager : MonoBehaviour
{
    // array of players
    // private Player[] _players;

    [SerializeField]
    GlobalProvider _globalProvider;

    private float forward = 0;
    private float backward = 0;
    private float right = 0;
    private float left = 0;

    // map of event for each input
    private Dictionary<Inputs, InputsOwnerShip> _inputsMapEvent;
    // Start is called before the first frame update
    void Awake() {
        // get all players
        // _inputsMapEvent = new Dictionary<Inputs, InputsOwnerShip>()
        // {
            // { Inputs.JUMP, new InputsOwnerShip(this.Jump, KeyCode.D) },
            // { Inputs.MOVE_FORWARD, new InputsOwnerShip(this.MoveForward, KeyCode.I) },
            // { Inputs.MOVE_BACKWARD, new InputsOwnerShip(this.MoveBackward, KeyCode.W) },
            // { Inputs.MOVE_LEFT, new InputsOwnerShip(this.MoveLeft, KeyCode.A) },
            // { Inputs.MOVE_RIGHT, new InputsOwnerShip(this.MoveRight, KeyCode.L) },
            // { Inputs.INTERACT, new InputsOwnerShip(this.Interacte, KeyCode.E) },
            // { Inputs.DIVIDE, new InputsOwnerShip() },
            // { Inputs.SWAP, new InputsOwnerShip() },
            // { Inputs.SHOOT, new InputsOwnerShip() },
            // { Inputs.PAUSE, new InputsOwnerShip() },

            // { Inputs.RESUME, new InputsOwnerShip() },
            // { Inputs.RETRY, new InputsOwnerShip() },
        // };

        // var players = FindObjectsOfType<Player>();

        // foreach (Player player in players) {
        //     foreach (Inputs input in player.inputs.currents) {  
        //         _inputsMapEvent[input].changePlayerOwnerShip(player);
        //     }
        // }
    }

    public void AddInputToPlayer(Player player, Inputs input){
        _inputsMapEvent[input].changePlayerOwnerShip(player);
        player.inputs.Add(input);
    }

    private float SimulateAnalogInputs(float value, float goal) {
        // make value reach goal in a smooth way
        if (value < goal) {
            value += Time.deltaTime * 2;
            return value >= goal ? goal : value;
        } else if (value > goal) {
            value -= Time.deltaTime * 2;
            return value <= goal ? goal : value;
        }
        return value;
    }


    private void AxisInputUpdate(Inputs input, float goal, ref float axis) {
        if (Input.GetKey(_inputsMapEvent[input].KEY)) {
            axis = SimulateAnalogInputs(axis, goal);
            _inputsMapEvent[input].InvokeEvent();
        } else if (axis != 0) {
            axis = SimulateAnalogInputs(axis, 0f);
            _inputsMapEvent[input].InvokeEvent();
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(_inputsMapEvent[Inputs.JUMP].KEY)) {
            _inputsMapEvent[Inputs.JUMP].InvokeEvent();
        }

        // check forward inputs
        AxisInputUpdate(Inputs.MOVE_FORWARD, 1f, ref forward);
        AxisInputUpdate(Inputs.MOVE_BACKWARD, -1f, ref backward);
        AxisInputUpdate(Inputs.MOVE_LEFT, -1f, ref left);
        AxisInputUpdate(Inputs.MOVE_RIGHT, 1f, ref right);

        if (Input.GetKeyDown(_inputsMapEvent[Inputs.INTERACT].KEY)) {
            _inputsMapEvent[Inputs.INTERACT].InvokeEvent();
        }        
    }

    private void MoveForward(Player player) {
        player.MoveForward(forward);
    }

    private void MoveBackward(Player player) {
        player.MoveBackward(backward);
    }

    private void MoveLeft(Player player) {
        player.MoveLeft(left);
    }

    private void MoveRight(Player player) {
        player.MoveRight(right);
    }



    private void Interacte(Player player) {
        player.Interacte();
    }
    private void Jump(Player player) {
        player.PressJump();
    }
}
