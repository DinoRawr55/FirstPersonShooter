using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;

    public float speed = 12f;

    public float gravity = -9.8f;

    public float JumpHeight = 1.5f;

    bool groundedPlayer;

    Vector3 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer=cc.isGrounded;
        if(groundedPlayer && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        cc.Move(move*speed*Time.deltaTime);

        if (Input.GetButtonDown("Jump")&&  groundedPlayer)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -3.0f * gravity);

        }
        velocity.y += gravity*Time.deltaTime;
        cc.Move(velocity*Time.deltaTime);
    }
}
