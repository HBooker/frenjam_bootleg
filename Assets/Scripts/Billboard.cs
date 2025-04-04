using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera cam;
    // private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        //rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(cam.transform.position, Vector3.up);
        transform.Rotate(0f, 180f, 0f);
        //transform
    }
}
