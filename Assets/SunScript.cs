using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{

    public GameObject player;
    private Rigidbody2D rb;
    private float originalPlayerX;

    private float originalPositionY;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPlayerX = player.transform.position.x;
        originalPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, originalPositionY - (float)(1.2 * (player.transform.position.x - originalPlayerX)), transform.position.z);
    }
}
