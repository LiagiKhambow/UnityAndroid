using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTrigger : MonoBehaviour
{

    public string loadName;
    public string unloadName;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player"))
        {
            if(loadName != null)
                GameSceneManager.Instance.Load(loadName);
            if (unloadName != null)
                StartCoroutine("UnloadScene");
        }
    }

    IEnumerator UnloadScene()
    {
        yield return new WaitForSeconds(.10f);
        GameSceneManager.Instance.Unload(unloadName);
    }
    
}
