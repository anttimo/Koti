using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioModifier : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Rigidbody2D rb;
    private float originalPlayerX;
    private AudioSource music;

    private float originalPositionY;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        originalPlayerX = player.transform.position.x;
        originalPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        music.pitch = Mathf.Clamp(music.pitch - 0.00002f * (player.transform.position.x - originalPlayerX), 0, 1);
    }
}