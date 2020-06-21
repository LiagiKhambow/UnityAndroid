using UnityEngine;

public class PlayerControllerNew : MonoBehaviour
{

    [SerializeField]
    private LayerMask levelLayerMask;
    private Rigidbody2D _rb;
    private Animator _animator;
    private CircleCollider2D _circleCollider;
    private SpriteRenderer _spriteRenderer;

    private float characterMovement;
    private bool isCrouching;
    private bool isJumping;
    private float jumpTime;
    private bool isFalling;
    private float canJump = 0f;
    private bool isRightClickPressed;
    bool isfacingRight = true;
    
    public GameObject bulletPrefab;
    public float runSpeed = 5f;
    public float jumpForce = 10f;
    public float jumpDelay = 1f;
    public float crouchSpeedModifier = 1f;

    public float bulletSpeed = 20f;
    public float comboDelay = 1f;
    private float lastClickedTime = 0f;
    private int noOfClicks = 0;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        characterMovement = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded() && Time.time > jumpTime)
        {
            isJumping = true;
            _animator.SetInteger("ComboCount",0);
        }

        if (Time.time - lastClickedTime > comboDelay)
        {
            noOfClicks = 0;
            
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (noOfClicks < 2)
            {
                lastClickedTime = Time.time;
                noOfClicks++;
            }
            if (noOfClicks == 1)
            {
                _animator.SetTrigger("isAttacking");
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            _animator.SetTrigger("isAttacking");
            isRightClickPressed = true;
        }
        
        if (Input.GetButtonDown("Crouch") && IsGrounded())
        {
            isCrouching = true;
        }

        if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(characterMovement * runSpeed * Time.deltaTime, _rb.velocity.y);
        if (isJumping && IsGrounded())
        {
            isJumping = false;
            _rb.AddForce(new Vector2(0f, jumpForce));
            jumpTime = Time.time + jumpDelay;
            _animator.SetTrigger("isJumping");
        }

        if (!IsGrounded() && _rb.velocity.y <= 0)
        {
            isFalling = true;
            _animator.SetBool("isFalling", true);
        }
        if (isCrouching)
        {
            _animator.SetBool("isCrouching",true);
        }else if (!isCrouching)
        {
            _animator.SetBool("isCrouching",false);
        }
        if(characterMovement < 0 && isfacingRight){
            Flip();
        }else if(characterMovement > 0 && !isfacingRight){
            Flip();
        }
        _animator.SetFloat("Speed",Mathf.Abs(characterMovement));
        if (IsGrounded())
        {
            _animator.SetBool("isGrounded",true);
            _animator.SetBool("isFalling",false);
        }
    }
    
    private bool IsGrounded(){
        float extraHeightTest = .1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(_circleCollider.bounds.center, _circleCollider.bounds.size, 0f, Vector2.down, extraHeightTest, levelLayerMask);
        Color rayColor;
        if(raycastHit.collider != null){
            rayColor = Color.green;
        }else{
            rayColor  = Color.red;
        }
        // Debug.DrawRay(_circleCollider.bounds.center + new Vector3(_circleCollider.bounds.extents.x,0), Vector2.down*(_circleCollider.bounds.extents.y + extraHeightTest), rayColor);
        // Debug.DrawRay(_circleCollider.bounds.center - new Vector3(_circleCollider.bounds.extents.x,0), Vector2.down*(_circleCollider.bounds.extents.y + extraHeightTest), rayColor);
        // Debug.DrawRay(_circleCollider.bounds.center - new Vector3(_circleCollider.bounds.extents.x,_circleCollider.bounds.extents.y), Vector2.right*(_circleCollider.bounds.extents.y + extraHeightTest), rayColor);
        return raycastHit.collider != null;
    }

    private void Flip(){
        isfacingRight = !isfacingRight;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }

    public void TouchedCollectible()
    {
        Debug.Log("Collectible collected");
    }

    public void SpawnBullet()
    {
        if (isRightClickPressed)
        {
            GameObject clone;
            Vector2 bulletPosition = transform.position;
            bulletPosition.x = isfacingRight ? bulletPosition.x += 1f : bulletPosition.x -= 1f;
            clone = Instantiate(bulletPrefab,bulletPosition,transform.rotation);
            Bullet bullet = clone.GetComponent(typeof(Bullet)) as Bullet;
            bullet.Fire(bulletSpeed,isfacingRight);
            isRightClickPressed = false;
        }
        if (noOfClicks == 2)
        {
            _animator.SetTrigger("isAttacking2");
        }
    }
    
}
