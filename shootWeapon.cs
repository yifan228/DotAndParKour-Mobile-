using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shootWeapon : AbWeapon//實作的武器
{
    [SerializeField] Transform point;//槍口
    public shootWeapon():base()
    {
        Dam = 1;
        this.tankLv = base.tankLv;
        this.parentTrans = base.parentTrans;
    }


    //test Mylv field global vs area scope
    //public override void SetMylv(int lv)
    //{
        //SetLv(lv,out Mylv);
        //Debug.Log(Mylv);
    //}
    //void SetLv(int lv,out int lf)
    //{
    //    lf = lv;
    //}
   
    protected override void CreateBullete(Vector2 vector,float dam,float per)
    {
        GameObject bullete= Instantiate(Bullete,point.position,Quaternion.identity);
        
        CreateBulletFactory<BulleteOne>.ReturnBullete(bullete,vector,damAlgo(),permeabilityAlgo());
    }

    protected override Vector2 TargetPos(Transform target)
    {
//        Debug.Log(target.position);
        float RngNum = Random.Range(0f, 0.5f);
        return (target.position + new Vector3(0,0.3f + RngNum, 0)) - transform.position;
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
