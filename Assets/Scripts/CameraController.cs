using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        transform.position = new(target.position.x, target.position.y, transform.position.z);
    }
}
