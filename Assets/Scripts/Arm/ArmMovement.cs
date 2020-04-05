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
        var horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Mouse Y");
        
        armRigidbody.velocity = new Vector2(horizontal * armVelocity, vertical * armVelocity);
        
    }
}