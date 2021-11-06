using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    private int lv;
    private GameObject gm;

    public List<GameObject> Towers;
    //public List<Vector2> Towerspos;

    public void SetLv(int Lv)
    {
        lv = Lv;
    }//this method used for button SetLevel
    
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += oncseneloaded;
    }

    public void oncseneloaded(Scene scene, LoadSceneMode mode)
    {
        //Invoke("SetGM", 0.1f);
        SetGM();
    }

    public void SetGM()
    {

       if( GameObject.Find("GameManager").GetComponent<GameManager>() != null)
        {
            GameManager gm =  GameObject.Find("GameManager").GetComponent<GameManager>();
            gm.Lv = lv;
            gm.Sys = this;

        }
        else
        {
            return;
        }
    }
}
