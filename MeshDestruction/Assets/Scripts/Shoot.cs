using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigRookGames.Weapons;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public Camera mCamera;
    public GameObject launcher;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            launcher.GetComponent<GunfireController>().FireWeapon();
            //var screenPoint = Input.mousePosition;
            //screenPoint.z = mCamera.transform.forward.z + 2;
            //screenPoint = Camera.main.ScreenToWorldPoint(screenPoint); 
            //GameObject bullet = Instantiate(Bullet, screenPoint, Quaternion.identity);
            //bullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 40;
        }
    }
}
