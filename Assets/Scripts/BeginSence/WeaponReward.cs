using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaeponReward : MonoBehaviour
{
    //武器预设体
    public GameObject[] weapons;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            //玩家切换武器
            int index = Random.Range(0, weapons.Length);
            PlayerObject player = other.GetComponent<PlayerObject>();
            player.ChangeWeapon(weapons[index]);
            //碰撞销毁自己
            Destroy(this.gameObject);
        }
    }
}
