using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotateSpeed = 100f;

    Transform leftHand;

    Transform pos_0, pos_1;

    LineRenderer lineRenderer;

    public GameObject bulletPrefab;

    public float bulletSpeed = 20f;

    private void Awake()
    {
        leftHand = GameObject.Find("leftHand").transform;
        pos_0 = GameObject.Find("pos_0").transform;
        pos_1 = GameObject.Find("pos_1").transform;

        lineRenderer = GameObject.Find("Gun").GetComponent<LineRenderer>();
        lineRenderer.enabled = false;

    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            KoluHareketEttirFNC();
        }

        if(Input.GetMouseButtonUp(0))
        {
            MermiFirlatFNC();
        }
    }

    void KoluHareketEttirFNC()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - leftHand.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        leftHand.rotation = Quaternion.Slerp(leftHand.rotation, rotation, rotateSpeed * Time.deltaTime);

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, pos_0.position);
        lineRenderer.SetPosition(1, pos_1.position);

    }

    void MermiFirlatFNC()
    {
        lineRenderer.enabled = false;

        GameObject bullet = Instantiate(bulletPrefab, pos_0.position, Quaternion.identity);

        if(transform.localScale.x>0)
        {
            bullet.GetComponent<Rigidbody2D>().AddForce(pos_0.right * bulletSpeed, ForceMode2D.Impulse);
        } else
        {
            bullet.GetComponent<Rigidbody2D>().AddForce(-pos_0.right * bulletSpeed, ForceMode2D.Impulse);
        }

        


        Destroy(bullet, 2f);
    }
}
