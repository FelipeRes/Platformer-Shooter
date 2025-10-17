using UnityEngine;
using UnityEngine.InputSystem; // Add the Input System

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float jumpForce;
	public Rigidbody2D rigidbody;
	public BoxCollider2D collider;
	public LayerMask floorLayerMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		if (Keyboard.current.dKey.isPressed) {
			rigidbody.linearVelocityX = speed;
		} else if (Keyboard.current.aKey.isPressed) {
			rigidbody.linearVelocityX = -speed;
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

		// Se esta no chao entao pode pular
		if (isGrounded) {
			if (Keyboard.current.spaceKey.wasPressedThisFrame) {
				rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			}
		}
	}
}
