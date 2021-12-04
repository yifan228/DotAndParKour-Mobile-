using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CreateWeaponSys : MonoBehaviour //create uidrag!!(Decide what condition can create a weapon)
{
    //最初的 基礎lv 玩家可以升級工廠而升級   createweaponSys>>>uidrag>>>abweapon
    //public void SetLvFromBrocast(object Source, int lv)
    //{
    //    comderFactoryLv = lv;
    //    //Debug.Log("weponSetLv" + lv);
    //}
    public int comderFactoryLv = 1;

    private int money;
    public int Money { get => money; set => money = value; }

    public void SetMoneyFromBrocast(object Source, int mony)
    {
        money = mony;
    }
    //money per tank (set in panel)
    //public int WeaponCost { get; set; }

    private ArrayList towerMountingSlot = new ArrayList();
    public int MountUpperBound=4;

    //[SerializeField] Camera DefCamera;
    [SerializeField]List<GameObject> Weapons;
    private int nowWeapon = 0;
    public int NowWeapon { get => nowWeapon; set => nowWeapon = value; }

    [Header("Btn")] [SerializeField]GameObject PrototypeBtn;
    [SerializeField] GameObject  weponImgeOnPort;//weponUI 
    [SerializeField] GameObject weaponBtnPos;

    private void Awake()//比createDropDown還要早才行
    {
        foreach (CreateWeaponBtn btn in CreateWeaponBtnManager.instance.btnList)
        {
            
            GameObject obj = Instantiate(PrototypeBtn);
            obj.transform.SetParent(GameObject.Find("MainCanvas").transform);
            obj.transform.position = weaponBtnPos.transform.position;
            obj.name = btn.name;
            obj.GetComponentInChildren<Text>().text ="製造"+"\n"+btn.name;
            BtnProperties prop = obj.GetComponent<BtnProperties>();
            prop.BtnName = btn.name;
            prop.BtnSpite = btn.UIDragTankImage;
            prop.BtnTank = btn.tankType;
            prop.TankCost = btn.TankCost;
            obj.GetComponent<Button>().onClick.AddListener(createWeapon);
        }
    }

    void Update()
    {
        foreach (GameObject tower in towerMountingSlot)
        {
            tower.transform.SetParent(transform);
            //tower.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    public void Remove(GameObject tower)
    {
        towerMountingSlot.Remove(tower);
    }
    

    //button create primary wepon
    public void createWeapon()
    {
        if (GameManager.instance.Money>= GameObject.FindObjectOfType<BtnProperties>().TankCost && towerMountingSlot.Count <= MountUpperBound-1)
        {            
            GameObject tempObj = Instantiate(weponImgeOnPort);                  
            towerMountingSlot.Add(tempObj);
            UIDrag uIDrag = tempObj.GetComponent<UIDrag>();

            uIDrag.FactoryLv = this.comderFactoryLv;//等級可能可以跟一些數值有關係，數值（武器等級之外的）在uidrag處理
            uIDrag.towerTank = GameObject.FindObjectOfType<BtnProperties>().BtnTank;
            uIDrag.GetComponent<Image>().sprite = uIDrag.towerTank.GetComponent<SpriteRenderer>().sprite;
            GameManager.instance.Money -= GameObject.FindObjectOfType<BtnProperties>().TankCost;
            GameManager.instance.OnBroadCastMoney();
        }
    }
    
}
