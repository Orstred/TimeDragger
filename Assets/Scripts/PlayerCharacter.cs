using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerCharacter : MonoBehaviour
{

    //The controller attached to the character
    private CharacterController controller;
    //Normal speed
    public float WalkSpeed;
    //Speed when sprinting
    public float RunSpeed;
    //the speed parameter that is used by the code 
    [HideInInspector]
    public float Speed;




    #region Gravity
    //bool that tells if the player is grounded
   // [HideInInspector]
    public bool isGrounded;
    //Vertical force applied when not in the air
    public float weight;
    //Position of an imaginary sphere that checks if the player is on the ground
    public Transform groundcheck;
    //Which layers should count as ground
    public LayerMask groundmask;
    //Diameter of an imaginary sphere that checks if the player is on the ground
    public float grounddistance = 0.4f;
    //jump height in unity units 
    public float Jumpheight;
    //Speed at wich the player character follows the camera rotation
    public float RotationSpeed;
    //used to set the gravity
    Vector3 velocity;
    #endregion
    #region pickupbox
    public Vector3 boxposition;
    #endregion

    Vector3 move;

    private void Start()
    {

 
        controller = GetComponent<CharacterController>();
    }







    void Update()
    {

        #region Base State
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = weight * Time.deltaTime;
        }

        //checks if a hipotetic sphere is touching the ground
        isGrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
        //The rotation for the player
        Quaternion CameraYRotation = Quaternion.Euler(0, -180, 0);

        //Gets the horizontal and vertical axis from the unity input system
        float z = 0;
        float x = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Vertical") > 0)
        {
           z = Input.GetAxis("Vertical");
        }
      
        //Rotates the player to face where the camera is facing
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, CameraYRotation, Time.deltaTime * RotationSpeed);

        }
        //Rotates the player to face where the camera is facing + 90 degrees
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(CameraYRotation.eulerAngles.x, CameraYRotation.eulerAngles.y + 90, CameraYRotation.eulerAngles.z), Time.deltaTime * RotationSpeed);
            if (Input.GetKey(KeyCode.S) != true)
                z = 1;
        }
        //Rotates the player to face where the camera is facing - 90 degrees
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(CameraYRotation.eulerAngles.x, CameraYRotation.eulerAngles.y - 90, CameraYRotation.eulerAngles.z), Time.deltaTime * RotationSpeed);
            if (Input.GetKey(KeyCode.S) != true)
                z = 1;
        }
        //Rotates the player to face where the camera is facing + 180 degrees
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(CameraYRotation.eulerAngles.x, CameraYRotation.eulerAngles.y - 180, CameraYRotation.eulerAngles.z), Time.deltaTime * RotationSpeed);
            z = 1;
        }
       



        //sets a new vector 3 based on the x and z axis

        move = transform.forward * z;


        //Lerps the player to move direction
        controller.Move(move * Speed * Time.deltaTime);



        //Sets the gravity parameter
        velocity.y -= weight * Time.deltaTime;
        //Applies gravity
        controller.Move(velocity * Time.deltaTime);



        #endregion

    }
    private void LateUpdate()
    {




        //Sets running speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = Mathf.Lerp(Speed, RunSpeed, Time.deltaTime * 1);
            return;
        }
        //Sets walking speed
        else if (Speed != WalkSpeed)
            Speed = Mathf.Lerp(Speed, WalkSpeed, Time.deltaTime * 1);

    }


    public void Jump()
    {
        //Uses real world physics to make the character jump
        velocity.y = Mathf.Sqrt(Jumpheight * 2f * weight);
    }

    public void Pickupbox(GameObject box)
    {
        box.GetComponent<Rigidbody>().isKinematic = true;
        box.transform.parent = transform;
        box.transform.position = boxposition + transform.position;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(boxposition + transform.position, .2f);
        //Draws in editor the hipotetic sphere used for checking the ground
        Gizmos.DrawWireSphere(groundcheck.transform.position, grounddistance);

        //Draws a line with a sphere at the end representing the jump height
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y + Jumpheight, transform.position.z));
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y + Jumpheight, transform.position.z), .1f);
    }
}
