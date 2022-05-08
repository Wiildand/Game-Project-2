using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InputsOwnerShip{
    private Player _player;
    private UnityEvent<Player> _event;

    public KeyCode KEY; 

    public InputsOwnerShip(UnityAction<Player> fctToCall, KeyCode key, Player player = null){
        _player = player;
        _event = new UnityEvent<Player>();
        KEY = key;
        _event.AddListener(fctToCall);
    }

    public void changePlayerOwnerShip(Player player){
        _player = player;
    }

    public void InvokeEvent(){
        if (_event != null && _player != null)
            _event.Invoke(_player);
    }
}

public class InputsManager : MonoBehaviour
{
    // array of players
    private Player[] _players;

    // map of event for each input
    private Dictionary<Inputs, InputsOwnerShip> _inputsMapEvent;
    // Start is called before the first frame update
    void Awake() {
        // get all players
        _inputsMapEvent = new Dictionary<Inputs, InputsOwnerShip>()
        {
            { Inputs.JUMP, new InputsOwnerShip(this.Jump, KeyCode.Space) },
            // { Inputs.MOVE_FORWARD, new InputsOwnerShip() },
            // { Inputs.MOVE_BACKWARD, new InputsOwnerShip() },
            // { Inputs.MOVE_LEFT, new InputsOwnerShip() },
            // { Inputs.MOVE_RIGHT, new InputsOwnerShip() },
            { Inputs.INTERACT, new InputsOwnerShip(this.Interacte, KeyCode.E) },
            // { Inputs.DIVIDE, new InputsOwnerShip() },
            // { Inputs.SWAP, new InputsOwnerShip() },
            // { Inputs.SHOOT, new InputsOwnerShip() },
            // { Inputs.PAUSE, new InputsOwnerShip() },

            // { Inputs.RESUME, new InputsOwnerShip() },
            // { Inputs.RETRY, new InputsOwnerShip() },
        };

        var players = FindObjectsOfType<Player>();

        foreach (Player player in players) {
            foreach (Inputs input in player.inputs.currents) {  
                _inputsMapEvent[input].changePlayerOwnerShip(player);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(_inputsMapEvent[Inputs.JUMP].KEY)) {
            _inputsMapEvent[Inputs.JUMP].InvokeEvent();
        }
        if (Input.GetKeyDown(_inputsMapEvent[Inputs.INTERACT].KEY)) {
            _inputsMapEvent[Inputs.INTERACT].InvokeEvent();
        }        
    }

    private void Interacte(Player player) {
        player.Interacte();
    }
    private void Jump(Player player) {
        player.PressJump();
    }
}
