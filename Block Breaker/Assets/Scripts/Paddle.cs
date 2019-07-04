using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float minX = 1f;

    [SerializeField]
    private float maxX = 15;

    [SerializeField]
    private float screenWidthUnits = 16f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosUnits = Input.mousePosition.x * screenWidthUnits / Screen.width;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y)
        {
            x = Mathf.Clamp(mousePosUnits, minX, maxX)
        };
        transform.position = paddlePos;
    }
}
