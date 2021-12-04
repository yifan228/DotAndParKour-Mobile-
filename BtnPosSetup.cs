using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPosSetup : MonoBehaviour
{
    [SerializeField] GameObject joystic, dashBtn, jumpBtn,grabBtn;
    [Header("Setup")] [SerializeField] GameObject Setjoystic, SetdashBtn, SetjumpBtn;
    private void Start()
    {
        Setjoystic.transform.position = joystic.transform.position;
        SetdashBtn.transform.position = dashBtn.transform.position;
        SetjumpBtn.transform.position = jumpBtn.transform.position;
    }

    private void Update()
    {
        joystic.transform.position = Setjoystic.transform.position;
        dashBtn.transform.position = SetdashBtn.transform.position;
        jumpBtn.transform.position = SetjumpBtn.transform.position;
        grabBtn.transform.position = SetjumpBtn.transform.position;
    }

    public void BackToGame()
    {
        this.gameObject.SetActive(false);
    }
}
