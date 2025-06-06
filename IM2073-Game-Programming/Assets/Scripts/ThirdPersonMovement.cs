//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    [SerializeField]
    public float speed = 6.4f;
    [SerializeField]

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private Animator animator;
    private string currentAnimation = "";

    private Vector3 direction;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.SimpleMove(moveDir.normalized * speed * Time.deltaTime);
        }

        CheckAnimation();
    }

    private void CheckAnimation()
    {
        if (direction.magnitude >= 0.1f)
        {
            ChangeAnimation("Run");
        }
        else
        {
            ChangeAnimation("Idle");
        }
    } 

    private void ChangeAnimation(string animation, float crossfade = 0.2f)
    {
        if (currentAnimation !=  animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossfade);
        }
    }
}
