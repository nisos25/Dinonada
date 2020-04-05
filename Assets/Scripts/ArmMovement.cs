using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    private Rigidbody2D armRigidbody;
    [SerializeField] private float armVelocity;

    private void Awake()
    {
        armRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var h = Input.GetAxis("Mouse X");
        var v = Input.GetAxis("Mouse Y");

        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject.Find("PattyPool").GetComponent<PattyPool>().SpawnPatty(transform.position);
        }
        
        MoveArm(h, v);
    }

    private void MoveArm(float horizontalDirection, float verticalDirection)
    {
        armRigidbody.velocity = new Vector2(horizontalDirection * armVelocity, verticalDirection * armVelocity);
    }
}