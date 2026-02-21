using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float pixelsPerUnit = 16f;
    public float acceleration = 10f;

    private Animator anim;
    private CharacterController controller;
    private Vector2 input;
    private Vector3 currentVelocity;
    private float pixelUnit;

    private Vector2 lastDirection;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        pixelUnit = 1f / pixelsPerUnit;
    }

void Update()
{
    float h = Input.GetAxisRaw("Horizontal");
    float v = Input.GetAxisRaw("Vertical");

    Vector2 rawInput = new Vector2(h, v).normalized;

    if (rawInput.magnitude > 0.1f)
    {
        input = rawInput.normalized;
        lastDirection = input;

        // andando
        anim.SetFloat("moveX", input.x);
        anim.SetFloat("moveY", input.y);

        anim.speed = 1f;
    }
    else
    {
        input = Vector2.zero;

        // PARADO → zera direção
        anim.SetFloat("moveX", lastDirection.x);
        anim.SetFloat("moveY", lastDirection.y);

         anim.Play(0, 0, 1f);

        // congela animação no frame atual
        anim.speed = 0f;
    }
}

    void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector3(input.x, 0, input.y) * moveSpeed;
        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
        controller.Move(targetVelocity * Time.fixedDeltaTime);
        SnapToPixelGrid();
    }

    void SnapToPixelGrid()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Round(pos.x / pixelUnit) * pixelUnit;
        pos.z = Mathf.Round(pos.z / pixelUnit) * pixelUnit;
        transform.position = pos;
    }
}
