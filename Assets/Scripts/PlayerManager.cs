using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private DynamicJoystick joystick;
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Animator animator;

    

    public float movSpeed = 0.0f;
    public float rotSpeed = 0.0f;


    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 movmentDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
        controller.SimpleMove(movmentDirection * movSpeed);
        
        if(movmentDirection.sqrMagnitude <= 0)
        {
            animator.SetBool("speed",false);
            return;
        }
        animator.SetBool("speed", true);

        Vector3 lookDirection = Vector3.RotateTowards(controller.transform.forward, movmentDirection, rotSpeed * Time.deltaTime, 0.0f);
        controller.transform.rotation = Quaternion.LookRotation(lookDirection);

    }

}
