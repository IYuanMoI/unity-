using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponObj : MonoBehaviour
{
    //子弹
    public GameObject bullet;
    //发射位置
    public Transform[] shootPos;
    //武器拥有者
    public BaseTank fatherTank;
    public void Fire() 
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetFatherTank(fatherTank);
        }
    }
    //设置拥有者
    public void SetFatherTank(BaseTank tank) 
    {
    this.fatherTank = tank;
        
    }
}
