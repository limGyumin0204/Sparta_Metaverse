using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    [SerializeField] private float walkSpeed = 4f;
    [SerializeField] private float runSpeed = 7f;
    protected bool isRunning = false;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    protected AnimationHandler animationHandler;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        RotateLookDirection();
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }

    private void Movement(Vector2 direction)
    {
        float speed = isRunning ? runSpeed : walkSpeed;
        Vector2 moveVelocity = direction * speed;

        _rigidbody.velocity = moveVelocity;

        animationHandler.Move(direction);
        if (animationHandler != null) animationHandler.Move(moveVelocity);
    }

    private void RotateLookDirection()
    {
        if (movementDirection.x < 0)
        {
            characterRenderer.flipX = true;
        }
        else if (movementDirection.x > 0)
        {
            characterRenderer.flipX = false;
        }
    }
}
