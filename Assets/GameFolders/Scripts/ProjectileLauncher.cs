using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    
        public float power = 10f;
        public float maxDrag = 5f;
        public Rigidbody2D rb;
        public LineRenderer lr;

        SpriteRenderer _renderer;
        Vector3 dragStartPos;
        public bool isPressed = true;



        private void Awake()
        {
        }
        private void Start()
        {
        isPressed = true;

        }
        private void Update()

        {
        if (!isPressed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DragStart();
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Dragging();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                DragRelease();
                isPressed = false;

            }
        }

        }

        private void DragStart()
        {
            dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragStartPos.z = 0f;
            lr.positionCount = 1;
            lr.SetPosition(0, dragStartPos);
        }

        private void Dragging()
        {
            Vector3 draggingPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            draggingPos.z = 0f;
            lr.positionCount = 2;
            lr.SetPosition(1, draggingPos);
        }

        private void DragRelease()
        {
            lr.positionCount = 0;

            Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragReleasePos.z = 0f;

            Vector3 force = dragStartPos - dragReleasePos;
            Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;
            rb.AddForce(clampedForce, ForceMode2D.Impulse);
        }
    }
