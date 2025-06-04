using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("이동")]
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;
    public float jumpPower = 6f;
    public float gravity = -9.8f;

    [Header("스태미너")]
    public float maxStamina = 5f;
    public float stamina = 5f;
    public float dashStaminaCost = 1f;
    public float staminaRegenRate = 1f;
    public float lowStaminaSpeed = 2f;
    private float lowStaminaTimer = 0f;
    private const float lowStaminaDuration = 2f;

    public static PlayerMovement Instance;
    private float reloadMoveSpeed;
    private bool isReloading = false;
    private bool isDashing;
    private bool isJumping;
    private Vector3 velocity;
    private CharacterController controller;

    public CameraController cameraController;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        ApplyGravity();
        RegenerateStamina();      
    }

    private void Awake() => Instance = this;

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

        // 스태미너가 0이 되면 타이머 발동
        if (stamina <= 0 && lowStaminaTimer <= 0f)
        {
            lowStaminaTimer = lowStaminaDuration;
        }

        // 타이머 감소
        if (lowStaminaTimer > 0f)
        {
            lowStaminaTimer -= Time.deltaTime;
        }

        // 이동속도 결정
        float speed = moveSpeed;
        if (isReloading)
        {
            speed *= 0.5f;
        }
        if (lowStaminaTimer > 0f)
        {
            speed = Mathf.Min(speed, lowStaminaSpeed); // 둘 중 더 느린 속도로 적용
        }

        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpPower;
        }

        Vector3 finalMove = moveDir * speed;
        controller.Move(finalMove * Time.deltaTime);
    }

    public void SetReloadSpeed(bool reloading)
    {
        isReloading = reloading;
        reloadMoveSpeed = moveSpeed; // 기본 이동속도를 저장
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
