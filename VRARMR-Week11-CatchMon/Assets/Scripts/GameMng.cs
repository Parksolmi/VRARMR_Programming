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
        numText.text = "��ȹ��" + numCatch + "/" + maxCatch;

        if(numCatch >= maxCatch)
        {
            PopupMsg("��� ���͸� ��ҽ��ϴ�.", 3);

            gameState = GameState.End;
            rePlayBtn.SetActive(true);
        }
        else
        {
            PopupMsg("��ҽ��ϴ�.", 2);
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
            numText.text = "��ȹ�� " + numCatch + "/" + maxCatch;
            gameState = GameState.Begin;
            ballObj.SetActive(true);
            PopupMsg("�巡���ؼ� ���� ��������!!", 2);
        }
    }

    public void PlayEffect(bool sucess, Vector3 pos)
    {
        ParticleSystem ps = sucess ? Instantiate(successEff) : Instantiate(failEff);
        ps.transform.position = pos;
    }
}
