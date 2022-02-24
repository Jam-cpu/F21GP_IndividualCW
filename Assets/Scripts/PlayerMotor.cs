using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;
    private Rigidbody rb;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float cameraRotationLimit = 85f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // create velocity vector
    public void Move (Vector3 _velocity)
    {
        velocity = _velocity;
    }

    // create rotation vector
    public void Rotate (Vector3 _rotation)
    {
        rotation = _rotation;
    }

    // create camera rotation vector
    public void RotateCamera (float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;
    }

    // Executes the movement based off the pre defined velocity vector
    // rb.MovePosition function takes into account the location of the rigid body when moving
    // this helps to perfrom physics checks such as collisions during movement
    void PerformMovement()
    {
        if (velocity != Vector3.zero)   // checks for change in variable value
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler (rotation));
        if (cam != null)    // set and clamp rotation
        {
            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }
    }

    // sets to execute every iterable frame
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
        Cursor.visible = false;
    }
}
// caleb big stinky