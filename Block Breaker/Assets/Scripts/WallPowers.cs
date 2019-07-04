using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPowers : MonoBehaviour
{
    [Range(-2, 2)]
    [SerializeField]
    private float speedBoost = 0f;

    [SerializeField]
    private bool hasChangingBallSize = false;

    [SerializeField]
    private bool isPaddle = false;

    //cached component refs
    private GameStatus game;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        game = FindObjectOfType<GameStatus>();

        if (isPaddle)
        {
            game.IncreaseSpeedBy(float.MinValue);
            if (gameObject.transform.localScale.x <= 0.701f)
            {
                gameObject.transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
            }
            gameObject.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
            return;
        }

        game.IncreaseSpeedBy(speedBoost);

        if (hasChangingBallSize)
        {
            FindObjectOfType<Ball>().ChangeSize();
        }





        //switch (gameObject.name)
        //{
        //    case "Top Wall":
        //        status.IncreaseSpeedBy(speedBoost);
        //        break;
        //    default:
        //        Debug.Log("wtf is this bro");
        //        break;
        //}
        
    }
}
