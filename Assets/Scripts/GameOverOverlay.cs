using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOverlay : MonoBehaviour
{
    public GameObject overlay;
    private bool showing = false;

    void Update()
    {
        if (GameController.instance.GameOver)
        {
            overlay.SetActive(GameController.instance.GameOver);
        }
    }

}
