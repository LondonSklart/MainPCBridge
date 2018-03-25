using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningWheel : MonoBehaviour
{
    public  GameObject wheeltoSpin;
    public GameObject wheel;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Sword")
        {
            wheel.transform.Rotate(0, 200 * Time.deltaTime, 0);
            wheeltoSpin.transform.Rotate(0, 200 * Time.deltaTime, 0);
        }

    }


}
