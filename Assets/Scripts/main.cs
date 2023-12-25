using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    public SettingPanel SettingPanel;
    private void Awake()
    {
        DataManager.Instance.Init();
        InitializeSettingPanel();
    }
    public void InitializeSettingPanel() 
    {
        SettingPanel.togMusic.isOn = DataManager.Instance.MusicData.isOpenMusic;
        SettingPanel.togSound.isOn = DataManager.Instance.MusicData.isOpenSound;
        SettingPanel.sdrMusic.value = DataManager.Instance.MusicData.MusicValue;
        SettingPanel.sdrSound.value = DataManager.Instance.MusicData.SoundValue;
        BKMusicData1.Instance.changeOpen(DataManager.Instance.MusicData.isOpenMusic);
        BKMusicData1.Instance.ChangedValue(DataManager.Instance.MusicData.MusicValue);
    }
}
