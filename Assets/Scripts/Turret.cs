using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]
    public float range = 15f;
    public GameObject turretRange;

    [Header("Use Bullets (default")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    [SerializeField] bool useLaser = false;

    [SerializeField] int damageOverTime = 30;
    [SerializeField] float slowAmount = 0.5f;

    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] ParticleSystem impactEffect;
    [SerializeField] Light impactLight;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    bool shouldPlaySound = false;

    [Header("Unity setup fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        if (turretRange == null)
            return;
        else
            StartCoroutine(showTurretRange());
	}

    public IEnumerator showTurretRange()
    {
        turretRange.transform.localScale = new Vector2(range, range) * 2;
        yield return new WaitForSeconds(5);

        turretRange.SetActive(false);
    }


    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }   
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (target == null)
        {
            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
	}

    void LockOnTarget()
    {
        //Used to rotate a part towards the target (target lock on)
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        shouldPlaySound = true;
        targetEnemy.GetComponent<Enemy>().TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slowAmount);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

        if (shouldPlaySound && !audioSource.isPlaying)
        {
          //  audioSource.loop = true;
            audioSource.Play();
        }
            //audioSource.Play();

            shouldPlaySound = false;
        //audioSource.PlayOneShot(audioSource.clip, 0.5f);
    }

    public void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        audioSource.Play();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected() //allows me to show range in scene view
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
