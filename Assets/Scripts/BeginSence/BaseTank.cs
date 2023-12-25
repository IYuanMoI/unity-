using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTank : MonoBehaviour
{
    //����
    public int atk;
    //����
    public int def;
    //���Ѫ��
    public int maxHP;
    //����Ѫ��
    public int nowHP;
    //�ƶ��ٶ�
    public float moveSpeed = 10;
    //ת���ٶ�
    public float roundSpeed = 50;
    //ͷ��ת���ٶ�
    public float headSpeed = 500;
    //������Ч
    public GameObject deadEff;
    //��̨
    public Transform tankHead;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //�����߼�
    public abstract void Fire();
    //�����߼�
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
        //ʵ������Ч
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
