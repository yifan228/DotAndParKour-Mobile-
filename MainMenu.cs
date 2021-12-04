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

    [SerializeField] GameObject initialcanvas;
    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject starWarcam;
    [SerializeField] GameObject mainmenucanvas;
    [SerializeField] GameObject mainCanvas;
    [SerializeField] GameObject starWarText;
    public int SceneNum;
    public void SetLv()
    {
        Lv = int.Parse(Inputfield.text);
        gameSystem.GetComponent<GameSystem>().SetLv(Lv);
        mainCam.SetActive(false);
        foreach(GameObject can in GameObject.FindGameObjectsWithTag("UI"))
        {
            can.SetActive(false);
        }
        starWarcam.SetActive(true);
        starWarText.SetActive(true);
    }

    public void OnStartGame()
    {
        initialcanvas.SetActive(false);
        mainmenucanvas.SetActive(true);
    }

    public void OnIntroBtn()
    {
        //
    }

    public void OnDonateBtn()
    {
        //
    }

    public void backToChooseMap()
    {
        mainCanvas.SetActive(false);
    }

    public void GameStart()
    {
        SceneManager.LoadScene(SceneNum);
    }
}
