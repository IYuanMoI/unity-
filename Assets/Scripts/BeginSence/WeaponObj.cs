using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponObj : MonoBehaviour
{
    //�ӵ�
    public GameObject bullet;
    //����λ��
    public Transform[] shootPos;
    //����ӵ����
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
    //����ӵ����
    public void SetFatherTank(BaseTank tank) 
    {
    this.fatherTank = tank;
        
    }
}
