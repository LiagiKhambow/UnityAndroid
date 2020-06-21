/*
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private LayerMask levelLayerMask;
    
    private enum PlayerState{
        Idle,Run,Jump,Fall,Crouch,Climb,Hurt
    }

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    CircleCollider2D circleCollider;

    public float runSpeed = 3f;
    public float climbSpeed = 2f;
    public float jumpForce = 100f;
    public bool canClimb = false;

    Vector2 movement = new Vector2(0f,0f);
    bool facingRight = true;
    bool isCrouching = false;
    bool isFalling = false;
    bool isJumping = false;
    bool isClimbing = false;

    private PlayerState _state;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate() {
        if (IsGrounded() && canClimb)
        {
            //animator.SetInteger("States",(int)PlayerState.Idle);
            //animator.SetBool("isClimbing", false);
        }
        if (!canClimb)
        {
            rb.velocity = new Vector2(movement.x * runSpeed, rb.velocity.y);
        }
        else if(canClimb && movement.y != 0)
        {
            //animator.SetInteger("State",(int)PlayerState.Climb);
            rb.velocity = new Vector2(movement.x * runSpeed, climbSpeed);
        }

        //animator.SetFloat("State", (int)_state);
        if(movement.x < 0 && facingRight){
            Flip();
        }else if(movement.x > 0 && !facingRight){
            Flip();
        }
        else{
            animator.SetBool("isFalling", false);
        }
        if(isCrouching && IsGrounded()){
            animator.SetBool("isCrouching",true);
        }
        if(isJumping && IsGrounded()){
            isJumping = false;
            animator.SetTrigger("isJumping");
            rb.velocity = new Vector2(movement.x * runSpeed, jumpForce);
        }
        if(!IsGrounded() && rb.velocity.y <= 0){
            animator.SetBool("isFalling",true);
        }
    }

    private bool IsGrounded(){
        float extraHeightTest = .3f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(circleCollider.bounds.center, circleCollider.bounds.size, 0f, Vector2.down, extraHeightTest, levelLayerMask);
        Color rayColor;
        if(raycastHit.collider != null){
            rayColor = Color.green;
        }else{
            rayColor  = Color.red;
        }
        Debug.DrawRay(circleCollider.bounds.center + new Vector3(circleCollider.bounds.extents.x,0), Vector2.down*(circleCollider.bounds.extents.y + extraHeightTest), rayColor);
        Debug.DrawRay(circleCollider.bounds.center - new Vector3(circleCollider.bounds.extents.x,0), Vector2.down*(circleCollider.bounds.extents.y + extraHeightTest), rayColor);
        Debug.DrawRay(circleCollider.bounds.center - new Vector3(circleCollider.bounds.extents.x,circleCollider.bounds.extents.y), Vector2.right*(circleCollider.bounds.extents.y + extraHeightTest), rayColor);
        return raycastHit.collider != null;
    }

    private bool IsClimbing()
    {
        return (isClimbing && !IsGrounded());
    }
    
    private void Flip(){
        facingRight = !facingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        if (movement.x != 0)
        {
            _state = PlayerState.Run;
        }
        else
        {
            _state = PlayerState.Idle;
        }
    }

    public void OnJump(InputAction.CallbackContext context){
        if (context.performed)
        {
            isJumping = true;
        }
    }

    public void OnCrouch(InputAction.CallbackContext context){
        if(context.started){
            isCrouching = true;
        }
        else if(context.canceled){
            isCrouching = false;
        }
    }
    
}
*/
