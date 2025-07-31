using UnityEngine;

public class playermove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

   
    private Rigidbody rb;
    private Vector3 moveInput;
    private bool isGrounded;

    
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
       
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);

        
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

   
    void FixedUpdate()
    {
        
        Vector3 targetVelocity = moveInput.normalized * moveSpeed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);
    }
}

