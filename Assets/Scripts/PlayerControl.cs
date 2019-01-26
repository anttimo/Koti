using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Camera cameraFollow;
    public float jumpSpeed = 10;
    public float runSpeed = 5;
    public GameObject head;

    private float originalHeadY;
    private float originalY;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sr;

    private float minY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        originalHeadY = head.transform.localPosition.y;
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (minY == 0)
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
        if (hasTouch && transform.position.y >= minY)
        {
            rb.velocity = new Vector2(runSpeed, jumpSpeed);
            return;
        }
        if (transform.position.y >= minY)
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            return;
        }
        GameController.instance.GameOver = true;
    }
}
