using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingPanel : BasePanel<SettingPanel>
{
    //�رհ�ť
    public Button btnExit;
    //����toggle
    public Toggle togMusic;
    //��Чtoggle
    public Toggle togSound;
    //���ֻ�����
    public Slider sdrMusic;
    //��Ч��������
    public Slider sdrSound;

    void Start()
    {
        //x�߼�
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
        //���ֻ������߼�
        sdrMusic.onValueChanged.AddListener((f) => DataManager.Instance.ChangeMusicValue(sdrMusic.value));
        //��Ч���������߼�  
        sdrSound.onValueChanged.AddListener((f) => DataManager.Instance.ChangeSoundValue(sdrSound.value));
        //����toggle�߼�   
        togMusic.onValueChanged.AddListener((b) =>DataManager.Instance.OpenOrCloseMusic(togMusic.isOn));
        //��Чtoggle�߼�
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
