using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform tf;

    public float rotationSpeed = 1.0f;
    public float movementSpeed = 1.0f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        if (GameManager.instance.player == null)
        {
            GameManager.instance.player = this.gameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tf.position += tf.right * movementSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            tf.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            tf.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            tf.position += tf.right * -movementSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Debug.Log("Shooting!");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnCollisionEnter2D(Collision2D otherObject)
    {
        Debug.Log("[Collision Entered] The GameObject of the other object is named: " + otherObject.gameObject.name);
    }

    void OnCollisionExit2D(Collision2D otherObject)
    {
        Debug.Log("[Collision Exited] The GameObject of the other object is named: " + otherObject.gameObject.name);
    }

    void OnDestroy()
    {
        // If the player dies, they lose a life.
        GameManager.instance.Die();
    }


}
