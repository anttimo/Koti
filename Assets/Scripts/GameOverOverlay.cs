using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOverlay : MonoBehaviour
{
    public GameObject overlay;
    private bool showing = false;

    void Update()
    {
        if (GameController.instance.GameOver)
        {
            overlay.SetActive(GameController.instance.GameOver);

            var hasTouch = Input.touchCount > 0 || Input.GetMouseButtonDown(0);

            if (hasTouch)
            {
                SceneManager.LoadScene("HomeScene", LoadSceneMode.Single);
                //SceneManager.SetActiveScene(SceneManager.GetSceneByName("HomeScene"));
            }
        }
    }

}
