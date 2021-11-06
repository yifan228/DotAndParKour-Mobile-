using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private int Lv;
    [SerializeField] InputField Inputfield;

    [SerializeField] GameObject gameSystem;

    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject starWarcam;
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject starWarText;

    public void SetLv()
    {
        Lv = int.Parse(Inputfield.text);
        gameSystem.GetComponent<GameSystem>().SetLv(Lv);
        mainCam.SetActive(false);
        mainCanvas.SetActive(false);
        starWarcam.SetActive(true);
        starWarText.SetActive(true);
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
}
