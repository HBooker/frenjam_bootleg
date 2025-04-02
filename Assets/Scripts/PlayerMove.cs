using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float velocity = 10.0f;
    public Animator camAnim;
    public float momentumDamping = 5.0f;

    private CharacterController control;
    private Vector3 inputVector;
    private Vector3 movementVector;
    private float gravity = -10.0f;
    private bool isWalking = false;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
        camAnim.SetBool("isWalking", isWalking);
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        
        if (hAxis != 0.0f || vAxis != 0.0f)
        {
            inputVector = new Vector3(hAxis, 0.0f, vAxis);
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);
            isWalking = true;
        }
        else
        {
            // No input this frame, decelerate
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentumDamping * Time.deltaTime);
            isWalking = false;
        }

        movementVector = (inputVector * velocity) + (Vector3.up * gravity);
    }

    void MovePlayer()
    {
        control.Move(movementVector * Time.deltaTime);
    }
}
