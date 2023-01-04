using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject idPlayerText;

    [SerializeField]
    private GameObject esceneWin;
    private GameObject textPlayerWin;

    public void Start()
    {
        GameManager.Instance.HUDPlayer = this;
    }
    public void setTextPlayer(string text)
    {
        //print("JUGADOR: "+text +" "+ idPlayerText);
        idPlayerText.GetComponent<TMPro.TextMeshProUGUI>().text = text;

    }
    public string getTextPlayer()
    {
        return idPlayerText.GetComponent<TMPro.TextMeshProUGUI>().text ;
    }

    public void showWinEscene()
    {
        esceneWin.SetActive(true);
        textPlayerWin.GetComponent<TextMeshPro>().text += getTextPlayer();
    }
}
