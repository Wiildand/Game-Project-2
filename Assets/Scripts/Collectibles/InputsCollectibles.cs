using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputsCollectibles : MonoBehaviour
{
    private PlayerManager playerManager;
    private float initalY;



    [SerializeField]
    private float speed;
    [SerializeField]
    private float distance;

    [SerializeField]
    private GameObject text;

    [SerializeField]
    private Inputs inputs;



    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        // get the text mesh from children
        text.GetComponent<TextMeshPro>().text = inputs.ToString();
        initalY = text.transform.position.y;
    }


    private void FixedUpdate() {
          text.transform.position = new Vector3(
            text.transform.position.x, 
            initalY + Mathf.Abs(Mathf.Sin(Time.time * speed)) * 0.1f * distance,
            text.transform.position.z);    
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Player player = other.gameObject.GetComponent<Player>();
            playerManager.ChangeInputOwnerShip(inputs, player);
            Destroy(gameObject);
        }
    }
}
