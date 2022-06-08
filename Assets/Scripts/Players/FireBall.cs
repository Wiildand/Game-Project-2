using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Rigidbody _rb;

    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Player")) {
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
