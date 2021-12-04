using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourGm : MonoBehaviour
{
    [SerializeField] GameObject setUIPosCanvas;
    public void SetUIPos()
    {
        setUIPosCanvas.SetActive(true);
    }
}
