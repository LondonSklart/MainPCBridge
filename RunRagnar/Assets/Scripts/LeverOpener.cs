using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverOpener : MonoBehaviour
{
    public Wall wallToOpen;
    public GameObject SpiningWheel;
    private Quaternion originalRotation;

    private void Start()
    {
         originalRotation= SpiningWheel.transform.rotation;

    }
    private void Update()
    {
        if (SpiningWheel != null && SpiningWheel.transform.rotation.y > originalRotation.y)
        {
            SpiningWheel.transform.Rotate(0, -20 * Time.deltaTime, 0);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Sword")
        {
            wallToOpen.OpenWall("Slow");
            SpiningWheel.transform.Rotate(0, 10, 0);
        }
    }
}
