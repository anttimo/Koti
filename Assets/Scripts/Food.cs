using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Food : MonoBehaviour
{

    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.instance.FoodCount++;
            sr.DOFade(0, 0.5f);
            transform.DOMoveY(transform.position.y + 5, 1).OnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}
