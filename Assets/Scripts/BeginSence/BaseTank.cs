using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTank : MonoBehaviour
{
    //攻击
    public int atk;
    //防御
    public int def;
    //最大血量
    public int maxHP;
    //现在血量
    public int nowHP;
    //移动速度
    public float moveSpeed = 10;
    //转动速度
    public float roundSpeed = 50;
    //头部转动速度
    public float headSpeed = 500;
    //死亡特效
    public GameObject deadEff;
    //炮台
    public Transform tankHead;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //开火逻辑
    public abstract void Fire();
    //受伤逻辑
    public virtual void Wound(BaseTank t1)
    {
        int dmg = t1.atk - this.def;
        this.nowHP = nowHP - dmg;
        if (this.nowHP <= 0)
        {
            this.nowHP = 0;
            this.dead();
        }
    }
    public virtual void dead() 
    { 
        this.gameObject.SetActive(false);
        //实例化音效
        if (this.deadEff != null ) 
        {
             GameObject effobj =Instantiate(this.deadEff,this.transform.position,this.transform.rotation);
             AudioSource audioSource=effobj.GetComponent<AudioSource>();
             audioSource.volume = DataManager.Instance.MusicData.SoundValue;
             audioSource.mute=DataManager.Instance.MusicData.isOpenSound;
             audioSource.Play();
        }
        
    }
}
