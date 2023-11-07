using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float leftBound = -20;

    // Update is called once per frame
    void Update()
    {
        if (!GameController.gameOver)
        {
            transform.Translate(Vector3.left * GameController.speed * Time.deltaTime);
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacles"))
        {
            Destroy(gameObject);
        }
    }
}
