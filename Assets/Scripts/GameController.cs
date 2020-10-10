using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[System.Serializable]
public class GameController : MonoBehaviour
{
    public GameObject bullet;
    public Queue<GameObject> bulletPool;
    public int maxBullets;

    // Start is called before the first frame update
    void Start()
    {
        BuiltBulletPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuiltBulletPool()
    {
        bulletPool = new Queue<GameObject>();
        for (int count = 0; count < maxBullets; count++)
        {
            var tempBullet = Instantiate(bullet);
            tempBullet.SetActive(false);
            tempBullet.transform.parent = transform;
            bulletPool.Enqueue(tempBullet);
        }
    }
    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    public void returnBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        bulletPool.Enqueue(returnedBullet);
    }
}
