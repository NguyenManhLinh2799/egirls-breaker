using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Config params
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1.5f;
    [SerializeField] float maxX = 14.5f;

    // Cached references
    GameSession gameSession;
    ChadBall chadBall;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        chadBall = FindObjectOfType<ChadBall>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = new Vector2(GetXPos(), transform.position.y);
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        transform.position = newPosition;
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return chadBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
