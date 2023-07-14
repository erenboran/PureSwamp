using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isPressed = false;
    private float releaseDelay = 0.15f;
    private float maxDragDistance = 25f;
    private float maxForce = 2500f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isPressed)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            float distance = Vector3.Distance(transform.position, mousePosition);
            distance = Mathf.Clamp(distance, 0f, maxDragDistance);

            if (Input.GetMouseButtonUp(0))
            {
                isPressed = false;
                rb.isKinematic = false;
                rb.AddForce(transform.forward * distance * maxForce / maxDragDistance, ForceMode2D.Impulse);
            }
        }
     }

     private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }


}


