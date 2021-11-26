using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMng : MonoBehaviour
{
    static public GameMng instance;
    public GameObject[] stages;
    int curStage = 0;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GoNextStage()
    {
        StartCoroutine(ChangeStage());
    }

    IEnumerator ChangeStage()
    {
        stages[curStage].SetActive(false);

        ++curStage;
        if (curStage < stages.Length)
        {
            yield return new WaitForSeconds(0.5f);
            stages[curStage].SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("EscapeMaze");
        }
    }
}
