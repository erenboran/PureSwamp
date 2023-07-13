using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeafController : MonoBehaviour
{
    [Range(0.1f, 5f)] [SerializeField] float _min = 0.1f;
    [Range(6f, 15f)] [SerializeField] float _max = 15f;
    

    FrogController _leafPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    void Spawn()
    {
        FrogController newLeaf = Instantiate(_leafPrefab, transform.position, transform.rotation);

    }
}
