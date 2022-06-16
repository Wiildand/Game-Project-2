using UnityEngine;
using System.Collections;

public class Dispenser : MonoBehaviour {
    public GameObject itemToShootPrefab;
    public Transform placeToShoot;
    public float shootInterval = 3f;
    private float elaspedTime = 0f;

    private Vector3 shootPoint;

    private bool canShoot = true;

    public void StopShooting() {
        canShoot = false;
        elaspedTime = 0f;
    }

    public void StartShooting() {
        canShoot = true;
    }

    private void Update() {
        if (canShoot) {
            elaspedTime += Time.deltaTime;
            if (elaspedTime >= shootInterval) {
                elaspedTime = 0f;
                Shoot();
            }
        }
    }

    private void Shoot() {
        // create a new item
        GameObject item = Instantiate(  itemToShootPrefab,
                                        placeToShoot.position,
                                        transform.rotation);
        item.transform.parent = transform;
    }
}
