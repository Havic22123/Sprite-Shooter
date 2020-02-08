using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    private Transform tf;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tf.position += tf.right * movementSpeed * Time.deltaTime;
    }
    void OnTriggerExit2D(Collider2D Player)
    {
        Destroy(Player.gameObject);
    }

    void OnDestroy()
    {
        Debug.Log("DEAD");
    }
    }
