using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    public float hitRate;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag!="Ball")
        {
            return;
        }

        if(Random.Range(0.0f, 1.0f) <hitRate)
        {
            print("명중입니다.");
        }
        else
        {
            print("막혔습니다.");
        }
    }
}
