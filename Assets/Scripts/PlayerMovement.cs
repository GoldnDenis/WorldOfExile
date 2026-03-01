using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public InputAction playerControls;
    
    public float movementSpeed;
    public Vector2 movementDirection;

    public float lastHorizontalVector;
    public float lastVerticalVector;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    
    void Update() // Frame rate dependant
    {
        InputManagement();
    }

    private void FixedUpdate() // Frame rate independent
    {
        Move();
    }

    void InputManagement()
    {
        /*  Unity6 Deprecated code - InputManager */
        // float x = Input.GetAxisRaw("Horizontal");
        // float z = Input.GetAxisRaw("Vertical");
        // direction = new Vector2(x,z).normalized;
        
        movementDirection = playerControls.ReadValue<Vector2>();

        if (movementDirection.x != 0)
        {
            lastHorizontalVector = movementDirection.x;
        }

        if (movementDirection.y != 0)
        {
            lastVerticalVector = movementDirection.y;
        }
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(movementDirection.x * movementSpeed, movementDirection.y * movementSpeed);
    }
}
