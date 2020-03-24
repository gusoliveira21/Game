using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	// Before rendering each frame..
	void Update () 
	{
		transform.Rotate (Vector3.up);
	}
}	