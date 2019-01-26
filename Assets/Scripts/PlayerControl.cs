using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Camera cameraFollow;
    public float jumpSpeed = 10;
    public float runSpeed = 5;
    public GameObject head;

    private float originalHeadY = 0;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        originalHeadY = head.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        cameraFollow.transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            cameraFollow.transform.position.z
        );

        var hasTouch = Input.touchCount > 0 || Input.GetMouseButtonDown(0);

        var contacts = new ContactPoint2D[2];
        rb.GetContacts(contacts);
        var isOnGround = false;
        foreach (var c in contacts)
        {
            if (c.rigidbody != null && c.rigidbody.CompareTag("Ground"))
            {
                isOnGround = true;
                break;
            }
        }
        head.transform.localPosition = new Vector3(
            head.transform.localPosition.x,
            originalHeadY + Mathf.Clamp(
                this.transform.position.y * 0.1f, -0.1f, 0.1f
            ),
            head.transform.localPosition.z
        );
        if (hasTouch && isOnGround)
        {
            rb.velocity = new Vector2(runSpeed, jumpSpeed);
        }
        else
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
        }
    }
}
