using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    public GameObject spawn;
    public float rate;
    public int quantity;
    public float startRate;

    void Start()
    {
        startRate = rate;
    }
    void Update()
    {
        if (rate > 0) {
            rate -= Time.deltaTime;
        } 
        
        if (rate <= 0) {
            Spawn();
            rate = startRate;
        }
    }

    void Spawn() {
        float randomX = Random.Range(-45f, -80f);
        float randomY = Random.Range(0f, 360f);

        GameObject spawnInstance = Instantiate(spawn, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
        spawnInstance.GetComponent<Rigidbody>().AddForce(Random.Range(-5, 5), Random.Range(0, 5), Random.Range(-5, 5), ForceMode.Impulse);
    }
}
