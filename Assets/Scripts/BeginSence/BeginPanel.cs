using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginPanel : BasePanel<BeginPanel>
{   //开始游戏按钮
    public Button btnBegin;
    //退出游戏按钮
    public Button btnQuit;
    //设置游戏按钮
    public Button btnSetting;
    //排行榜按钮
    public Button btnRank;


    void Start()
    {
        //开始游戏按钮逻辑
        btnBegin.onClick.AddListener(() => {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("GameScene");
        });
        //退出游戏按钮逻辑
        btnQuit.onClick.AddListener(() => 
        Application.Quit());
        //设置游戏按钮逻辑
        btnSetting.onClick.AddListener(() =>
        {
            SettingPanel.Instance.ShowMe();
            HideMe();
        }) ;
      
    }

    void Update()
    {
         
    }
}
