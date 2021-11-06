using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateWeaponBtnManager : MonoBehaviour
{
    //存放towertankprefab
    public static CreateWeaponBtnManager instance;
    public List<CreateWeaponBtn> btnList = new List<CreateWeaponBtn>();

    [Header("Btns")][SerializeField] GameObject Btn0Add,Btn1Add,Btn0Cancel,Btn1Cancel;

    [Header("Tanks")]
    [SerializeField] GameObject[] tanks;

    void AddBtn(string tankTypeName,GameObject towerTankType,Sprite uiDragTankImage)
    {
        btnList.Add(new CreateWeaponBtn { name = tankTypeName, tankType = towerTankType, UIDragTankImage = uiDragTankImage });
    }

    void RemoveBtn(string thename)
    {
        for(int i= 0;i<btnList.Count;i++)
        {
            if (btnList[i].name == thename)
                btnList.Remove(btnList[i]);
        }
    }

    public void AddTank0()
    {
        string st0 = Btn0Add.GetComponentInChildren<Text>().text;
        AddBtn(st0,tanks[0],tanks[0].GetComponent<SpriteRenderer>().sprite);
        Btn0Add.SetActive(false);
        Btn0Cancel.SetActive(true);
    }
    public void CancelTank0(string st)
    {
        RemoveBtn(st);
        Btn0Cancel.SetActive(false);
        Btn0Add.SetActive(true);
    }

    public void AddTank1()
    {
        string st1 = Btn1Add.GetComponentInChildren<Text>().text;
        AddBtn(st1, tanks[1], tanks[1].GetComponent<SpriteRenderer>().sprite);
        Btn1Add.SetActive(false);
        Btn1Cancel.SetActive(true);
    }
    public void CancelTank1(string st)
    {
        RemoveBtn(st);
        Btn1Cancel.SetActive(false);
        Btn1Add.SetActive(true);
    }

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        Btn0Add.GetComponent<Button>().onClick.AddListener(AddTank0);
        Btn0Cancel.GetComponent<Button>().onClick.AddListener(() => CancelTank0(Btn0Add.GetComponentInChildren<Text>().text));
        Btn1Add.GetComponent<Button>().onClick.AddListener(AddTank1);
        Btn1Cancel.GetComponent<Button>().onClick.AddListener(()=>CancelTank1(Btn1Add.GetComponentInChildren<Text>().text));
        Btn0Cancel.SetActive(false);
        Btn1Cancel.SetActive(false);
    }
}
