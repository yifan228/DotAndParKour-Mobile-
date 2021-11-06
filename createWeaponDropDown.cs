using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class createWeaponDropDown : MonoBehaviour
{
    List<GameObject> buttons;
    Dropdown dropdown;
    private void Start()
    {
        dropdown = GetComponent<Dropdown>();
        dropdown.ClearOptions();
        buttons = new List<GameObject>();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Btn");
        if (objs is null) return;
        foreach(GameObject obj in objs)
        {
            buttons.Add(obj);
            dropdown.options.Add(new Dropdown.OptionData() { text = obj.name });
            obj.SetActive(false);
        }
        objs[0].SetActive(true);
        dropdown.onValueChanged.AddListener((Dropdown)=>chooseBtn(dropdown)) ;
        
    }

    void chooseBtn(Dropdown d)
    {
        foreach(GameObject btn in buttons)
        {
            if(btn.name == d.options[d.value].text)
            {
                btn.SetActive(true);
            }
            else { btn.SetActive(false); }
        }
    }
}
