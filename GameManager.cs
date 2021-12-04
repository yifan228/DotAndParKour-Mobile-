using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{   // 金錢 敵人開場的等級

    // singleton instance
    public static GameManager instance;
    //Lv
    public int Lv;
    //Money
    public int Money { get; set; } = 20;
    [SerializeField] private Text moneytext;

    //Link To Gamesystem
    GameSystem sys;
    public GameSystem Sys { get => sys; set => sys = value; }

    //link to the enemy weapon factory
    [SerializeField] CreateWeaponSys weponFactory;
    [SerializeField] CreateEnemy enemyFactory;

    //round1 2 3...
    private int round;

    //broadcast setlv setmoney
    public event EventHandler<int> BroadcastLv;

    public void OnBroadcastEnemyMaxLv()
    {
        BroadcastLv = null;
        BroadcastLv += enemyFactory.SetLvFromBroCast;
        BroadcastLv(this, Lv);
    }
    //public void OnBroadcastWeaponFacLv()
    //{
    //    BroadcastLv = null;

    //    BroadcastLv += weponFactory.SetLvFromBrocast;
    //    BroadcastLv(this, Lv);
    //}


    public event EventHandler<int> BroadCastMoney;
    public void OnBroadCastMoney()
    {
        BroadCastMoney += enemyFactory.SetMoneyFromBrocast;
        BroadCastMoney += weponFactory.SetMoneyFromBrocast;
        BroadCastMoney(this, Money);
        moneytext.text ="錢錢："+ $"{Money}";
        //Debug.Log(Money);
    }

    private void Awake()
    {
        DOTween.SetTweensCapacity(2000, 1000);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    [Header("GameoverCanvas")] [SerializeField] GameObject gameovercanvas;
    public void GameOver()
    {
        gameovercanvas.SetActive(true);
        
    }
    public void ReloadTheScene()
    {
        foreach(GameObject o in GameObject.FindGameObjectsWithTag("Tower"))
        {
            Destroy(o);
        }
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }


    //ＴＤ結束動畫
    [Header("TDEndingAnim")] [SerializeField] GameObject endingCanvas,mainCanvas,ContinueBtn;
    [SerializeField] Text endingtx;
    [SerializeField] Image endingImage;
    public void TDWin()
    {
        endingCanvas.SetActive(true);
        mainCanvas.SetActive(false);
        Time.timeScale = 1;
        Sequence s1 = DOTween.Sequence();
        s1.Append(endingtx.DOText("做得好 指揮官！", 2f,true,ScrambleMode.None).SetEase(Ease.Linear)).AppendInterval(1).
          Append(endingtx.DOText("你擊潰了邪惡的力量 \n 身為你的長官 我倍感榮幸", 5f).SetEase(Ease.Linear)).AppendInterval(1).
          Append(endingtx.DOText("",0.1f)).Append(endingtx.DOText("我 <color=red>一 定</color> 會跟偉大的總統\n稟告你的功勞\n 先去休息吧～",7f,true).SetEase(Ease.Linear)).
          AppendCallback(()=> ContinueBtn.SetActive(true)).AppendInterval(1).
          Append(endingtx.DOText(" ",0.1f));
        //Scene scene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene(scene.buildIndex + 1);
        endingtx.DOKill();
        
    }
    public void StoryturningPoint()
    {
        Sequence ss = DOTween.Sequence();
        ss.AppendCallback(() => ContinueBtn.SetActive(false)).Append(endingImage.DOColor(Color.black, 0.5f)).AppendInterval(1f).
            Append(endingtx.DOText("twenty years later ......", 3f).SetEase(Ease.Linear)).Append(endingtx.DOText("",0.1f)).
            AppendInterval(1f).Append(endingImage.DOColor(Color.white, 0.3f)).Append(endingImage.DOColor(Color.black, 0.3f)).
            Append(endingImage.DOColor(Color.white, 0.3f)).AppendCallback(() => endingtx.color = Color.black).
            Append(endingtx.DOText("這是怎麼了!!\n 我的手??\n我的頭上怎麼長出綠色的葉子？",10f).SetEase(Ease.Linear)).
            AppendCallback(()=>SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1));
    }

    private void Start()
    {
        OnBroadcastEnemyMaxLv();
        Invoke("OnBroadCastMoney",0.3f);
    }

    //store the tower info
    private void StoreTowerInfo()
    {
        GameObject[] tws = GameObject.FindGameObjectsWithTag("Tower");
        foreach (GameObject tw in tws)
        {
            Sys.Towers.Add(tw);
            //sys.Towerspos.Add(tw.transform.position);
        }
    }
}
