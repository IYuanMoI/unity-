using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //小地图摄像机跟随目标
    public GameObject obj;
    public Vector3 pos;
    public float h = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (obj != null) { return; }
        pos.x=obj.transform.position.x;
        pos.z=obj.transform.position.z;
        pos.y=h;
        this.transform.position=pos;
    }
}
