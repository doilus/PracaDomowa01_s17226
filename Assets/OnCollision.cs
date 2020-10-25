using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class OnCollision : MonoBehaviour

    
{
    bool isCoroutineExecuting;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(ExecuteAfterTime(1.0f, () =>
            {
                Destroy(gameObject);
            }));
           
        }
    }


    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }
}
