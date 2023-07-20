using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraOrthoSize : MonoBehaviour
{
    Camera _cam;

    private void Start() {
        _cam=Camera.main;

        _cam.orthographicSize = CalculateOrto().size;
        _cam.transform.position = CalculateOrto().center;
    }
  


    private(Vector3 center , float size) CalculateOrto()
    {
        var bounds = new Bounds();

        foreach (var col in FindObjectsOfType<Collider2D>())
        {
            bounds.Encapsulate(col.bounds);
        }

        bounds.Expand(1.2f);

        var vertical = bounds.size.y;
        var horizontal = bounds.size.x * _cam.pixelHeight / _cam.pixelWidth;

        var size = Mathf.Max(horizontal, vertical)*0.5f;
        var center = bounds.center + new Vector3(0, 0, -10);

        return (center, size);
    }
   
}
