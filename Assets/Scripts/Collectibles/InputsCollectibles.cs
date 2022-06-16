using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputsCollectibles : MonoBehaviour
{
    private PlayerManager playerManager;

    [SerializeField]
    private Inputs inputs;

    [SerializeField]
    private GameObject text;
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        // get the text mesh from children
        text.GetComponent<TextMeshPro>().text = inputs.ToString();
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Player player = other.gameObject.GetComponent<Player>();
            playerManager.ChangeInputOwnerShip(inputs, player);
            Destroy(gameObject);
        }
    }
}
