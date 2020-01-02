using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    Vector2 movement;
    public Rigidbody2D rbd2;
    public Animator anim;
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //Movement
        rbd2.MovePosition(rbd2.position + movement * moveSpeed * Time.fixedDeltaTime);
        if(movement != Vector2.zero)
        {
            anim.SetFloat("movX",movement.x);
            anim.SetFloat("movY",movement.y);
        }
        anim.SetFloat("speed",movement.sqrMagnitude);
    }
}
