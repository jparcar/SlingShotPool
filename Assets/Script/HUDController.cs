using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool butted = false;
    


    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickInBall()
    {
        Vector3 posicionRaton = Input.mousePosition;
        Vector2 posicionMundo = (Vector2)Camera.main.ScreenToWorldPoint(posicionRaton);
        transform.position = posicionMundo;
    }
}
