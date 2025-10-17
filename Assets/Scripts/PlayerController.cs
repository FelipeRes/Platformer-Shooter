using UnityEngine;
using UnityEngine.InputSystem; // Add the Input System

public class PlayerController : MonoBehaviour
{
	public float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed) {
			this.transform.position += Vector3.up * Time.deltaTime * speed;
		}

		if (Keyboard.current.sKey.isPressed) {
			this.transform.position += Vector3.down * Time.deltaTime * speed;
		}

		if (Keyboard.current.dKey.isPressed) {
			this.transform.position += Vector3.right * Time.deltaTime * speed;
		}

		if (Keyboard.current.aKey.isPressed) {
			this.transform.position += Vector3.left * Time.deltaTime * speed;
		}

	}
}
