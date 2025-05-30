using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("이동")]
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;
    public float jumpPower = 6f;
    public float gravity = -20f;

    [Header("스태미너")]
    public float maxStamina = 5f;
    public float stamina = 5f;
    public float dashStaminaCost = 1f;    
    public float staminaRegenRate = 1f;
    public float lowStaminaSpeed = 2f;

    private bool isDashing;
    private bool isJumping;
    private Vector3 velocity;
    private CharacterController controller;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
        ApplyGravity();
        RegenerateStamina();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 inputDir = new Vector3(h, 0, v).normalized;

        Vector3 moveDir = transform.TransformDirection(inputDir);

        bool dashInput = Input.GetKey(KeyCode.LeftShift) && stamina > 0;

        if (dashInput)
        {
            isDashing = true;
            stamina -= dashStaminaCost * Time.deltaTime;
        }
        else
        {
            isDashing = false;
        }

        stamina = Mathf.Clamp(stamina, 0, maxStamina);

        float speed = stamina <= 0 ? lowStaminaSpeed : (isDashing ? dashSpeed : moveSpeed);

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpPower;
            }
        }

        Vector3 finalMove = moveDir * speed;
        controller.Move(finalMove * Time.deltaTime);
    }

    void ApplyGravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(new Vector3(0, velocity.y, 0) * Time.deltaTime);
    }

    void RegenerateStamina()
    {
        if (!isDashing && stamina < maxStamina)
        {
            stamina += staminaRegenRate * Time.deltaTime;
            stamina = Mathf.Clamp(stamina, 0, maxStamina);
        }
    }
}
