using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private DynamicJoystick joystick;
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Animator animator;

    public bool isAttacking = false;

    public float movSpeed = 0.0f;
    public float rotSpeed = 0.0f;

    [SerializeField]
    private GameObject enemy;


    private void FixedUpdate()
    {
        Movement();
        AimEnemy();
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

        if (!isAttacking) 
        {
            Vector3 lookDirection = Vector3.RotateTowards(controller.transform.forward, movmentDirection, rotSpeed * Time.deltaTime, 0.0f);
            controller.transform.rotation = Quaternion.LookRotation(lookDirection);
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (!isAttacking)
            {
                isAttacking = true;
                enemy = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if (isAttacking)
            {
                isAttacking = false;
                enemy = null;
            }
        }
    }

    private void Attack()
    {
        
    }

    private void AimEnemy()
    {
        if(enemy != null)
        {
            Vector3 enemyPosition = new Vector3(enemy.transform.position.x, 0.0f, enemy.transform.position.z);
            Vector3 aimDirection = Vector3.RotateTowards(controller.transform.forward, enemyPosition, rotSpeed * Time.deltaTime, 0.0f);
            controller.transform.rotation = Quaternion.LookRotation(enemyPosition);
        }
    }

}
