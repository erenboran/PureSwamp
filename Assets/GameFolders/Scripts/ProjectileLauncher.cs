using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{

    [Header("***Compenents***")]

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





        if (Input.GetMouseButtonDown(0))
        {


            pointParent.gameObject.SetActive(true);

            mouseStartPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);


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

            Jump();
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

    void LookMouse(float yDistance)
    {
        float zRotation = minRotation - (yDistance * yDistanceMultiplier);

        frogRotation.transform.rotation = Quaternion.Euler(0, 0, zRotation);

        direction = frogRotation.transform.right;


    }

    void Jump()
    {

        frogRigidbody2D.velocity = frogRotation.transform.right * jumpSpeed;

    }

    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)pointSpawnPoint.position + (direction.normalized * jumpSpeed * t) + 0.5f * Physics2D.gravity * (t * t);

        return position;
    }

    


}