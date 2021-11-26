using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCtrl : MonoBehaviour
{
    public float hitRate;

    public float damageRate;
    public float catchRate;
    public Image imgHP;

    Animation ani;
    private void Start()
    {
        ani = GetComponent<Animation>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag!="Ball")
        {
            return;
        }
        Vector3 colPos = collision.contacts[0].point;

        if(Random.Range(0.0f, 1.0f) <hitRate)
        {
            GameMng.instance.PlayEffect(true, colPos);

            imgHP.fillAmount -= damageRate;
            if (imgHP.fillAmount > 0.001f)
            {
                GameMng.instance.PopupMsg("명중입니다!!", 1);
            }
            else
            { 
                if (Random.Range(0.0f, 1.0f) < catchRate)
                {
                    GameMng.instance.AddCatch();
                }
                else
                {
                    GameMng.instance.PopupMsg("놓쳤습니다..", 2);
                }
                gameObject.SetActive(false);

                Invoke("ChangePos", Random.Range(2, 5));
                imgHP.fillAmount = 1;

            }
        }
        else
        {
            GameMng.instance.PopupMsg("막혔습니다.", 1);

            StartCoroutine(PlayAni());
            GameMng.instance.PlayEffect(false, colPos);
        }
    }

    void ChangePos()
    {
        gameObject.SetActive(true);

        Vector3 pos;
        pos.x = Random.Range(-0.5f, 0.5f);
        pos.y = 0;
        pos.z = Random.Range(-0.5f, 0.5f);

        transform.localPosition = pos;
    }

    IEnumerator PlayAni()
    {
        ani.Play("Attack");
        float aniLen = ani.GetClip("Attack").length;
        yield return new WaitForSeconds(aniLen);
        ani.Play("Idle");
    }
}
