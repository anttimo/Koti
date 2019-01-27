using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Gamelogic : MonoBehaviour
{

    private bool hasStarted = false;
    public GameObject player;
    public GameObject thinkBubble;

    public GameObject logo;

    void Start()
    {
        GameController.instance.GameOver = false;
    }

    // Start is called before the first frame update
    void Update()
    {
        var hasTouch = Input.touchCount > 0 || Input.GetMouseButtonDown(0);

        if (hasTouch && !hasStarted)
        {
            hasStarted = true;
            player.SetActive(true);
            Walk();
        }
    }

    void Walk()
    {
        //logo.SetActive(false);
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(1f);
        sequence.Append(player.transform.DOMoveX(-0.65f, 2));
        sequence.AppendCallback(() =>
        {
            thinkBubble.SetActive(true);
        });
        sequence.AppendInterval(2f);
        sequence.AppendCallback(() =>
        {
            thinkBubble.SetActive(false);
        });
        sequence.Append(player.transform.DOMoveX(10, 3));
        sequence.AppendCallback(() =>
        {
            SceneManager.LoadScene("ParallaxLevel", LoadSceneMode.Single);
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("ParallaxLevel"));
        });
    }
}
