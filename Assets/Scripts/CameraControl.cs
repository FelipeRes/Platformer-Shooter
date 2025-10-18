using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed;
    public Vector3 offset;
    public Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(target.transform.position + offset, this.transform.position, speed * Time.deltaTime);
    }
}
