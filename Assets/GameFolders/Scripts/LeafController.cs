using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeafController : MonoBehaviour
{
    // public GameObject leafPrefab;
    // [Range(3f, 5f)] [SerializeField] float _spawnDistanceMin = 4f;
    // [Range(4f, 7f)] [SerializeField] float _spawnDistanceMax = 5f;
    // float _fixedYPosition = -4.28f;


    // bool _spawnedLeaf;
    // bool _leafColliderControl;

    // ProjectileLauncher _frogController;

    // void Start()
    // {
    //     _spawnedLeaf = false;
    //     _leafColliderControl = true;

    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     ProjectileLauncher frogController = collision.collider.GetComponent<ProjectileLauncher>();

    //     if (frogController != null && _leafColliderControl)
    //     {
    //         _leafColliderControl = false;
    //         GameManager.Instance.IncreaseScore(1);
    //         frogController.isPressed = true;
    //     }


    //     _spawnedLeaf = true;
    //     SpawnLeaf();
    //  //   frogController.enabled = false;
    // }

    // public void SpawnLeaf()
    // {
    //     if(_spawnedLeaf == true)
    //     {
    //         float spawnDistance = Random.Range(_spawnDistanceMin, _spawnDistanceMax);
    //         Vector3 spawnPosition = transform.position + new Vector3(spawnDistance, 0f, 0f);
    //         spawnPosition.y = _fixedYPosition;
    //         GameObject newLeaf = Instantiate(leafPrefab, spawnPosition, Quaternion.identity);
    //         newLeaf.transform.parent = this.transform;
    //         _spawnedLeaf = false;

    //     }
    // }
}

