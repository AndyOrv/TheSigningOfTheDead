using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightZone : MonoBehaviour
{
    public GameObject Starter;
    public Transform nodeLocation;
    public int zone;


    void Start ()
    {

    }
    void Update()
    {
        
        if (GameObject.FindGameObjectWithTag("Zombie" + zone) == null)
        {
            Instantiate(Starter, nodeLocation.position, nodeLocation.rotation);
            Destroy(gameObject);
        }

    }
}
