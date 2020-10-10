using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefabController : MonoBehaviour
{
    // Start is called before the first frame update
    public float verticalSpeed = 5;
    public GameController bulletManager;
    public float verticalBoundary = 6;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.0f, verticalSpeed, 0.0f);
        checkBounds();
    }

    private void checkBounds()
    {
        if (transform.position.y > verticalBoundary)
        {
            bulletManager.returnBullet(gameObject);
        }
    }
}
