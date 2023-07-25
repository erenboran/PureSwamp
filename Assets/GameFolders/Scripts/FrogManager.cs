using UnityEngine;

public class FrogManager : MonoBehaviour
{

    [Header("***Compenents***")]

    [SerializeField]
    Animator frogAnimator;

    [SerializeField]
    Rigidbody2D frogRigidbody2D;
    [SerializeField]
    Transform frogRotation;
    [SerializeField]
    GameObject pointPrefab;

    [SerializeField]
    Transform pointParent;

    GameObject[] points;

    [SerializeField]
    Transform pointSpawnPoint;

    [Header("***Settings***")]

    [SerializeField]
    float minJumpForce = 4f;

    [SerializeField]
    float minRotation = 25f;

    [SerializeField]
    float xDistanceMultiplier = 1f;
    [SerializeField]
    float yDistanceMultiplier = 1f;

    float jumpSpeed;

    [SerializeField]
    int numberOfPoints;

    [SerializeField]
    float spaceBetweenPoints;

    Vector2 direction;

    Vector2 mouseStartPoint;

    Vector2 frogStartRotation;

    bool canJump = true;

    [SerializeField]
    GameObject lastLeaf;



    private void Start()
    {
        frogStartRotation = frogRotation.rotation.eulerAngles;

        points = new GameObject[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(pointPrefab, pointSpawnPoint.position, Quaternion.identity);
            points[i].transform.parent = pointParent;
        }


    }



    private void Update()
    {
        if (!canJump)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                pointParent.gameObject.SetActive(true);

                mouseStartPoint = Camera.main.ScreenToWorldPoint(touch.position);

                frogAnimator.SetBool("isGrounded", false);
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                for (int i = 0; i < numberOfPoints; i++)
                {
                    points[i].transform.position = PointPosition(i * spaceBetweenPoints);
                }

                Vector2 touchEndPoint = Camera.main.ScreenToWorldPoint(touch.position);

                float xDistance = touchEndPoint.x - mouseStartPoint.x;
                float yDistance = touchEndPoint.y - mouseStartPoint.y;

                ChangeJumpForce(xDistance);

                LookMouse(yDistance);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                pointParent.gameObject.SetActive(false);

                for (int i = 0; i < numberOfPoints; i++)
                {
                    points[i].transform.position = pointSpawnPoint.position;
                }

                if (jumpSpeed > 0)
                {
                    Jump();

                    frogAnimator.SetBool("isFlying", true);
                }
                else
                {
                    frogAnimator.SetBool("isStartJump", false);
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {


                pointParent.gameObject.SetActive(true);

                mouseStartPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                frogAnimator.SetBool("isGrounded", false);


            }

            if (Input.GetMouseButton(0))
            {
                for (int i = 0; i < numberOfPoints; i++)
                {
                    points[i].transform.position = PointPosition(i * spaceBetweenPoints);
                }

                Vector2 mouseEndPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                float xDistance = mouseEndPoint.x - mouseStartPoint.x;
                float yDistance = mouseEndPoint.y - mouseStartPoint.y;

                ChangeJumpForce(xDistance);

                LookMouse(yDistance);


            }

            if (Input.GetMouseButtonUp(0))
            {



                pointParent.gameObject.SetActive(false);

                for (int i = 0; i < numberOfPoints; i++)
                {
                    points[i].transform.position = pointSpawnPoint.position;
                }

                if (jumpSpeed > 0)
                {
                    Jump();

                    frogAnimator.SetBool("isFlying", true);
                }

                else
                {
                    frogAnimator.SetBool("isStartJump", false);

                }

            }


        }

        void ChangeJumpForce(float xDistance)
        {
            if (xDistance > 0)
            {
                pointParent.gameObject.SetActive(false);

                jumpSpeed = 0;
            }

            else
            {
                pointParent.gameObject.SetActive(true);

                jumpSpeed = minJumpForce - xDistance * xDistanceMultiplier;
            }




        }
    }

    void LookMouse(float yDistance)
    {
        float zRotation = minRotation - (yDistance * yDistanceMultiplier);

        frogRotation.transform.rotation = Quaternion.Euler(0, 0, zRotation);

        direction = frogRotation.transform.right;


    }

    void Jump()
    {

        canJump = false;
        frogRigidbody2D.velocity = frogRotation.transform.right * jumpSpeed;

    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)pointSpawnPoint.position + (direction.normalized * jumpSpeed * t) + 0.5f * Physics2D.gravity * (t * t);

        return position;
    }

    void StartingJumpAnimation()
    {
        frogAnimator.SetBool("isStartJump", true);
        frogAnimator.SetBool("isGrounded", false);
    }

    void GroundAnimation()
    {
        frogAnimator.SetBool("isFlying", false);
        frogAnimator.SetBool("isGrounded", true);
        frogAnimator.SetBool("isStartJump", false);


    }

    public void EndScene()
    {
        GameEvents.Instance.OnGameEnded?.Invoke();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            EndScene();

        }
    }






    private void OnCollisionEnter2D(Collision2D other)
    {
        GroundAnimation();



        canJump = true;

        if (lastLeaf == other.gameObject)
        {
            return;
        }

        lastLeaf = other.gameObject;

        GameEvents.Instance.OnEnteredLeaf?.Invoke();

        if (other.gameObject.CompareTag("Leaf"))
        {
            GameEvents.Instance.OnScoreChanged?.Invoke(1);
        }

        else if (other.gameObject.CompareTag("Bowl"))
        {

            GameEvents.Instance.OnScoreChanged?.Invoke(5);

        }

    }




}