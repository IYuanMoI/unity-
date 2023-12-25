using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel<GamePanel>
{
    public Button btnSetting;
    public Button btnQuit;
    public Text textTime;
    public Text textScore;
    public Image texHP;
    [HideInInspector]
    public int nowScore = 0;
    [HideInInspector]
    public float nowTime = 0;
    public SettingPanel SettingPanel;

    void Start()
    {
        //设置按钮
        btnSetting.onClick.AddListener(() => {
            SettingPanel.Instance.ShowMe();
            Time.timeScale = 0;
            SettingPanel.togMusic.isOn = DataManager.Instance.MusicData.isOpenMusic;
            SettingPanel.togSound.isOn = DataManager.Instance.MusicData.isOpenSound;
            SettingPanel.sdrMusic.value = DataManager.Instance.MusicData.MusicValue;
            SettingPanel.sdrSound.value = DataManager.Instance.MusicData.SoundValue;
            BKMusicData1.Instance.changeOpen(DataManager.Instance.MusicData.isOpenMusic);
            BKMusicData1.Instance.ChangedValue(DataManager.Instance.MusicData.MusicValue);
        }
        ); 
        //返回按钮
        btnQuit.onClick.AddListener(() => { 
            TipsPanel.Instance.ShowMe();
            Time.timeScale = 0;
        });          
    }
    void Update()
    {
        //累加游戏时间
        nowTime += Time.deltaTime;
        textTime.text = ConversionTime(nowTime);
    }
    //改变分数
    public void ChangeScore(int value)
    {
        nowScore += value;
        textScore.text = nowScore.ToString();
    }
    //改变血量
    public void ChangeHP(int MAXHP, int nowHP)
    {
        texHP.rectTransform.sizeDelta = new Vector2(280 * nowHP / MAXHP, 20);
    }
    //时间换算
    public string ConversionTime(float time)
    {
        int ctime = (int)time;
        string texttime = "";
        if (ctime / 3600 > 0) 
        {
            texttime += ctime / 3600 + "时";
        }
        if (time % 3600 / 60 > 0 || texttime != "") 
        {
            texttime += ctime % 3600 / 60 + "分";
        }
        texttime += ctime % 60 + "秒";
        return texttime;
    }
  
}
