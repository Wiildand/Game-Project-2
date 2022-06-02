using UnityEngine;
using System.Collections;

public class Dispenser : MonoBehaviour {
    public GameObject itemToShootPrefab;
    public float shootInterval = 3f;
    private float elaspedTime = 0f;

    public float shootPointOffset = 0.5f;

    private Vector3 shootPoint;
    private void Start() {

    }

    private void Update() {
        // launch a new item every shootInterval seconds
        elaspedTime += Time.deltaTime;
        if (elaspedTime >= shootInterval) {
            elaspedTime = 0f;
            Shoot();
        }
    }

    private void Shoot() {
        // create a new item
        GameObject item = Instantiate(  itemToShootPrefab,
                                        transform.position + transform.forward * shootPointOffset,
                                        transform.rotation);
        item.transform.parent = transform;
    }
}
