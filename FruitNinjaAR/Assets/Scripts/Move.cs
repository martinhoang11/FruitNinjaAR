using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine("Moving");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 3f * Time.deltaTime);
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(1f);
        transform.eulerAngles += new Vector3(0, 180f, 0);

        while (true)
        {
            yield return new WaitForSeconds(2f);    
            transform.eulerAngles += new Vector3(0, 180f, 0);
        }
    }
}