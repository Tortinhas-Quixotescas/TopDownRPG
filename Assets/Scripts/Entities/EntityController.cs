using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] protected Rigidbody2D rigidbody;
    [SerializeField] protected Animator animator;
    protected float lastXValue = 0;
    protected float lastYValue = -1;

    protected void Start()
    {
        this.rigidbody = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }

    protected void HandleMovementInput(Vector2 input)
    {
        this.rigidbody.velocity = input * this.moveSpeed;
        this.animator.SetFloat("xMovement", input.x);
        this.animator.SetFloat("yMovement", input.y);

        if (input != Vector2.zero)
        {
            this.lastXValue = input.x;
            this.animator.SetFloat("lastXValue", input.x);
            this.lastYValue = input.y;
            this.animator.SetFloat("lastYValue", input.y);
        }
    }

}
