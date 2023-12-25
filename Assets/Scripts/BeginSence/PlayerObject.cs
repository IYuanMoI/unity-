using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : BaseTank
{
    //当前武器
    public WeaponObj weapon;
    //武器位置
    public Transform weaponPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ws控制前进
        this.transform.Translate(Input.GetAxis("Vertical")*Vector3.forward * moveSpeed * Time.deltaTime);
        //ad控制旋转
        this.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * roundSpeed * Time.deltaTime);
        //鼠标控制炮台旋转
        tankHead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headSpeed * Time.deltaTime);
        //开火
        if (Input.GetMouseButtonDown(0)) 
        {
            Fire();
        }
    }
    public override void Wound(BaseTank t1)
    {
        base.Wound(t1);
        GamePanel.Instance.ChangeHP(this.maxHP, this.nowHP);
    }
    public override void dead()
    {
        base.dead();
    } 
    public override void Fire()
    {
        if (weapon != null) 
        {
        weapon.Fire();
        }
    }
    //更换武器
    public void ChangeWeapon(GameObject obj)
    {
        if(weapon != null)
        {
            Destroy(weapon.gameObject);
            weapon = null;    
        }
        GameObject weaponobj =Instantiate(obj,weaponPos,false);
        weapon = weaponobj.GetComponent<WeaponObj>();
        weapon.SetFatherTank(this);
    }
}
