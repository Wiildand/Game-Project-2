using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Rigidbody _rb;

    private float liveTime = 0.0f;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.isTrigger || other.transform.CompareTag("Player")) {
            return;
        }
        Destroy(gameObject);
    }

    private void FixedUpdate() {
        liveTime += Time.deltaTime;
        if (liveTime > 5.0f) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) {
        //ignore collision if player
        if (other.transform.CompareTag("Player")) {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
            return;
        }
        Destroy(gameObject);
    }
    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    public void Shoot(Player player, float speed) {

        transform.rotation = Quaternion.LookRotation(player.lookAt.normalized);
        _rb.AddForce(player.lookAt.normalized * speed, ForceMode.Impulse);
    }
}
