using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;


public struct PlayerInfos {
    PlayerInputs inputs;
    Player player;
}
public class PlayerManager : MonoBehaviour
{
    private List<Player> _players;
    private Camera _cam;
    private Dictionary <Inputs, Player> _inputsPlayerMap;


    [SerializeField]
    private GlobalProvider _globalProvider;
    
    [SerializeField]
    private GameplayManager _gameplayManager;

    void Start()
    {
        var players = FindObjectsOfType<Player>();
        _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        _players = new List<Player>(players);
        Debug.Log("Players found: " + _players.Count);
        _inputsPlayerMap = new Dictionary<Inputs, Player>() {
            { Inputs.MOVE_FORWARD, null },
            { Inputs.MOVE_BACKWARD, null },
            { Inputs.MOVE_LEFT, null },
            { Inputs.MOVE_RIGHT, null },
            { Inputs.INTERACT, null },
            { Inputs.DIVIDE, null },
            { Inputs.SWAP, null },
            { Inputs.JUMP, null },
            { Inputs.SHOOT, null }
        };
        
        foreach (Player player in _players) {
            PlayerInputs  inputs =  player.gameObject.GetComponent<PlayerInputs>();
            foreach (Inputs input in inputs.current) {
                Debug.Log("Player: " + player.name + " Input: " + input);
                _inputsPlayerMap[input] = player; 
            }
        }

        _globalProvider.SubscribeInputOnPerformed(Inputs.MOVE_FORWARD, OnMoveForward);
        _globalProvider.SubscribeInputOnPerformed(Inputs.MOVE_BACKWARD, OnMoveBackward);
        _globalProvider.SubscribeInputOnPerformed(Inputs.MOVE_LEFT, OnMoveLeft);
        _globalProvider.SubscribeInputOnPerformed(Inputs.MOVE_RIGHT, OnMoveRight);
        _globalProvider.SubscribeInputOnStarted(Inputs.INTERACT, OnInteractStart);
        _globalProvider.SubscribeInputOnCanceled(Inputs.INTERACT, OnInteractEnd);
        _globalProvider.SubscribeInputOnPerformed(Inputs.DIVIDE, OnDivide);
        _globalProvider.SubscribeInputOnPerformed(Inputs.SWAP, OnSwap);
        _globalProvider.SubscribeInputOnPerformed(Inputs.JUMP, OnJump);
        _globalProvider.SubscribeInputOnPerformed(Inputs.SHOOT, OnShoot);

        _globalProvider.mouse.performed += onMouseMove;

        Debug.Log("PlayerManager initialized");

    }

    private void OnDestroy() {
        _globalProvider.mouse.performed -= onMouseMove;

        _globalProvider.UnSubscribeInputOnPerformed(Inputs.MOVE_FORWARD, OnMoveForward);
        _globalProvider.UnSubscribeInputOnPerformed(Inputs.MOVE_BACKWARD, OnMoveBackward);
        _globalProvider.UnSubscribeInputOnPerformed(Inputs.MOVE_LEFT, OnMoveLeft);
        _globalProvider.UnSubscribeInputOnPerformed(Inputs.MOVE_RIGHT, OnMoveRight);
        _globalProvider.UnSubscribeInputOnStarted(Inputs.INTERACT, OnInteractStart);
        _globalProvider.UnSubscribeInputOnCanceled(Inputs.INTERACT, OnInteractEnd);
        _globalProvider.UnSubscribeInputOnPerformed(Inputs.DIVIDE, OnDivide);
        _globalProvider.UnSubscribeInputOnPerformed(Inputs.SWAP, OnSwap);
        _globalProvider.UnSubscribeInputOnPerformed(Inputs.JUMP, OnJump);
        _globalProvider.UnSubscribeInputOnPerformed(Inputs.SHOOT, OnShoot);


    }

    private void RemoveAllInputsOfPlayer(Player player) {
        // get Player Inputs
        PlayerInputs inputs = player.gameObject.GetComponent<PlayerInputs>();
        foreach (Inputs input in inputs.current) {
            _inputsPlayerMap[input] = null;
        }

        inputs.ClearAll();
    }

    public void KillPlayer(Player player) {
        _players.Remove(player);
        RemoveAllInputsOfPlayer(player);
        if (_players.Count < 1) {
            _gameplayManager.Restart();
        }
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

    public void ChangeInputOwnerShip(Inputs input, Player player){
        if (_inputsPlayerMap[input] != null) {
            _inputsPlayerMap[input].gameObject.GetComponent<PlayerInputs>().Remove(input);
        }
        _inputsPlayerMap[input] = player;

        PlayerInputs inputs = player.gameObject.GetComponent<PlayerInputs>();

        inputs.Add(input);
    }

    void OnMoveForward(CallbackContext context) {
        var contextValue = context.ReadValue<float>();
        Debug.Log("MoveForward" + _inputsPlayerMap[Inputs.MOVE_FORWARD].name);
        _inputsPlayerMap[Inputs.MOVE_FORWARD]?.MoveForward(contextValue); 
    }

    void OnMoveBackward(CallbackContext context) {
        var contextValue = context.ReadValue<float>();
        _inputsPlayerMap[Inputs.MOVE_BACKWARD]?.MoveBackward(contextValue);
    }

    void OnMoveLeft(CallbackContext context) {
        var contextValue = context.ReadValue<float>();
        _inputsPlayerMap[Inputs.MOVE_LEFT]?.MoveLeft(contextValue);
    }

    void OnMoveRight(CallbackContext context) {
        var contextValue = context.ReadValue<float>();
        _inputsPlayerMap[Inputs.MOVE_RIGHT]?.MoveRight(contextValue);
    }

    void OnInteractStart(CallbackContext context) {
        _inputsPlayerMap[Inputs.INTERACT]?.InteractStart();
    }

    void OnInteractEnd(CallbackContext context) {
        _inputsPlayerMap[Inputs.INTERACT]?.InteractEnd();
    }

    void OnJump(CallbackContext context) {
        _inputsPlayerMap[Inputs.JUMP]?.Jump();
    }

    void OnShoot(CallbackContext context) {
        _inputsPlayerMap[Inputs.SHOOT]?.Shoot();
    }

    void OnDivide(CallbackContext context) {
        Debug.Log("Divide");
    }

    void OnSwap(CallbackContext context) {
        Debug.Log("Swap");
    }

    void onMouseMove(CallbackContext context) {
        var contextValue = context.ReadValue<Vector2>();
        if (!_cam)
            return;
        Vector3 point = _cam.ScreenToWorldPoint(new Vector3(contextValue.x, contextValue.y, 1));
        float t = _cam.transform.position.y / (_cam.transform.position.y - point.y);
        Vector3 pointInGame = new Vector3(t * (point.x - _cam.transform.position.x) + _cam.transform.position.x, 1, t * (point.z - _cam.transform.position.z) + _cam.transform.position.z);
        foreach (Player player in _players) {
            player.UpdateMousePosition(pointInGame);
        }
    }

}
