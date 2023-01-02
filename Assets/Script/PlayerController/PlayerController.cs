using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool agarraBola = false;

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

        }
        else
        {
            ballPlayer.GetComponent<BallPlayer>().CanBreakPivot = true;
            agarraBola = false;
        }


    }
    private void Update()
    {


        if (!agarraBola)
        { return; }

        Vector3 posicionRaton = Input.mousePosition;
        Vector2 posicionMouseMundo = (Vector2)Camera.main.ScreenToWorldPoint(posicionRaton);
        ballPlayer.transform.position = posicionMouseMundo;

        
    }
}
