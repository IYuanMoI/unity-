using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingPanel : BasePanel<SettingPanel>
{
    //¹Ø±Õ°´Å¥
    public Button btnExit;
    //ÒôÀÖtoggle
    public Toggle togMusic;
    //ÒôÐ§toggle
    public Toggle togSound;
    //ÒôÀÖ»¬¶¯Ìõ
    public Slider sdrMusic;
    //ÒôÐ§¹û»¬¶¯Ìõ
    public Slider sdrSound;

    void Start()
    {
        //xÂß¼­
        btnExit.onClick.AddListener(() => 
        {          
            BKMusicData1.Instance.changeOpen(DataManager.Instance.MusicData.isOpenMusic);
            BKMusicData1.Instance.ChangedValue(DataManager.Instance.MusicData.MusicValue);
            MgrJson.Mj.Save(DataManager.Instance.MusicData, "/Data", "/MusicData");
            HideMe();
            if (SceneManager.GetActiveScene().name == "SampleScene") 
            {
                BeginPanel.Instance.ShowMe();
            }
            if (SceneManager.GetActiveScene().name == "GameScene")
            {
                GamePanel.Instance.ShowMe();
            }


        });
        //ÒôÀÖ»¬¶¯ÌõÂß¼­
        sdrMusic.onValueChanged.AddListener((f) => DataManager.Instance.ChangeMusicValue(sdrMusic.value));
        //ÒôÐ§¹û»¬¶¯ÌõÂß¼­  
        sdrSound.onValueChanged.AddListener((f) => DataManager.Instance.ChangeSoundValue(sdrSound.value));
        //ÒôÀÖtoggleÂß¼­   
        togMusic.onValueChanged.AddListener((b) =>DataManager.Instance.OpenOrCloseMusic(togMusic.isOn));
        //ÒôÐ§toggleÂß¼­
        togSound.onValueChanged.AddListener((b) => DataManager.Instance.OpenOrCloseSound(togSound.isOn));
        HideMe();
    }

    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
