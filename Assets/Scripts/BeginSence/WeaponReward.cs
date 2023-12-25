using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaeponReward : MonoBehaviour
{
    //����Ԥ����
    public GameObject[] weapons;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            //����л�����
            int index = Random.Range(0, weapons.Length);
            PlayerObject player = other.GetComponent<PlayerObject>();
            player.ChangeWeapon(weapons[index]);
            //��ײ�����Լ�
            Destroy(this.gameObject);
        }
    }
}
