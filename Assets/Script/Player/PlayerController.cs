using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool agarraBola = false;
    private bool inShot = false;

    [SerializeField]
    private GameObject ballPlayer;


    private void Start()
    {
        GameManager.Instance.PlayerController = this;
    }
    public void clickBall()
    {
        if (!agarraBola)
        {
            agarraBola = true;
            ballPlayer.GetComponent<BallPlayer>().moveBall();
            inShot = true;

        }
        else
        {
            ballPlayer.GetComponent<BallPlayer>().CanBreakPivot = true;
            agarraBola = false;
        }


    }
    private void Update()
    {
        if(inShot && !GameManager.Instance.GestorBall.ballsInMove())
        {
            inShot = false;
            GameManager.Instance.changePlayer(ballPlayer.GetComponent<BallPlayer>().FirstBall);
            ballPlayer.GetComponent<BallPlayer>().FirstBall = 0; 
        }

        if (!agarraBola)
        { return; }

        Vector3 posicionRaton = Input.mousePosition;
        Vector2 posicionMouseMundo = (Vector2)Camera.main.ScreenToWorldPoint(posicionRaton);
        ballPlayer.transform.position = posicionMouseMundo;

        
    }
}
