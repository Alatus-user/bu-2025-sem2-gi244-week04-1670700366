using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    private InputAction moveAction;
    private InputAction shootAction;
    public float xRange = 10f;

    public GameObject bonePrefabs;
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");

    }

    // Update is called once per frame
    void Update()
    {

        var hInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(Vector3.right * hInput * moveSpeed * Time.deltaTime);

        if( transform.position.x > xRange )
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        else if( transform.position.x < -xRange )
        {
            transform.position = new Vector3(-10f, transform.position.y, transform.position.z);
        }

        if (shootAction.triggered)
        {
            var bone = Instantiate(bonePrefabs, transform.position, Quaternion.identity);
            Destroy(bone, 1f);
        }



    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        /*Gizmos.DrawSphere(transform.position,1f);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position,Camera.main.transform.position);*/

        Vector3 left = new Vector3  (-10f, transform.position.y, transform.position.z);
        Vector3 right = new Vector3 (10f, transform.position.y, transform.position.z);

        Gizmos.DrawLine(left, right);


        Gizmos.color = Color.green;
        Gizmos.DrawSphere(left, 0.5f);
        Gizmos.DrawSphere(right, 0.5f);
    }
}
