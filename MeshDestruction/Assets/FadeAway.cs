using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    float timer;
    float safetyTimer;
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (timer >= 5f || safetyTimer >= 10f)
            Destroy(this.gameObject);
        safetyTimer += Time.deltaTime;
        if (rigidbody.velocity != Vector3.zero)
            return;
        timer += Time.deltaTime;

    }
}
