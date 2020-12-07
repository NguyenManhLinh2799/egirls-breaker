using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Simps : MonoBehaviour
{
    [SerializeField] float leftDistance = 3f;
    [SerializeField] float rightDistance = 3f;
    [SerializeField] float deltaX = 0.1f;

    private float leftEdge;
    private float rightEdge;

    // Start is called before the first frame update
    void Start()
    {
        leftEdge = transform.position.x - leftDistance;
        rightEdge = transform.position.x + rightDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= leftEdge || transform.position.x >= rightEdge)
        {
            deltaX *= -1;
        }
        float newX = transform.position.x + deltaX;
        Vector2 newPos = new Vector2(newX, transform.position.y);
        transform.position = newPos;
    }
}
