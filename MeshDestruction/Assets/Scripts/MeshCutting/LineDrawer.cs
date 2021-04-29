using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField]
    Camera camera;
    private bool lineStart;

    Vector3 StartPoint;
    Vector3 EndPoint;

    LineRenderer line;

    [SerializeField]
    MeshDestroy mesh;
    // Start is called before the first frame update
    void Start()
    {
        lineStart = false;
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            if(lineStart == true)
            {
                var screenPoint = Input.mousePosition;
                screenPoint.z = camera.transform.forward.z + 2;
                EndPoint = Camera.main.ScreenToWorldPoint(screenPoint);
                line.SetPosition(1, EndPoint);
                SliceShape();
            }
            else
            {
                var screenPoint = Input.mousePosition;
                screenPoint.z = camera.transform.forward.z + 2;
                StartPoint = Camera.main.ScreenToWorldPoint(screenPoint);
                lineStart = true;
                line.SetPosition(0, StartPoint);
            }

        }
        if(lineStart)
        {
            var screenPoint = Input.mousePosition;
            screenPoint.z = camera.transform.forward.z + 2;
            EndPoint = Camera.main.ScreenToWorldPoint(screenPoint);
            line.SetPosition(1, EndPoint);
        }
        else
        {
            line.SetPosition(0, new Vector3(0,0,0));
            line.SetPosition(1, new Vector3(0,0,0));
        }
    }

    private void SliceShape()
    {
        Plane plane = new Plane(StartPoint, EndPoint, EndPoint + camera.transform.forward * 5);
        lineStart = false;
        //mesh.DestroyWithPlane(plane);
        foreach (var item in GameObject.FindGameObjectsWithTag("Cuttable"))
        {
            item.GetComponent<MeshDestroy>().DestroyWithPlane(plane);
        }
        //RaycastHit hit;
        //if (Physics.Linecast(StartPoint, camera.transform.forward * 5, out hit))
        //{
        //    if (hit.transform.gameObject.GetComponent<MeshDestroy>() != null)
        //    {
        //        hit.transform.gameObject.GetComponent<MeshDestroy>().DestroyWithPlane(plane);
        //    }
        //}
    }
}
