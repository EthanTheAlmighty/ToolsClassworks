using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]//you select this thing in the heirarchy
public class GizmoExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmos()
    {
        //Gizmos.DrawIcon(transform.position, "the thing i want");
    }

    //only called if the object is selected
    void OnDrawGizmosSelected()
    {

    }
}
