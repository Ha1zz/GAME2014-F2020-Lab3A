using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefabController : MonoBehaviour
{
    public GameController gameController;
    public float horizontalBoundary;
    public float horizontalSpeed;
    public float maximumVelocityX;
    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var touch in Input.touches)
        {

            if (Camera.main.ScreenToWorldPoint(touch.position).x > transform.position.x)
            {
                rigidBody.velocity = Move(1.0f) * 0.90f;
            }
            if (Camera.main.ScreenToWorldPoint(touch.position).x < transform.position.x)
            {
                rigidBody.velocity = Move(-1.0f) * 0.90f;
            }
        }



        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            //rigidBody.velocity += Move(1.0f);
            rigidBody.velocity = Move(1.0f) * 0.90f;
            //rigidBody.AddForce(rigidBody.velocity *= Move(1.0f));
        }
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            //rigidBody.velocity += Move(-1.0f);
            rigidBody.velocity = Move(-1.0f) * 0.90f;
            //rigidBody.AddForce(rigidBody.velocity *= Move(-1.0f));
        }
        checkBounds();

        if (Time.frameCount % 40 == 0)
        {
            gameController.GetBullet(transform.position);
        }
    }

    private void checkBounds()
    {
        if (transform.position.x <= -horizontalBoundary)
        {
            transform.position = new Vector3(-horizontalBoundary, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= horizontalBoundary)
        {
            transform.position = new Vector3(horizontalBoundary, transform.position.y, transform.position.z);
        }
    }



    private Vector2 Move(float direction)
    {
        var newVelocity = rigidBody.velocity + new Vector2(horizontalSpeed * direction, 0.0f);
        return Vector2.ClampMagnitude(newVelocity, maximumVelocityX);
        //rigidBody.AddForce(rigidBody.velocity *= Move(-1.0f));
        //return new Vector2(horizontalSpeed * direction, 0.0f);
    }
}
