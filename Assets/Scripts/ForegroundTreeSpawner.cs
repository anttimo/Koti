using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundTreeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform child in transform)
        {
            var vp = Camera.main.WorldToViewportPoint(
                child.position + new Vector3(child.GetComponent<SpriteRenderer>().bounds.size.x / 2, 0, 0)
            );
            if (vp.x < 0)
            {
                Destroy(child.gameObject);
            }
        }
        var lastChild = transform.GetChild(transform.childCount - 1);
        var halfWidth = lastChild.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        var treeRight = lastChild.position.x + halfWidth;
        var screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        if (treeRight < screenRight)
        {
            var go = Instantiate(
                lastChild,
                new Vector3(treeRight + halfWidth + Random.Range(1f, 10f), lastChild.position.y, lastChild.position.z),
                Quaternion.identity,
                transform
            );
            var scaleFactor = Random.Range(0.75f, 1.25f);
            go.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
        }
    }
}
