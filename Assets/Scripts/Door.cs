using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool IsOpen = false;
    [SerializeField] private bool isSlidingDoor = true;
    [SerializeField] private float Speed = 1f;
    [Header("Sliding Configs")]
    [SerializeField] private Vector3 slideDirection = Vector3.up.normalized;
    [SerializeField] private float slideAmount = 1900f;

    private Vector3 StartPosition;

    private Coroutine animationCoroutine;

    private void Awake()
    {
        StartPosition = transform.position;
    }

    public void Open()
    {
        if (!IsOpen)
        {
            if (animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }

            if (isSlidingDoor)
            {
                animationCoroutine = StartCoroutine(DoSlidingOpen());
            }
        }
    }

    private IEnumerator DoSlidingOpen()
    {
        Vector3 endposition = StartPosition + slideAmount * slideDirection;
        Vector3 startPosition = transform.position;
        float time = 0;
        IsOpen = true;
        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, endposition, time);
            yield return null;
            time += Time.deltaTime * Speed;

        }
    }

    public void Close()
    {
        if (IsOpen)
        {
            if(animationCoroutine != null)
            {
                StopCoroutine(animationCoroutine);
            }
            if (isSlidingDoor)
            {
                animationCoroutine = StartCoroutine(DoSlidingClose());
            }
        }
    }

    private IEnumerator DoSlidingClose()
    {
        Vector3 endposition = StartPosition;
        Vector3 startPosition = transform.position;
        float time = 0;

        IsOpen = false;

        while (time < 1)
        {
            transform.position = Vector3.Lerp(startPosition, endposition, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }

    }


}
