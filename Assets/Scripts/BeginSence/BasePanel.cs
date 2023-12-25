using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//面板基类
public class BasePanel<T> : MonoBehaviour where T:class
{
    private static T instance;
    public static T Instance => instance;

    private void Awake()
    {
        instance = this as T;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //显示自己
    public virtual void ShowMe() 
    {
    this.gameObject.SetActive(true);
    }
    //隐藏自己
    public  virtual void HideMe() 
    { 
    this.gameObject.SetActive(false);
    }
}
