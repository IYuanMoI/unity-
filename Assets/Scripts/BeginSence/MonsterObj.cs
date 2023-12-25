using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : BaseTank
{
    //��������֮�������ƶ�
    //��ǰĿ���
    private Transform nowPos;
    //Ŀ�����
    public Transform[] randomPos;
    //һֱ�����Լ���Ŀ��
    public Transform lookAtObj;

    //��Ŀ�굽��һ����Χ�� ���һ��ʱ�䣬����Ŀ��
    public float fireDis = 5f;
    public float fireTime = 1f;
    public float nowTime = 0f;
    //�����
    public GameObject[] shootPos;
    public GameObject bulletObj;
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame 
    void Update()
    {
        this.transform.LookAt(nowPos);
        this.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        if (Vector3.Distance(this.transform.position, nowPos.transform.position) < 0.5f)
        {
            RandomPos();
        }
        if (lookAtObj != null)
        {
            tankHead.transform.LookAt(lookAtObj.position);
        }
        if (Vector3.Distance(this.transform.position, nowPos.transform.position) < fireDis)
        {
            nowTime = nowTime + Time.deltaTime;
            if (nowTime >= fireTime)
            {
                Fire();
                nowTime = 0f;
            }
        }
    }
    private void RandomPos()
    {
        if (randomPos.Length == 0)
        {
            return;
        }
        nowPos = randomPos[Random.Range(0, randomPos.Length)];
    }

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bulletObj, shootPos[i].transform.position, shootPos[i].transform.rotation);
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFatherTank(this);
        }
    }
    public override void dead()
    {
        base.dead();
        //�ӷ�
        GamePanel.Instance.ChangeScore(10);
    }
}

