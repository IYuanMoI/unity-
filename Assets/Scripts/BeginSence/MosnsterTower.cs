using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosnsterTower : BaseTank
{
    //子弹预设体
    public GameObject bulletObj;
    //间隔时间
    public float fireTime = 5f;
    //计数时间
    public float nowTime=0f;
    //发射位置
    public Transform[] shootPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nowTime = nowTime+Time.deltaTime;
        if (nowTime >=fireTime)
        {
            Fire();
            nowTime = 0f;
        }
    }

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++) 
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].transform.position, shootPos[i].transform.rotation);
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFatherTank(this);            
        }
    }
    public override void Wound(BaseTank t1)
    {
       
    }


}
