using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    public List<GameObject> gemPrefap;
    public float timer;
    public float spawnInterval = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnGem();
            timer = 0;
        }
    }
    void SpawnGem()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8, 8), 6f, 0);
        int randomIndex = Random.Range(0,gemPrefap.Count);
        Instantiate(gemPrefap[randomIndex], spawnPosition, Quaternion.identity, this.gameObject.transform);
    }
}
