using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 direction = transform.position - other.transform.position;

        if(other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);

            if(transform.GetChild(0).GetComponent<Rigidbody2D>().gravityScale<1)
            {
                NinjayiYokEtFNC();
            }

            GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x > 0 ? 1 : -1, direction.y > 0 ? .3f : -.3f), ForceMode2D.Impulse);
        }
    }

    private void NinjayiYokEtFNC()
    {
        gameObject.tag = "Untagged";

        foreach (Transform item in transform)
        {
            item.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
    }
}
