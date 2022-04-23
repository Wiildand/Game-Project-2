using UnityEngine;

public class Projectile : MonoBehaviour {
    public float speed = 5f;

    private void Start() {
        MeshRenderer itemToShootMaterial = GetComponent<MeshRenderer>();
        itemToShootMaterial.material.color = Color.red;
    }

    // Update is called once per frame
    private void Update() {
        transform.position += transform.right * Time.deltaTime * speed;
    }
}
