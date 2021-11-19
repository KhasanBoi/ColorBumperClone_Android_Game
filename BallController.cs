using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float thrust = 150f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float wallDistance = 5;
    [SerializeField] private float minCamDistance = 3f;
    
    private Vector2 lastMousePos;

    // Update is called once per frame
    void Update()
    {
        Vector2 deltaMousePos = Vector2.zero;
        
        if(Input.GetMouseButton(0))
        {
            Vector2 curMousePos = Input.mousePosition;
            if(lastMousePos == Vector2.zero)
            {
                lastMousePos = curMousePos;
            }
            deltaMousePos = curMousePos - lastMousePos;
            lastMousePos = curMousePos;

            Vector3 force = new Vector3(deltaMousePos.x, 0, deltaMousePos.y)*thrust;
            rb.AddForce(force);
        }
        else
        {
            lastMousePos = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
          rb.MovePosition(transform.position + Vector3.forward* 5 * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        Vector3 pos3d = transform.position;
        if(transform.position.x < -wallDistance+1)
        {
            pos3d.x = -wallDistance+1;
        }
        else if(transform.position.x > wallDistance-1)
        {
            pos3d.x = wallDistance-1;
        }
        if(transform.position.z < Camera.main.transform.position.z+minCamDistance)
        {
            pos3d.z = Camera.main.transform.position.z + minCamDistance;
        }
        transform.position = pos3d;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BadCube")
        {
            FindObjectOfType<GameManager>().EndGame();   
        }
    }
}
