using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerControl : MonoBehaviour
{

    public Camera cameraFollow;
    public float jumpSpeed = 10;
    public float runSpeed = 5;
    public GameObject head;

    public GameObject thinkBubble;

    public GameObject dimmingPanel;
    public int mushroomTarget = 6;
    public bool goalReached = false;
    private float originalHeadY;
    private float originalY;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sr;

    [SerializeField]
    private float minY = float.NaN;

    private bool jumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        originalHeadY = head.transform.localPosition.y;
        originalY = transform.position.y;
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (goalReached || GameController.instance.GameOver)
        {
            return;
        }

        if (GameController.instance.FoodCount == mushroomTarget)
        {
            goalReached = true;
            GoHome();
        }
        cameraFollow.transform.position = new Vector3(
            transform.position.x + 4,
            cameraFollow.transform.position.y,
            cameraFollow.transform.position.z
        );

        var hasTouch = Input.touchCount > 0 || Input.GetMouseButtonDown(0);
        head.transform.localPosition = new Vector3(
            head.transform.localPosition.x,
            originalHeadY + Mathf.Clamp(
                (transform.position.y - originalY) * 0.1f, -0.1f, 0.1f
            ),
            head.transform.localPosition.z
        );

        if (float.IsNaN(minY))
        {
            var contacts = new ContactPoint2D[2];
            rb.GetContacts(contacts);
            foreach (var c in contacts)
            {
                if (c.rigidbody != null && c.rigidbody.CompareTag("Ground"))
                {
                    minY = transform.position.y;
                    break;
                }
            }

            return;
        }

        var diff = transform.position.y - minY;
        if (Mathf.Abs(diff) < 0.05 && jumping)
        {
            jumping = false;
            Debug.Log("LANDED!");
        }

        if (hasTouch && diff < 0.1 && diff > -0.1)
        {
            rb.velocity = new Vector2(runSpeed, jumpSpeed);
            jumping = true;
            return;
        }
        if (diff > -0.1)
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            return;
        }
        if (GameController.instance.ReloadInProgress)
        {
            return;
        }
        GameController.instance.ReloadLevel();
    }

    void GoHome()
    {
        dimmingPanel.SetActive(false);
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
        {
            thinkBubble.SetActive(true);
        });
        sequence.AppendInterval(2f);

        sequence.AppendCallback(() =>
        {
            SceneManager.LoadScene("HomeScene", LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("HomeScene"));
            goalReached = false;
        });
    }
}
