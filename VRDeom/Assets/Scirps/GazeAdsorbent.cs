using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GazeAdsorbent : MonoBehaviour
{

    Ray ray;
    RaycastHit hitInfo;
    public GameObject smallCube;
    public GameObject myCube;

    public static GazeAdsorbent instans;

    private GameObject galleey;
    public GameObject Galleey
    {
        get { return this.galleey; }
    }
    private GameObject smaGameObject;
    public GameObject SmaGameObject
    {
        get { return this.smaGameObject; }
    }
    void Start()
    {
        if (instans == null)
        {
            instans = this;
        }

    }

    void Update()
    {
        //Camera .main .transform .position 
        ray = new Ray(transform.position, transform.forward);
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //transform.Rotate(transform.up, Input.GetAxis("Mouse X"));
        //transform.Rotate(transform.right, -Input.GetAxis("Mouse Y"));
        if (Physics.Raycast(ray, out hitInfo, 20f, 1 << 0))
        {
            smallCube.transform.position = hitInfo.point;
            smallCube.transform.forward = hitInfo.normal;
            this.galleey = hitInfo.transform.gameObject;
        }
        else
        {
            this.galleey = null;
            smallCube.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Physics.Raycast(ray, out hitInfo, 20f, 1 << 9))
        {
            //Material ma = hitInfo.collider.gameObject.GetComponent<MeshRenderer>().material;
            //Material mb = myCube.GetComponent<MeshRenderer>().material;
            //mb.color = ma.color;
            this.smaGameObject = hitInfo.transform.gameObject;

        }
        else
        {
            this.smaGameObject = null;
        }
    }


}
