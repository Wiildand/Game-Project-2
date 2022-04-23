using UnityEngine;
using System.Collections;

public class Dispenser : MonoBehaviour {
    public GameObject itemToShootPrefab;
    public float shootStartDelay = 0.1f;
    public float shootInterval = 3f;
    public Transform maxPosition;

    private void Start() {
        StartCoroutine(ShootObject(shootInterval));
    }

    private IEnumerator ShootObject(float delay) {
        yield return new WaitForSeconds(delay + shootStartDelay);
        shootStartDelay = 0f;
        GameObject item = Instantiate(itemToShootPrefab, transform.position, transform.rotation);
        float distance = Vector3.Distance(transform.position, maxPosition.position);
        float timeBetweenObjects = distance / item.GetComponent<Projectile>().speed;

        Destroy(item, timeBetweenObjects);
        StartCoroutine(ShootObject(shootInterval));
    }
}
