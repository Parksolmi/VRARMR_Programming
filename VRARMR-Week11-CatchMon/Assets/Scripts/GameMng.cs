using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    Ready,
    Begin,
    End
}

public class GameMng : MonoBehaviour
{
    static public GameMng instance;
    public Text numText;
    public int maxCatch;
    int numCatch = 0;
    public Text stateText;

    public GameObject ballObj;
    public GameState gameState = GameState.Ready;

    public ParticleSystem failEff;
    public ParticleSystem successEff;

    public GameObject rePlayBtn;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        ballObj.SetActive(false);
    }

   public void AddCatch()
    {
        ++numCatch;
        numText.text = "포획수" + numCatch + "/" + maxCatch;

        if(numCatch >= maxCatch)
        {
            PopupMsg("모든 몬스터를 잡았습니다.", 3);

            gameState = GameState.End;
            rePlayBtn.SetActive(true);
        }
        else
        {
            PopupMsg("잡았습니다.", 2);
        }
    }

    public void OnClickReplay()
    {
        SceneManager.LoadScene("CatchMon");
    }

    public void PopupMsg(string msg, int time)
    {
        StartCoroutine(ShowMsg(msg, time));
    }

    IEnumerator ShowMsg(string msg, int time)
    {
        stateText.text = msg;
        yield return new WaitForSeconds(time);
        stateText.text = "";
    }

    public void OnDetected()
    {
        if(gameState == GameState.Ready)
        {
            numText.text = "포획수 " + numCatch + "/" + maxCatch;
            gameState = GameState.Begin;
            ballObj.SetActive(true);
            PopupMsg("드래그해서 볼을 던지세요!!", 2);
        }
    }

    public void PlayEffect(bool sucess, Vector3 pos)
    {
        ParticleSystem ps = sucess ? Instantiate(successEff) : Instantiate(failEff);
        ps.transform.position = pos;
    }
}
