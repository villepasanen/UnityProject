using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] SpriteRenderer _characterBody;
    [SerializeField] Animator _animator;
    private Rigidbody2D _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    _rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        HandlePlayerMovement();
    }
       

    private void HandlePlayerMovement()
    {
       /* Vanha  liikkumis systeemi
       float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");

       Vector2 movement = new Vector2(moveHorizontal, moveVertical);
       _rb.linearVelocity = movement; */
        Vector2 movement = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            movement.y += 1;

        if (Keyboard.current.sKey.isPressed)
            movement.y -= 1;

        if (Keyboard.current.aKey.isPressed)
            movement.x -= 1;

        if (Keyboard.current.dKey.isPressed)
            movement.x += 1;
        movement = Vector2.ClampMagnitude(movement, 1.0f); //Fixes faster diagonal movement
        _rb.linearVelocity = movement * movementSpeed;
        bool characterIsWalking = movement.magnitude  > 0f;
        _animator.SetBool("isWalking", characterIsWalking);

        bool flipSprite = movement.x < 0f;
        _characterBody.flipX = flipSprite;
    }
}

