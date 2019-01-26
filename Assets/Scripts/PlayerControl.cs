using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Camera cameraFollow;
    public float jumpSpeed = 10;
    public float runSpeed = 5;

    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private Sprite sprite;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        collider = this.GetComponent<BoxCollider2D>();
        sprite = this.GetComponent<Sprite>();
    }

    // Update is called once per frame
    void Update()
    {
        this.cameraFollow.transform.position = new Vector3(
            this.transform.position.x,
            this.transform.position.y,
            this.cameraFollow.transform.position.z
        );

        var hasTouch = Input.touchCount > 0 || Input.GetMouseButtonDown(0);

        var contacts = new ContactPoint2D[2];
        rb.GetContacts(contacts);
        var isOnGround = false;
        foreach (var c in contacts)
        {
            if (c.rigidbody != null && c.rigidbody.CompareTag("Ground")) {
                isOnGround = true;
                break;
            }
        }
        if (hasTouch && isOnGround) {
            rb.velocity = new Vector2(runSpeed, jumpSpeed);
        } else {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
        }
    }
}
