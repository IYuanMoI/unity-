using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    public float moveSpeed = 50;
    public BaseTank fatherObj;
    public GameObject effObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cube")||
            other.CompareTag("Player")&&fatherObj.CompareTag("Monster")||
            other.CompareTag("Monster") && fatherObj.CompareTag("Player")) 
        {
            //判断是否受伤
            BaseTank bk= other.GetComponent<BaseTank>();
            if (bk!=null) 
            {
                bk.Wound(fatherObj);
            }
            if (effObj != null) 
            {
                GameObject eff = Instantiate(effObj, this.transform.position, this.transform.rotation);
                //得到音效
                AudioSource audioSource = eff.GetComponent<AudioSource>();
                //设置音效音量
                audioSource.volume = DataManager.Instance.MusicData.SoundValue;
                //设置音效开关
                audioSource.mute = !DataManager.Instance.MusicData.isOpenSound;
            }
            Destroy(this.gameObject);}
        else Destroy(this.gameObject,3);
        
    }
    //设置拥有者
    public void SetFatherTank(BaseTank tank)
    {
        this.fatherObj = tank;
    }
}
