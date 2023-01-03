using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorBall : MonoBehaviour
{
    private List<Ball> balls = new List<Ball>();

    public List<Ball> Balls { get => balls; set => balls = value; }

  
    // Update is called once per frame
    void Update()
    {
        
    }
    public bool ballsInMove()
    {
        foreach(Ball ball in Balls)
        {
            if (!ball.QuietBall)
            {
                return true;
            }
        }
        return false;
    }
}
