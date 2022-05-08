using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private APlayerState _currentState;
    private Vector3 _goalVelocity;
    private Vector3 _unitGoalDir;
    private  Interactable _interactable;



    [SerializeField] private Camera _cam;
    [SerializeField] public int Id;
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
    [SerializeField] public EntitieInputs inputs;

    // Update is called once per frame

    public void Start() {
        _rb = GetComponent<Rigidbody>();
        _goalVelocity = Vector3.zero;
        _unitGoalDir = Vector3.zero;
        _cayoteTimeCounter = 0;
        _jumpBufferingTimeCounter = 0;
        _raycastHitted = false;
        ChangeState(new GroundedState(this));
    }
    void Update()
    {
        CayoteTimeCheck();
        getMovementInputs();
        FaceMousePosition();
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

    public void Interacte() {
        if (_interactable != null) {
            _interactable.Interact();
        }
    }

    public void PressJump() {
        _jumpBufferingTimeCounter = JumpBufferingTime;
    }

    public void MoveForward(float value) {
    }
    public void MoveBackward(float value) {
    }
    public void MoveLeft(float value) {
    }
    public void MoveRight(float value) {
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
        _raycastHitted = Physics.Raycast(ray, out _rayHit);
    }


    // MOVEMENT OF PLAYER
    private void getMovementInputs()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        var inputUnitDir = new Vector3(x, 0, z);

        if (inputUnitDir.magnitude > 1.0f)
            inputUnitDir.Normalize();

        _unitGoalDir = inputUnitDir;
    }

    private void MovePlayer() {
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

        _rb.AddForce(Vector3.Scale(neededAccelerationToReachGoalVelocity * _rb.mass, ForceScale));
    }


    // Model Rotation

    private void FaceMousePosition()
    {
        Vector3 point = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        float t = _cam.transform.position.y / (_cam.transform.position.y - point.y);
        Vector3 finalPoint = new Vector3(t * (point.x - _cam.transform.position.x) + _cam.transform.position.x, 1, t * (point.z - _cam.transform.position.z) + _cam.transform.position.z);
        transform.rotation = Quaternion.Euler(0, Mathf.Atan2(finalPoint.x - transform.position.x, finalPoint.z - transform.position.z) * Mathf.Rad2Deg, 0);
    }

}
