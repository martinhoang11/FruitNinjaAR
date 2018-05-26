using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyme : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnBecameInvisible() {

        Destroy(this.gameObject.transform.root.gameObject);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
