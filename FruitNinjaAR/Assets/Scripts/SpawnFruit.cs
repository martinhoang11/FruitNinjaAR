using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnFruit : MonoBehaviour {

    public GameObject[] fruitPrefab;
   
    // Use this for initialization
    void Start() {
        StartCoroutine(Spawn());
    }

       IEnumerator Spawn() {

        while (true)
        {
            GameObject go = Instantiate(fruitPrefab[Random.Range(0, fruitPrefab.Length)]);
            Rigidbody temp = go.GetComponent<Rigidbody>();

            temp.velocity = new Vector3(Random.Range(-2f, 2f), Random.Range(5f, 10f), Random.Range(-1f, 1f));
            temp.angularVelocity = new Vector3(Random.  Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));   
            temp.useGravity = true;

            Vector3 pos = transform.position;
            pos.x += Random.Range(-0.2f, 0.2f);
            go.transform.position = pos;

            yield return new WaitForSeconds(Random.Range(0.1f, 1f));
        }

    }

    //private void OnTrackingLost()
    //{

    //    Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
    //    Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
    //    if (!bol)
    //    {
    //        Disable rendering:
    //        foreach (Renderer component in rendererComponents)
    //        {
    //            component.enabled = false;
    //        }

    //        Disable colliders:
    //        foreach (Collider component in colliderComponents)
    //        {
    //            component.enabled = false;
    //        }
    //        bol = true;
    //    }
    //}
}

