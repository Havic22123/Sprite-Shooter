using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform tf;

    public float bulletSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Always move forward
        tf.position += tf.right * bulletSpeed * Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D otherObject)
    {
        Debug.Log("[Collision Entered] The GameObject of the other object is named: " + otherObject.gameObject.name);
        if (otherObject.gameObject != GameManager.instance.player)
        {
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);
        }
    }
}
