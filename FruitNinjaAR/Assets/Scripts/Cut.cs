using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour {

    public GameObject fruitsprefab;
    public GameObject halffruitprefab;

    bool swipe = true;
    GameObject gobj = null;

    Vector3 lastPosition;
    Vector3 deltaPosition;
    // Use this for initialization

    Ray GenerateMouseRay(Vector3 touchPos) {

        Vector3 mousePosFar = new Vector3(touchPos.x, touchPos.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(touchPos.x, touchPos.y, Camera.main.nearClipPlane);

        Vector3 mouseF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mouseN = Camera.main.ScreenToWorldPoint(mousePosNear);

        Ray mr = new Ray(mouseN, mouseF - mouseN);

        return mr;
    }


    void CoolDown() {

        swipe = true;
    }



    void Update() {

        if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0)))
        {
            Plane objplane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
            Ray mray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objplane.Raycast(mray, out rayDistance))
                lastPosition = mray.GetPoint(rayDistance);
        }
        else if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) || Input.GetMouseButton(0)))
        {
            Plane objplane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
            Ray mray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objplane.Raycast(mray, out rayDistance))
                this.transform.position = mray.GetPoint(rayDistance);

            Ray mouseRay = GenerateMouseRay(Input.mousePosition);
            RaycastHit hit;
            deltaPosition = this.transform.position - lastPosition;
            lastPosition = this.transform.position;

            if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit) && swipe)
            {
                gobj = hit.transform.gameObject;
                swipe = false;
                Invoke("CoolDown", 0.5f);
                if (gobj.tag == "apple") {

                    GameObject h1 = (GameObject) Instantiate(halffruitprefab, gobj.transform.position, gobj.transform.rotation);
                    h1.transform.rotation *= Quaternion.Euler(90, 0, 90);
                    h1.transform.Translate(0, 0, -5);
                    h1.GetComponent<Rigidbody>().velocity = gobj.GetComponent<Rigidbody>().velocity;
                    h1.GetComponent<Rigidbody>().AddTorque(deltaPosition);
                    h1.GetComponent<Rigidbody>().AddForce(deltaPosition);

                    GameObject h2 = (GameObject)Instantiate(halffruitprefab, gobj.transform.position, gobj.transform.rotation);
                    h2.transform.rotation *= Quaternion.Euler(-90, -90, 0);
                    h2.GetComponent<Rigidbody>().velocity = gobj.GetComponent<Rigidbody>().velocity;
                    h2.GetComponent<Rigidbody>().AddTorque(deltaPosition);
                    h2.GetComponent<Rigidbody>().AddForce(deltaPosition );
                    Destroy(gobj);
                }
            }
       }
    }

    // Update is called once per frame

}
