using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateTrigger : MonoBehaviour
{
    [SerializeField] private GameObject block;
    bool isOpened = false;
    private void OnTriggerEnter(Collider col)
    {
        if(isOpened == false)
        {
            isOpened = true;
            block.transform.position += new Vector3(0, 1, 0);
        }
    }
}
