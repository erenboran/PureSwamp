using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject _leafPrefab,_bowlOfFlowersPrefab;

    [SerializeField]
    int leafRandomRatio =4, bowlOfFlowersRandomRatio = 1;

    [SerializeField]
    bool randomY;

    [SerializeField]
    Transform spawnPointLeft, spawnPointRight;

    float startY;

    Camera _mainCamera;

    private void OnEnable()
    {
        GameEvents.Instance.OnEnteredLeaf += Spawn;
    }

    private void OnDisable()
    {
        GameEvents.Instance.OnEnteredLeaf -= Spawn;
    }


    void Start()
    {
        startY = spawnPointLeft.position.y;
        _mainCamera = Camera.main;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnLeaf();
        }
    }

    void Spawn()
    {
         int randomPrefab = Random.Range(0, leafRandomRatio + bowlOfFlowersRandomRatio);

        if (randomPrefab < leafRandomRatio)
        {
            SpawnLeaf();
        }
        else
        {
            SpawnBowlOfFlowersPrefab();
        }
    }


     void SpawnBowlOfFlowersPrefab()
    {
      

        Vector3 spawnPosition = new Vector3(Random.Range(spawnPointLeft.position.x, spawnPointRight.position.x), startY, 0f);

        GameObject newLeaf = Instantiate(_bowlOfFlowersPrefab, spawnPosition, Quaternion.identity);


    }


    void SpawnLeaf()
    {
        
        Vector3 spawnPosition = new Vector3(Random.Range(spawnPointLeft.position.x, spawnPointRight.position.x), startY, 0f);

        GameObject newLeaf = Instantiate(_leafPrefab, spawnPosition, Quaternion.identity);


    }
}
