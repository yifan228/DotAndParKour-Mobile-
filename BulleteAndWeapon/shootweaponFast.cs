using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootweaponFast : AbWeapon
{
    [SerializeField] Transform point;//槍口
    [SerializeField] Transform point2;//槍口2
    int num = 1;
    public shootweaponFast():base() { coldTime = 0.5f;this.parentTrans = base.parentTrans;Dam=0.5f;this.tankLv = base.tankLv; }
    
    protected override void CreateBullete(Vector2 vector, float dam, float per)
    {
        if(num>0)
        {
            GameObject bullete = Instantiate(Bullete, point.position, Quaternion.identity);
            CreateBulletFactory<BulleteOne>.ReturnBullete(bullete, vector, damAlgo(), permeabilityAlgo());
            num *= -1;
        }else
        {
            GameObject bullete = Instantiate(Bullete, point2.position, Quaternion.identity);
            CreateBulletFactory<BulleteOne>.ReturnBullete(bullete, vector, damAlgo(), permeabilityAlgo());
            num *= -1;
        }
    }

    protected override Vector2 TargetPos(Transform target)
    {
        float rngNum = Random.Range(0, 1f);
        return target.position + new Vector3(0, rngNum, 0)-transform.position;
    }

    private float damAlgo()
    {
        return Dam * tankLv;
    }

    private float permeabilityAlgo()
    {
        return permeability * tankLv;
    }
    
}
