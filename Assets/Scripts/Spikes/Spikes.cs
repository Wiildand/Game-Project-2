using System;
using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

    public int delayToChangeActivityEverySecond = 5;
    public GameObject _spikes;
    private PlayerManager _playerManager;

    private void Awake() {
        if (delayToChangeActivityEverySecond < 0)
            throw new Exception("delayToChangeActivity must be a positive number");
        _playerManager = FindObjectOfType<PlayerManager>();
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
        _spikes.SetActive(!_spikes.activeSelf);
    }
}
