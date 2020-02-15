using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform tf;
    public float rotationSpeed = 1.0f;
    public float movementSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        tf = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        GameManager.instance.enemiesList.Add(this.gameObject);
        // Aim at the player at start
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, tf.position, movementSpeed * Time.deltaTime);
        // Always move forward
    }

    void OnDestroy()
    {
        GameManager.instance.enemiesList.Remove(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject == GameManager.instance.player)
        {
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);
        }

    }

}
