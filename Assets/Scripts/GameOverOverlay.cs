using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOverlay : MonoBehaviour
{
    public GameObject overlay;
    void Update()
    {
        if (GameController.instance.GameOver)
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        overlay.SetActive(GameController.instance.GameOver);
    }
}
