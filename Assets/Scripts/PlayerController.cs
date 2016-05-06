using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float maxVelocityChange;
    public float jumpSpeed;
    public float sensitivity;
    private Rigidbody rb;
    private GameObject head;
    private Vector3 movement;
    private bool onFloor;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        head = transform.Find("Head").gameObject;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        head.transform.Rotate(new Vector3(0, mouseX, 0) * sensitivity, Space.World);
        float rotateCamX = -mouseY * sensitivity;
        if (head.transform.localRotation.eulerAngles.x >= 270 && head.transform.localRotation.eulerAngles.x + rotateCamX < 280) {
            rotateCamX = -(head.transform.localRotation.eulerAngles.x - 280);
        } else if (head.transform.localRotation.eulerAngles.x <= 90 && head.transform.localRotation.eulerAngles.x + rotateCamX > 80) {
            rotateCamX = 80 - head.transform.localRotation.eulerAngles.x;
        }
        head.transform.Rotate(new Vector3(rotateCamX, 0, 0));

        float maxVelocityChangeGround;
        if (onFloor) {
            maxVelocityChangeGround = maxVelocityChange;
        } else {
            maxVelocityChangeGround = maxVelocityChange / 4;
        }

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 movement = head.transform.TransformDirection(new Vector3(Mathf.Abs(direction.normalized.x) * direction.x, 0, Mathf.Abs(direction.normalized.z) * direction.z) * speed);
        Vector3 velocityChange = movement - rb.velocity;
        velocityChange.y = 0;
        if (velocityChange.magnitude > 0) {
            float magnitude = Mathf.Clamp(velocityChange.magnitude, -maxVelocityChangeGround, maxVelocityChangeGround);
            float ratio = magnitude / velocityChange.magnitude;
            velocityChange.x = velocityChange.x * ratio;
            velocityChange.z = velocityChange.z * ratio;
            rb.AddForce(velocityChange, ForceMode.VelocityChange);
        }
        onFloor = false;
    }

    void OnCollisionStay(Collision collision) {
        onFloor = true;
        if (Input.GetKeyDown(KeyCode.Space))
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
    }
}
