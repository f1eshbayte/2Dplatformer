using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private float _groundCheckRadius = 0.2f;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _playerSprite;
    private bool _isGrounded;

    private const string Attack = "Attack";
    private const string Speed = "Speed";
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        _rigidbody2D.velocity = new Vector2(moveInput * _moveSpeed, _rigidbody2D.velocity.y);

        _isGrounded = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckRadius, _groundLayer);
        
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }

        _animator.SetFloat(Speed, moveInput); // currentSpeed добавть надо
        AjustableFliping(moveInput);
    }

    private void AjustableFliping(float side)
    {
        if (side == 1.0)
        {
            _playerSprite.flipX = false;
        }
        else if(side == -1.0)
        {
            _playerSprite.flipX = true;            
        }
    }
}