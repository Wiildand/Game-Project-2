using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;


public class PlayerInfos {
    public PlayerInputs inputs;
    public Player player;

    public PlayerInfos(PlayerInputs inputs, Player player) {
        this.inputs = inputs;
        this.player = player;
    }
}
public class PlayerManager : MonoBehaviour
{
    private List<Player> _players;
    private Camera _cam;
    private Dictionary <Inputs, PlayerInfos> _inputsPlayerMap;


    [SerializeField]
    private GlobalProvider _globalProvider;
    
    [SerializeField]
    private GameplayManager _gameplayManager;

    void Start()
    {
        var players = FindObjectsOfType<Player>();
        _cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        _players = new List<Player>(players);
        _inputsPlayerMap = new Dictionary<Inputs, PlayerInfos>() {
            { Inputs.JUMP, null },
            { Inputs.SHOOT, null },
            { Inputs.INTERACT, null },
            { Inputs.DIVIDE, null },
            { Inputs.MOVE_FORWARD, null },
            { Inputs.MOVE_BACKWARD, null },
            { Inputs.MOVE_LEFT, null },
            { Inputs.MOVE_RIGHT, null }

        };
        
        foreach (Player player in _players) {
            PlayerInputs  playerInputs =  player.gameObject.GetComponent<PlayerInputs>();
            foreach (Inputs input in playerInputs.current) {
                _inputsPlayerMap[input] = new PlayerInfos(playerInputs, player); 
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

        _globalProvider.mouse.move.performed += onMouseMove;

    }

    private void OnDestroy() {
        _globalProvider.mouse.move.performed -= onMouseMove;

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
            _inputsPlayerMap[input].inputs.Remove(input);
        }

        PlayerInfos playerInfos = new PlayerInfos(player.gameObject.GetComponent<PlayerInputs>(), player);
        playerInfos.inputs.Add(input);
        _inputsPlayerMap[input] = playerInfos;

    }

    void OnMoveForward(CallbackContext context) {
        var contextValue = context.ReadValue<float>();
        _inputsPlayerMap[Inputs.MOVE_FORWARD]?.player?.MoveForward(contextValue); 
    }

    void OnMoveBackward(CallbackContext context) {
        var contextValue = context.ReadValue<float>();
        _inputsPlayerMap[Inputs.MOVE_BACKWARD]?.player?.MoveBackward(contextValue);
    }

    void OnMoveLeft(CallbackContext context) {
        var contextValue = context.ReadValue<float>();
        _inputsPlayerMap[Inputs.MOVE_LEFT]?.player?.MoveLeft(contextValue);
    }

    void OnMoveRight(CallbackContext context) {
        var contextValue = context.ReadValue<float>();
        _inputsPlayerMap[Inputs.MOVE_RIGHT]?.player?.MoveRight(contextValue);
    }

    void OnInteractStart(CallbackContext context) {
        _inputsPlayerMap[Inputs.INTERACT]?.player?.InteractStart();
    }

    void OnInteractEnd(CallbackContext context) {
        _inputsPlayerMap[Inputs.INTERACT]?.player?.InteractEnd();
    }

    void OnJump(CallbackContext context) {
        _inputsPlayerMap[Inputs.JUMP]?.player?.Jump();
    }

    void OnShoot(CallbackContext context) {
        _inputsPlayerMap[Inputs.SHOOT]?.player?.Shoot();
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

        // raycast to get the mouse position on the world  and make the player look at it
        Ray ray = _cam.ScreenPointToRay(contextValue);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100)) {
            foreach (Player player in _players) {
                player.UpdateMousePosition(hit.point);
            }
        }
    }

}
