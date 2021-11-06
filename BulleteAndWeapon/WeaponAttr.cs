using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttr : MonoBehaviour//目前先不要做好了
{
    private bool canclick = true;
    public bool Canclick{ get => canclick; set => canclick = value; }

    public int Level;

    private float permeability;
    public float Permeability { get => permeability; }

    private float coldTime = 0.5f;
    public float ColdTime { get => coldTime; set => coldTime = value; }

    [SerializeField] float Speed;

    private bool isActivate = true;
    public bool IsActivate { get => isActivate; set => isActivate = value; }
}
