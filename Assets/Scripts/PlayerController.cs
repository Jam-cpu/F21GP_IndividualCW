using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]            // displays in inspector
    private float speed = 5f;
    private PlayerMotor motor;

    [SerializeField]
    private float lookSensitivity = 3;


    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        // velocity calculation
        float xMove = Input.GetAxisRaw("Horizontal");   // varies between -1 and 1
        float zMove = Input.GetAxisRaw("Vertical");     // varies between -1 and 1
        Vector3 moveHorizontal = transform.right * xMove;   // results in values 1, 0, or -1
        Vector3 moveVertical = transform.forward * zMove;   // sets movement vector to direction of camera in z plane
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed; // normalised so it fixes the vector length to one so the resulting velocity is constant
        motor.Move(velocity);   // applies the movement

        // calculate rotation as a 3D vector
        float yRot = Input.GetAxisRaw("Mouse X");   // moving the mouse in the X direction gives rotation around the y-axis
        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;
        motor.Rotate(rotation);

        // calculate camera rotation as a 3D vector
        float xRot = Input.GetAxisRaw("Mouse Y");   // moving the mouse in the X direction gives rotation around the y-axis
        float cameraRotationX = xRot * lookSensitivity;
        motor.RotateCamera(cameraRotationX);
    }
}