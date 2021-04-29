using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public GameObject erase;
    private bool hit = false;
    float timer = 0f;
    public float bulletEndSize = 0f;
    public float bulletSize = 0f;
    public Bullet bullet;
    public GameObject rubble;
    private void Update()
    {
        if (hit)
            timer += Time.deltaTime;
        if(timer >= 0.1f)
        {            
            Instantiate(rubble,transform.position,Quaternion.identity);
            Destroy(this.gameObject);        

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
            bulletSize = bulletEndSize;
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            //GetComponent<Rigidbody>().useGravity = false;
            //hit = true;
            hit = true;


    }
}
