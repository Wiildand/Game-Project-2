using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Direction
{
    public float forward;
    public float backward;
    public float right;
    public float left;
} 

public class Player : MonoBehaviour
{
    
    [HideInInspector]
    public Rigidbody _rb;
    [HideInInspector]
    public bool _raycastHitted;
    [HideInInspector]
    public RaycastHit _rayHit;
    [HideInInspector]
    public float _jumpBufferingTimeCounter;
    [HideInInspector]
    public float _cayoteTimeCounter;


    private Direction _inputDirection;


    private APlayerState _currentState;
    private Vector3 _goalVelocity;
    private Vector3 _unitGoalDir;
    private  Interactable _interactable;

    private Vector3 _positionToLookAt;

    [SerializeField] public int Id;
    [SerializeField] private Transform PlayerModel;
    [Space]
    [Header("Movement")]

    [SerializeField] public AnimationCurve AccelerationFactor;
    [SerializeField] public float MaxSpeed;
    [SerializeField] public float Acceleration;
    [SerializeField] public float MaxAcceleration;
    [SerializeField] public Vector3 ForceScale;

    [Space]
    [Header("Jump")]

    [SerializeField] public AnimationCurve JumpVelocityCurve;
    [SerializeField] public float RideSpringStrenght;
    [SerializeField] public float RideSpringDamper;
    [SerializeField] public float GravityForce;
    [SerializeField] public float RideHeight;
    [SerializeField] public float JumpForce;
    [SerializeField] public float CayoteTime;
    [SerializeField] public float JumpBufferingTime;

    [Space]
    [Header("Inputs")]
    [SerializeField] public EntitieInputs inputsOnStart;
    [HideInInspector] public List<Inputs> inputsRuntime;

    // Update is called once per frame

    public void Start() {
        inputsRuntime = new List<Inputs>(inputsOnStart.currents);
        _rb = GetComponent<Rigidbody>();
        _goalVelocity = Vector3.zero;
        _unitGoalDir = Vector3.zero;
        _cayoteTimeCounter = 0;
        _jumpBufferingTimeCounter = 0;
        _raycastHitted = false;
        _inputDirection = new Direction();
        _positionToLookAt = Vector3.zero;

        ChangeState(new GroundedState(this));
    }
    void Update()
    {
        CayoteTimeCheck();
        LaunchRaycast();

        _currentState.CheckForChangeInState();
    }

    private void FixedUpdate() {
        MovePlayer();
        _currentState.PhysicsUpdate();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Interactable")) {
            _interactable = other.GetComponent<Interactable>();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Interactable")) {
            _interactable = null;
        }
    }


    // ALL INPUTS ARE HERE

    public void InteractStart() {
        if (_interactable != null) {
            _interactable.InteractStart(this);
        }
    }
    public void InteractEnd() {
        if (_interactable != null) {
            _interactable.InteractEnd(this);
        }
    }

    public void Jump() {
        _jumpBufferingTimeCounter = JumpBufferingTime;
    }

    public void MoveForward(float value) {
        _inputDirection.forward = value;
    }
    public void MoveBackward(float value) {
        _inputDirection.backward = value;
    }
    public void MoveLeft(float value) {
        _inputDirection.left = value;

    }
    public void MoveRight(float value) {
        _inputDirection.right = value;
    }

    public void Shoot(){
        
    }


    // JUMP  OF PLAYER
    public bool IsGrounded() {
        return _rayHit.distance <= RideHeight;
    }

    public void ChangeState(APlayerState newState) {
        _currentState = newState; 
    }
    
    public void CayoteTimeCheck() {
        if  (IsGrounded()) {
            _cayoteTimeCounter = CayoteTime;
        }
        else if (_cayoteTimeCounter > 0) {
            _cayoteTimeCounter -= Time.deltaTime;
        }

        if (_jumpBufferingTimeCounter > 0) {
            _jumpBufferingTimeCounter -= Time.deltaTime;
        }

    }

    public bool playerJumped() {
        if ( _cayoteTimeCounter > 0 && _jumpBufferingTimeCounter > 0) {
            _cayoteTimeCounter = 0;
            _jumpBufferingTimeCounter = 0;
            return true;
        }
        return false;
    }

    private void LaunchRaycast()
    {
        Ray ray  = new Ray(transform.position -  Vector3.up * transform.localScale.y, Vector3.down);
        // debug raycast
        Debug.DrawRay(ray.origin, ray.direction * RideHeight, Color.red);
        _raycastHitted = Physics.Raycast(ray, out _rayHit);
    }


    // MOVEMENT OF PLAYER

    private void NormalizeDirectionInput()
    {
        float forward = _inputDirection.forward;
        float backward = _inputDirection.backward;
        float right = _inputDirection.right;
        float left = _inputDirection.left;

        Vector3 direction = new Vector3(right - left, 0, forward - backward);

        if (direction.magnitude > 1.0f)
            direction.Normalize();

        _unitGoalDir = direction;
    }

    private void MovePlayer() {
        NormalizeDirectionInput();

        Vector3 unitVel = _goalVelocity.normalized;

        float accelerationXYAxisValue = Vector3.Dot(_unitGoalDir, unitVel);
        float accelerationWithFactor = Acceleration * AccelerationFactor.Evaluate(accelerationXYAxisValue);

        Vector3 calculatedGoalVelocity  = _unitGoalDir * MaxSpeed;

        _goalVelocity = Vector3.MoveTowards(
           _goalVelocity,
           calculatedGoalVelocity,
           accelerationWithFactor * Time.fixedDeltaTime);

        Vector3 neededAccelerationToReachGoalVelocity = (_goalVelocity - _rb.velocity) / Time.fixedDeltaTime;

        neededAccelerationToReachGoalVelocity = Vector3.ClampMagnitude(
            neededAccelerationToReachGoalVelocity,
            MaxAcceleration);

        if (neededAccelerationToReachGoalVelocity.magnitude > 0) {
            FaceMousePosition();
            _rb.AddForce(Vector3.Scale(neededAccelerationToReachGoalVelocity * _rb.mass, ForceScale));
        }
    }

    // Model Rotation

    public void UpdateMousePosition(Vector3 point) {
        _positionToLookAt = point;
        FaceMousePosition();
    }
    private void FaceMousePosition()
    {
        PlayerModel.transform.rotation = Quaternion.Euler(0, Mathf.Atan2(_positionToLookAt.x - transform.position.x, _positionToLookAt.z - transform.position.z) * Mathf.Rad2Deg, 0);
    }

}
