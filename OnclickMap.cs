using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OnclickMap : MonoBehaviour
{
    [SerializeField] int Num;//切場景要用到的

    [SerializeField]GameObject startcanvas;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(onclicked);
    }

    private void onclicked()
    {
        startcanvas.SetActive(true);
        startcanvas.transform.GetChild(0).transform.GetChild(0).GetComponentInChildren<Image>().sprite= GetComponent<Image>().sprite;
        startcanvas.GetComponentInChildren<Text>().text = gameObject.name;
        FindObjectOfType<MainMenu>().SceneNum = Num;
    }

}
