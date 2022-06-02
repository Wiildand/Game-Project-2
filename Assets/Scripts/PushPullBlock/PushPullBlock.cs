using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPullBlock : MonoBehaviour
{

    private Rigidbody _rb;
    private TeleportableEvent _teleportable;
    private Player _player;

    private void Start() {
        _teleportable = GetComponent<TeleportableEvent>();
        _rb = GetComponent<Rigidbody>();
        _rb.sleepThreshold = 0f;
        _teleportable.onTeleported += OnTeleported;
    }

    private void OnTeleported() {
        if (_player != null) {
            _player.StopInteraction();
        }
    }

    public void StartCarry(Player player)
    {
        _rb.isKinematic = true;

        float widthSize = new Vector3(
            transform.localScale.x,
            0,
            transform.localScale.z
        ).magnitude; 

        Vector3 direction = transform.position - player.transform.position;
        transform.position = player.transform.position + 
                            new Vector3(direction.normalized.x, 0, direction.normalized.z) * widthSize+
                            Vector3.up * (transform.localScale.y - player.transform.position.y) / 2;

        transform.parent = player.transform;
        _player = player;

    }

    public void StopCarry(Player player)
    {
        transform.parent = null;
        _rb.useGravity = true;
        _rb.isKinematic = false;

        _player = null;
        //_rb.velocity = player._rb.velocity;
        _rb.AddForce(player._rb.velocity, ForceMode.VelocityChange);

    }
}
