using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateTrigger : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private Door door;
    //bool isOpened = false;
    private void OnTriggerEnter(Collider col)
    {
        /*
        if(isOpened == false)
        {
            isOpened = true;
            block.transform.position += new Vector3(0, 1, 0);
        }
        */

        if (!door.IsOpen)
        {
            door.Open();
        }
        else if (door.IsOpen)
        {
            door.Close();
        }

    }
}
