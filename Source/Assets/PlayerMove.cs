using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public Vector3 Velocity = new Vector3(0,0);
    public float Speed = 0.0000000001f;
    public float Strafe = 0.001f;
    public float Turn = 1f;
    public Quaternion To;
    public Vector2 Friction;

    void Update()
    {
        Vector3 localVelocity = transform.worldToLocalMatrix * Velocity;
        Vector3 accel = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //accel = transform.TransformDirection(accel);
        Debug.Log("accel1 = " + accel);
        accel = new Vector3(accel.x * Strafe, accel.y * Speed, accel.z * Speed);
        Debug.Log("accel2 = " + accel);
        localVelocity += accel;
        transform.Translate(localVelocity);
        Velocity = transform.localToWorldMatrix * localVelocity;

        var mousePos = Input.mousePosition;
        var screenPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
        Vector3 targetRot = new Vector3(0, 0, Mathf.Atan2((screenPos.y - transform.position.y), (screenPos.x - transform.position.x)) * Mathf.Rad2Deg - 90);
        //float cameraDif = -(Camera.main.transform.position.z - transform.position.z);
        //Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, cameraDif, Input.mousePosition.y));
        //transform.LookAt(target);
        //var targetDir = target - transform.position;
        //var newDir = Vector3.RotateTowards(transform.forward, targetRot, Turn, 0);
        //var vect = screenPos - transform.position;
        //transform.rotation = Quaternion.LookRotation(vect);
        //transform.eulerAngles = targetRot;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRot), Time.deltaTime*10);
        Debug.Log(Quaternion.Euler(transform.forward) + " - " + Quaternion.Euler(targetRot));
        //transform.rotation = Quaternion.LookRotation(targetRot); // Quaternion.LookRotation(newDir);
        //transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
