using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewPortManager : MonoBehaviour
{
    [SerializeField] GameObject DefCam;
    [SerializeField] GameObject ParkCam;
    [SerializeField] GameObject changeToParkBtn;
    [SerializeField] GameObject changeToDefBtn;

    public void OnClickChangeToParkBtn()
    {
        DefCam.SetActive(false);
        ParkCam.SetActive(true);
        changeToDefBtn.SetActive(true);
        changeToParkBtn.SetActive(false);
    }

    public void OnClickChangeToDefBtn()
    {
        DefCam.SetActive(true);
        ParkCam.SetActive(false);
        changeToDefBtn.SetActive(false);
        changeToParkBtn.SetActive(true);
    }
}
