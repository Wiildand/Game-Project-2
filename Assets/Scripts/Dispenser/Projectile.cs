using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed = 5f;
    public float lifeTime = 5f;

    private PlayerManager _playerManager;


    private void Awake() {
        _playerManager = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    private void Update() {
        // kill the projectile after lifeTime seconds
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0) {
            Destroy(gameObject);
        }
        transform.position += transform.forward * Time.deltaTime * speed;
        
    }

    private void OnTriggerEnter(Collider collision) {
        
        if (collision.isTrigger) {
            return;
        }

        if (collision.gameObject.tag == "Player") {
            Player player = collision.gameObject.GetComponent<Player>();
            _playerManager.KillPlayer(player);
        } 
        Destroy(gameObject);
    }

}
