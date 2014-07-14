using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {

    public GameObject Background;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Background.transform.localPosition = new Vector3(-transform.position.x * 0.1f, -transform.position.y * 0.1f, 10);
	}
}
