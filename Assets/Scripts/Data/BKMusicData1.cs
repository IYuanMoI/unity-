using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusicData1 : MonoBehaviour
{
    private static BKMusicData1 bKMusicData;
    public static BKMusicData1 Instance => bKMusicData;
    private AudioSource audioSource;
    private void Awake()
    {
        bKMusicData = this;
        audioSource = this.GetComponent<AudioSource>();
      
    }
    //改变背景音乐大小
    public void ChangedValue(float f)
    {
        audioSource.volume = f;
    }
    //开关背景音乐
    public void changeOpen(bool isOpen)
    {
        audioSource.mute = !isOpen;
    }
}
