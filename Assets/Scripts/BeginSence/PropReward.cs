using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
//加属性类型
public enum E_PeopType 
{
    atk,
    maxhp,
    hp
}
public class PropReward : MonoBehaviour
{
    public GameObject eff;
    public E_PeopType type = E_PeopType.atk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerObject player =other.GetComponent<PlayerObject>();
            switch (type) 
            {
                case E_PeopType.atk:
                    player.atk += 20;
                    break;           
                case E_PeopType.maxhp:
                    player.maxHP += 20;
                    break;
                case E_PeopType.hp:
                    player.nowHP += 20;
                    if (player.nowHP > player.maxHP) 
                    {
                    player.nowHP = player.maxHP;
                       
                    }
                    GamePanel.Instance.ChangeHP(player.maxHP, player.nowHP);
                    break;
                   
            } 
            //创建特效
            GameObject eff1=Instantiate(eff,this.transform.position,this.transform.rotation);
            //控制音效
            AudioSource aud=eff1.GetComponent<AudioSource>();
            aud.volume = DataManager.Instance.MusicData.SoundValue;
            aud.mute = !DataManager.Instance.MusicData.isOpenSound;
            Destroy(this.gameObject);
        }
    }
}
