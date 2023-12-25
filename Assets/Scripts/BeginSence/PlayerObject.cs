using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : BaseTank
{
    //��ǰ����
    public WeaponObj weapon;
    //����λ��
    public Transform weaponPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ws����ǰ��
        this.transform.Translate(Input.GetAxis("Vertical")*Vector3.forward * moveSpeed * Time.deltaTime);
        //ad������ת
        this.transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * roundSpeed * Time.deltaTime);
        //��������̨��ת
        tankHead.transform.Rotate(Input.GetAxis("Mouse X") * Vector3.up * headSpeed * Time.deltaTime);
        //����
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
    //��������
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
