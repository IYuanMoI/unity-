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
            //�ж��Ƿ�����
            BaseTank bk= other.GetComponent<BaseTank>();
            if (bk!=null) 
            {
                bk.Wound(fatherObj);
            }
            if (effObj != null) 
            {
                GameObject eff = Instantiate(effObj, this.transform.position, this.transform.rotation);
                //�õ���Ч
                AudioSource audioSource = eff.GetComponent<AudioSource>();
                //������Ч����
                audioSource.volume = DataManager.Instance.MusicData.SoundValue;
                //������Ч����
                audioSource.mute = !DataManager.Instance.MusicData.isOpenSound;
            }
            Destroy(this.gameObject);}
        else Destroy(this.gameObject,3);
        
    }
    //����ӵ����
    public void SetFatherTank(BaseTank tank)
    {
        this.fatherObj = tank;
    }
}
