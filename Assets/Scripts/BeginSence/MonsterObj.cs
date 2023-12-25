using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : BaseTank
{
    //在两个点之间来回移动
    //当前目标点
    private Transform nowPos;
    //目标点组
    public Transform[] randomPos;
    //一直盯着自己的目标
    public Transform lookAtObj;

    //当目标到达一定范围内 间隔一段时间，攻击目标
    public float fireDis = 5f;
    public float fireTime = 1f;
    public float nowTime = 0f;
    //开火点
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
        //加分
        GamePanel.Instance.ChangeScore(10);
    }
}

