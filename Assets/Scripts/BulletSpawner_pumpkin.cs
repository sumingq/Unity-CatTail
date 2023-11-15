using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner_pumpkin : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 10f;
    public float spawnRateMax = 30f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;


    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
