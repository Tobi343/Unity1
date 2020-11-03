using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    enum direction
    {
        up,
        down,
        right,
        left
    }
    private Rigidbody2D rb;
    private Vector2 movement;
    private direction dir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = direction.right;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchMove();
        MoveAndRotatePacMan();
    }

    private void MoveAndRotatePacMan()
    {
        Vector2 move = new Vector2(0, 0);
        switch (dir)
        {
            case direction.up:
                move.y = 1;
                rb.MovePosition(rb.position + move * speed * Time.deltaTime);
                transform.localRotation = Quaternion.Euler(0, 0, 90);
                break;
            case direction.down:
                move.y = -1;
                rb.MovePosition(rb.position + move * speed * Time.deltaTime);
                transform.localRotation = Quaternion.Euler(0, 0, 270);
                break;
            case direction.left:
                move.x = -1;
                rb.MovePosition(rb.position + move * speed * Time.deltaTime);
                transform.localRotation = Quaternion.Euler(0, 0, 180);
                break;
            case direction.right:
                move.x = 1;
                rb.MovePosition(rb.position + move * speed * Time.deltaTime);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }

    private void SwitchMove()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (movement.x != 1 && movement.y != 1)
        {
            if (movement.x > 0.01f) dir = direction.right;
            else if (movement.x < -0.01f) dir = direction.left;
            else if (movement.y > 0.01f) dir = direction.up;
            else if (movement.y < -0.01) dir = direction.down;
        }
    }


}
