using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    //奖励预设体
    public GameObject[] rewardObject;
    //被打掉的特效预设体
    public GameObject deadEff;
    private void OnTriggerEnter(Collider other)
    {
        //打掉自己随机掉落奖励
        int i= Random.Range(0,100);
        if (i < 50) 
        {
            int j = Random.Range(0, rewardObject.Length);
            Instantiate(rewardObject[j], this.transform.position, this.transform.rotation);               
        }
        //实例化特效
        GameObject effboj = Instantiate(deadEff, this.gameObject.transform.position, this.gameObject.transform.rotation);
        //控制音效
        AudioSource aud = deadEff.GetComponent<AudioSource>();
        aud.volume = DataManager.Instance.MusicData.SoundValue;
        aud.mute = !DataManager.Instance.MusicData.isOpenSound;
        Destroy(this.gameObject);
    }
}
