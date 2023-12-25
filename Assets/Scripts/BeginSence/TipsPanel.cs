using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TipsPanel : BasePanel<TipsPanel>
{
    public Button btnExit;
    public Button btnGoOn;
    public Button btnQuit;
    private void Start()
    {
        btnQuit.onClick.AddListener(() => this.HideMe());
        btnExit.onClick.AddListener(() => SceneManager.LoadScene("SampleScene"));
        btnGoOn.onClick.AddListener(() =>this.HideMe());
        HideMe();
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }

}
