using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObj : MonoBehaviour
{
    //����Ԥ����
    public GameObject[] rewardObject;
    //���������ЧԤ����
    public GameObject deadEff;
    private void OnTriggerEnter(Collider other)
    {
        //����Լ�������佱��
        int i= Random.Range(0,100);
        if (i < 50) 
        {
            int j = Random.Range(0, rewardObject.Length);
            Instantiate(rewardObject[j], this.transform.position, this.transform.rotation);               
        }
        //ʵ������Ч
        GameObject effboj = Instantiate(deadEff, this.gameObject.transform.position, this.gameObject.transform.rotation);
        //������Ч
        AudioSource aud = deadEff.GetComponent<AudioSource>();
        aud.volume = DataManager.Instance.MusicData.SoundValue;
        aud.mute = !DataManager.Instance.MusicData.isOpenSound;
        Destroy(this.gameObject);
    }
}
