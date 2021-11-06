using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAndTankParPanel : MonoBehaviour
{
    //
    [SerializeField] float EnemyLvSpeedRatio;
    [SerializeField]float EnemyHpLvincreaseRatio;
    [SerializeField] int IntWeaponCost;
    [SerializeField] float UpgradeCtDRatio;
    [SerializeField] int UpgradeLvupCostRatio;
    private void Start()
    {
        FindObjectOfType<CreateEnemy>().SpeedRatio = EnemyLvSpeedRatio;
        FindObjectOfType<CreateEnemy>().HpRatio = EnemyHpLvincreaseRatio;
        FindObjectOfType<CreateWeaponSys>().WeaponCost =IntWeaponCost;
        FindObjectOfType<UpgradeSys>().CTimeDRatio = UpgradeCtDRatio;
        FindObjectOfType<UpgradeSys>().LvUpCostRatio = UpgradeLvupCostRatio;
    }
}
