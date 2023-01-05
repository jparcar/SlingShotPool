using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDStartScene : MonoBehaviour
{
    public GameObject imageClick;
    private float changeColor=0,velocityChangeColor=0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeColor += Time.deltaTime * velocityChangeColor;
        if (changeColor < 0 || changeColor>1)
        {
            velocityChangeColor = velocityChangeColor * (-1);
        }
        Color color = imageClick.GetComponent<Image>().color;
        imageClick.GetComponent<Image>().color= new Color(color.r, color.g,color.b,changeColor);
    }

    public void changeToGame()
    {
        SceneManager.LoadScene(0);
    }
}
