using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject _leadPrefab;

    Camera _mainCamera;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnLeaf();
        }
    }


    void SpawnLeaf()
    {
        Vector3 bottomLeft = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, _mainCamera.nearClipPlane));
        Vector3 bottomRight = _mainCamera.ViewportToWorldPoint(new Vector3(1, 0, _mainCamera.nearClipPlane));
        Vector3 middleTop = _mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1, _mainCamera.nearClipPlane));

        bottomLeft = new Vector3(bottomLeft.x + transform.position.x, bottomLeft.y, 0f);

            Debug.Log(bottomLeft);

        float spawnDistanceY = Random.Range(4.5f, middleTop.y);
        float spawnDistanceX = Random.Range(bottomLeft.x, bottomRight.x);

        Vector3 spawnPosition = new Vector3(spawnDistanceX, spawnDistanceY, 0f);

        GameObject newLeaf = Instantiate(_leadPrefab, spawnPosition, Quaternion.identity);










    }
}
