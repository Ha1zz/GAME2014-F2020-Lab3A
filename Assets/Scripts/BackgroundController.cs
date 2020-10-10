using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;



public class BackgroundController : MonoBehaviour
{
    public float verticalSpeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        checkBound();
    }

    private void Move()
    {
        var newPosition = new Vector3(0.0f, verticalSpeed, 0.0f);
        transform.position -= newPosition;
    }

    private void Reset()
    {
        transform.position = new Vector3(0.0f, 10.0f, 0.0f);
    }

    private void checkBound()
    {
        if (transform.position.y <= -10.0f)
        {
            Reset();
        }
    }

}
