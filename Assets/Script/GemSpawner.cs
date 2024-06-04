using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GemFallScript> gemPrefap;
    public float timer;
    public float spawnInterval = 3f;
    [SerializeField] private FallType fallType;

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

        int randomIndex = Random.Range(0, gemPrefap.Count);
        fallType = (FallType)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(FallType)).Length);
        Vector3 spawnPosition = Vector3.zero;
        if (fallType == FallType.Down)
        {
             spawnPosition = new Vector3(Random.Range(-8, 8), 6f, 0);
        }
        if (fallType == FallType.Up)
        {
            spawnPosition = new Vector3(Random.Range(-8, 8), -3f, 0);
        }
        if (fallType == FallType.Left)
        {
            spawnPosition = new Vector3(8f, 0f, 0);
        }
        if (fallType == FallType.Right)
        {
             spawnPosition = new Vector3(-8f, 0f, 0);
        }

        
       GemFallScript gem = Instantiate(gemPrefap[randomIndex], spawnPosition, Quaternion.identity, this.gameObject.transform);
        gem.initData(fallType);
        
    }
    
    
}
