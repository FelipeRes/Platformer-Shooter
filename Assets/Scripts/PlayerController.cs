using UnityEngine;
using UnityEngine.InputSystem; // Add the Input System

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float jumpForce;
	public Rigidbody2D rigidbody;
	public BoxCollider2D collider;
	public Animator animator;
	public Bullet bulletPrefab;
	public SpriteRenderer spriteRenderer;
	public LayerMask floorLayerMask;

	private int direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		direction = 1;
	}

    // Update is called once per frame
    void Update()
    {

		if (Keyboard.current.dKey.isPressed) {
			rigidbody.linearVelocityX = speed;
			direction = 1;
			spriteRenderer.flipX = true;
		} else if (Keyboard.current.aKey.isPressed) {
			rigidbody.linearVelocityX = -speed;
			direction = -1;
			spriteRenderer.flipX = false;
		} else {
			rigidbody.linearVelocityX = 0;
		}


		bool isGrounded = false;
		// Verifica se tem algo na direcao do chao
		var result = Physics2D.BoxCast(this.transform.position, collider.size, 0, Vector2.down, 1, floorLayerMask);

		if(result.collider != null) {
			Debug.Log("Alguma coisa foi detectada!");

			// Se a distancia for muito proxima do objeto, pode se considerar aquilo como chao
			if(result.distance < 0.1f) {
				isGrounded = true;
			}
		}

		animator.SetBool("Walking", false);

		// Se esta no chao entao pode pular
		if (isGrounded) {
			if (Keyboard.current.spaceKey.wasPressedThisFrame) {
				rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			}
			if(rigidbody.linearVelocityX != 0) {
				animator.SetBool("Walking", true);
			}
		}

		if (Keyboard.current.iKey.wasPressedThisFrame) {
			var bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);
			bullet.direction = direction;
			animator.Play("Shoot");
		}
	}
}
