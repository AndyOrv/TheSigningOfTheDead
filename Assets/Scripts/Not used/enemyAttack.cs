using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public float fireRange;
    public GameObject Scatter;
    public GameObject attackingObject;
    public Transform playerTarget;
    public GameObject PlayerObject;
    public float fireRate;
    private float nextFire;
    playerHealth p_Health;
    public int attackDamage = 1;

    void Awake()
    {
        p_Health = PlayerObject.GetComponent<playerHealth>();
    }
    void Start()
    {
        StartCoroutine(delayBeforeFire());
    }

    IEnumerator delayBeforeFire()
    {
        yield return new WaitForSeconds(5);
        {
            transform.LookAt(playerTarget);
        }
    }

    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            RaycastHit hit;
            if (Physics.Raycast(attackingObject.transform.position, transform.TransformDirection(Vector3.forward), out hit, fireRange))
            {
                Debug.DrawRay(attackingObject.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");

                p_Health.TakeDamage(attackDamage);

                GameObject hurtSpark = Instantiate(Scatter, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hurtSpark, 1f);
            }
            else
            {
                Debug.DrawRay(attackingObject.transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }
    }
}
