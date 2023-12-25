using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginPanel : BasePanel<BeginPanel>
{   //��ʼ��Ϸ��ť
    public Button btnBegin;
    //�˳���Ϸ��ť
    public Button btnQuit;
    //������Ϸ��ť
    public Button btnSetting;
    //���а�ť
    public Button btnRank;


    void Start()
    {
        //��ʼ��Ϸ��ť�߼�
        btnBegin.onClick.AddListener(() => {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("GameScene");
        });
        //�˳���Ϸ��ť�߼�
        btnQuit.onClick.AddListener(() => 
        Application.Quit());
        //������Ϸ��ť�߼�
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
