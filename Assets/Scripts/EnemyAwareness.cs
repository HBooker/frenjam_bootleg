using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public Material aggroMat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().material = aggroMat;
        }
    }
}
