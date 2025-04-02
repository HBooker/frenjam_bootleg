using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 20.0f;
    public float verticalRange = 20.0f;
    public EnemyManager enemyManager;
    public float fireRate = 1.0f;
    public float smallDamage = 1.0f;
    public float bigDamage = 2.0f;
    public LayerMask raycastLayerMask;

    private float nextTimeToFire;
    private BoxCollider gunTrigger;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1.0f, verticalRange, range);
        gunTrigger.center = new Vector3(0f, 0f, range * 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire)
        {
            Fire();
        }
    }

    void Fire()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();

        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            Vector3 dir = enemy.transform.position - transform.position;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);

                    if (dist > range * 0.5f)
                    {
                        enemy.TakeDamage(smallDamage);
                    }
                    else
                    {
                        enemy.TakeDamage(bigDamage);
                    }
                }

                //Debug.DrawRay(transform.position, dir, Color.green);
                //Debug.Break();
            }
        }

        nextTimeToFire = Time.time + fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
