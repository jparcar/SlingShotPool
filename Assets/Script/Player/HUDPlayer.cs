using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject idPlayerText;

    [SerializeField]
    private GameObject esceneWin;
    private GameObject textPlayerWin;
    [SerializeField]
    private GameObject buttonEnd;

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
        buttonEnd.SetActive(true);
        esceneWin.SetActive(true);
        buttonEnd.GetComponent<Button>().onClick.AddListener(() => { SceneManager.LoadScene(1); });
        textPlayerWin.GetComponent<TMPro.TextMeshProUGUI>().text += getTextPlayer();
    }
}
