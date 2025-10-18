using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int direction = 1;  // 1 eh direita, -1 eh esquerda
    public float timeToDestroy;

    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);

	}

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.right * speed * direction * Time.deltaTime;

	}
}
