using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPullBlock : MonoBehaviour
{

    private Rigidbody _rb;
    private TeleportableEvent _teleportable;
    private Player _player;

    private float minDistance;

    private void Start() {
        _teleportable = GetComponent<TeleportableEvent>();
        _teleportable.onTeleported += OnTeleported;
        _rb = GetComponent<Rigidbody>();
        minDistance = _rb.transform.localScale.y * 1.75f;
    }

    private void OnTeleported() {
        if (_player != null) {
            _player.StopInteraction();
        }
    }


    public void StartCarry(Player player)
    {

        Vector3 directionNormalized = (_rb.transform.position - player.transform.position).normalized;
        float offset = Mathf.Abs(Mathf.Abs(directionNormalized.x) - Mathf.Abs(directionNormalized.z));
        float offsetDiagonal = (1 - offset) * minDistance;
        float offsetPerpendicular = offset * minDistance;

        _rb.useGravity = false;

        _rb.transform.position = player.transform.position + 
                                new Vector3(directionNormalized.x, 0, directionNormalized.z) * 
                                (offsetDiagonal + offsetPerpendicular + minDistance);


        _rb.transform.parent = player.transform;
        _player = player;

    }

    private void Update() {
    }

    public void StopCarry(Player player)
    {
        _rb.transform.parent = transform;
        _rb.useGravity = true;

        _player = null;
        _rb.AddForce(player._rb.velocity, ForceMode.VelocityChange);
       
    }
}
