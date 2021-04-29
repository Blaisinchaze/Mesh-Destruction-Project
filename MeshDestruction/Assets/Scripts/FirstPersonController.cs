using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    #region --- helpers ---
    private static class MouseBtn
    {
        public static int primary = 0;
        public static int secondary = 1;
        public static int middle = 2;
    }
    public struct Sounds
    {
        public AudioSource erase;
        public AudioSource add;
        public AudioSource thrust;
    }
    #endregion

    public float Movespeed = 3.5f;
    public float Turnspeed = 120f;
    public Camera cam = null;
    public GameObject terraineditor = null;
    public GameObject player = null;
    private RaycastHit hit;
    //private Sounds snd;
    private Renderer rend = null;
    float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GameObject go = this.gameObject;
        //snd.erase = Globals.CreateAudioSource(go, "erase");
        //snd.add = Globals.CreateAudioSource(go, "add");
        //snd.thrust = Globals.CreateAudioSource(go, "thrust");

        rend = terraineditor.GetComponent<Renderer>();
    }
    private void Update()
    {
        //move, turn
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");
        player.transform.Translate(Vector3.forward * vert * Movespeed * Time.deltaTime);
        player.transform.Translate(Vector3.left * -horz * Movespeed * Time.deltaTime);

        //look up down
        float my = Input.GetAxis("Mouse Y") * Turnspeed * Time.deltaTime;
        float mx = Input.GetAxis("Mouse X") * Turnspeed * Time.deltaTime;

        xRotation -= my;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.transform.Rotate(Vector3.up * mx);

        //terrain editing
        //if (Input.GetMouseButton(MouseBtn.primary) == true)
        //{
        //    if (WhereDidIClick() == true)
        //        EditMarchCubeAdd();
        //}
        //else if (Input.GetMouseButton(MouseBtn.secondary) == true)
        //{
        //    if (WhereDidIClick() == true)
        //        EditMarchCubeErase();
        //}
        //else
        //{
        //    EditOff();
        //}
    }
    private bool WhereDidIClick()
    {
        //Note:
        //  set gridpoints to Ignore Raycast (layer 2) and maybe the terraineditor gameobject too.
        //  this way raycast will pick up on marching cube mesh only.
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit);       
    }
    private void EditMarchCubeAdd()
    {
        if (hit.transform.CompareTag("MarchCube") == false)
        {
            Debug.Log(string.Format("Raycast Hit = {0}", hit.transform.name));
            return;
        }
        //if (snd.add.isPlaying == false)
        //    snd.add.Play();
        terraineditor.tag = "Add";
        terraineditor.transform.localPosition = hit.point;
        rend.enabled = true;
        rend.material.color = Color.green;        
    }
    private void EditMarchCubeErase()
    {
        if (hit.transform.CompareTag("MarchCube") == false)
            return;
        //if (snd.erase.isPlaying == false)
        //    snd.erase.Play();
        terraineditor.tag = "Erase";
        terraineditor.transform.position = hit.point;
        rend.enabled = true;
        rend.material.color = Color.red;        
    }
    private void EditOff()
    {
        //if (snd.add.isPlaying == true)
        //    snd.add.Stop();
        //if (snd.erase.isPlaying == true)
        //    snd.erase.Stop();
        terraineditor.tag = "Untagged";
        rend.material.color = Color.white;
        rend.enabled = false;
    }
}
