using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spikes : MonoBehaviour {

    public int delayToChangeActivityEverySecond = 5;
    public GameObject deadZone;
    public GameObject particlesContainer;


    private bool isActive = false;
    private PlayerManager _playerManager;

    private List<ParticleSystem> _particles;

    private void Awake() {
        if (delayToChangeActivityEverySecond < 0)
            throw new Exception("delayToChangeActivity must be a positive number");
        _playerManager = FindObjectOfType<PlayerManager>();

        // get all particles in the container
        _particles = new List<ParticleSystem>(particlesContainer.GetComponentsInChildren<ParticleSystem>());
    }

    private void Start() {
        StartCoroutine(ChangeActivityEveryDelay());
    }

    private IEnumerator ChangeActivityEveryDelay() {
        while (true) {
            yield return new WaitForSeconds(delayToChangeActivityEverySecond);
            ToggleColliderActivation();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Player player = other.gameObject.GetComponent<Player>();
            _playerManager.KillPlayer(player);
            
        }
    }

    private void ToggleColliderActivation() {
        
        isActive = !isActive;
        deadZone.SetActive(isActive);
        foreach (ParticleSystem particle in _particles) {
            if (isActive) {
                particle.Play();
            } else {
                particle.Stop();
            }
        }
    }
}
