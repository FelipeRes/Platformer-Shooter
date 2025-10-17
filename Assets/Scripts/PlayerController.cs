using UnityEngine;
using UnityEngine.InputSystem; // Add the Input System

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float jumpForce;
	public Rigidbody2D rigidbody;

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

		if (Keyboard.current.spaceKey.wasPressedThisFrame) {
			rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}



	}
}
