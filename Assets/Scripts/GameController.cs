using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int FoodCount { get; set; } = 0;
    public bool GameOver { get; set; } = false;
    public bool ReloadInProgress { get; set; } = false;
    public static GameController instance = null;

    public void ReloadLevel()
    {
        StartCoroutine(Reset());
    }

    IEnumerator Reset()
    {
        ReloadInProgress = true;
        yield return new WaitForSeconds(1);
        var s = SceneManager.GetActiveScene();
        SceneManager.LoadScene(s.name);
        FoodCount = 0;
        ReloadInProgress = false;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    void Update()
    {

    }
}
