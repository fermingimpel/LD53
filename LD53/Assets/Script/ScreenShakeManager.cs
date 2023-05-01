using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScreenShakeManager : MonoBehaviour
{
    public static ScreenShakeManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public IEnumerator ScreenShake(float duration, float magnitude)
    {
        GameObject mainCamera = Camera.main.gameObject;
        if (mainCamera)
        {
            Vector3 originalPos = mainCamera.transform.localPosition;
            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                mainCamera.transform.localPosition = new Vector3(x, y, originalPos.z);
                elapsedTime += Time.deltaTime;

                yield return null;
            }

            mainCamera.transform.localPosition = originalPos;
        }
    }
}