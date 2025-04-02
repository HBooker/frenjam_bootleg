using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float velocity = 20.0f;
    public Animator camAnim;

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
        CheckForHeadBob();

        camAnim.SetBool("isWalking", isWalking);
    }

    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);
        movementVector = (inputVector * velocity) + (Vector3.up * gravity);
    }

    void MovePlayer()
    {
        control.Move(movementVector * Time.deltaTime);
    }

    void CheckForHeadBob()
    {
        if(control.velocity.magnitude > 0.1f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
}
