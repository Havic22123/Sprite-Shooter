using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hax : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        GameManager.instance.score += 10;
    }
}
