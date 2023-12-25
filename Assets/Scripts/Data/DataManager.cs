using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    private static DataManager dataManager = new();
    public static DataManager Instance => dataManager;
    public MusicData MusicData = new();
    

    public void Init()
    {
        Debug.Log("cao");
        MusicData = MgrJson.Mj.Load<MusicData>("/Data", "/MusicData");
        
    }

    //�洢�ı������ݣ��Ƿ����ر����֣�
    public void OpenOrCloseMusic(bool isopen) 
    {
        MusicData.isOpenMusic = isopen;
        BKMusicData1.Instance.changeOpen(isopen);
        MgrJson.Mj.Save(DataManager.Instance.MusicData, "/Data", "/MusicData");
    }
    //�洢�ı������ݣ��Ƿ����ر���Ч��
    public void OpenOrCloseSound(bool issound)
    {
        MusicData.isOpenSound = issound;
        MgrJson.Mj.Save(DataManager.Instance.MusicData, "/Data", "/MusicData");
    }
    //�洢�ı������ݣ�����������С��
    public void ChangeMusicValue(float value)
    {
        MusicData.MusicValue = value;
        BKMusicData1.Instance.ChangedValue(value);
        MgrJson.Mj.Save(DataManager.Instance.MusicData, "/Data", "/MusicData");
    }
    //�洢�ı������ݣ���Ч������С��
    public void ChangeSoundValue(float value)
    {
        MusicData.SoundValue = value;
        MgrJson.Mj.Save(DataManager.Instance.MusicData, "/Data", "/MusicData");
    }
}
