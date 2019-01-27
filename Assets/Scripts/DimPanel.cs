using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DimPanel : MonoBehaviour
{

    public Image image;

    public float lerpDuration = 20f;
    private float lerpStart = 0;
    private float progress;
    private bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        lerpStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float progress = Time.time - lerpStart;
        float alpha = Mathf.Lerp(0.0f, 1.0f, progress / lerpDuration);
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

        if (alpha > 0.99f && !gameEnded)
        {
            gameEnded = true;
            GameController.instance.GameOver = true;
        }
    }
}
