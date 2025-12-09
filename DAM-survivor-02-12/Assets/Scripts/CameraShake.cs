using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour{
    public float duration = 0.2f; 
    public FollowCamera followCamera;
    private Vector3 originalPos;


    public void Shake()
    {
        Debug.Log("He llegado hasta el shake.");
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine());
    }


    private IEnumerator ShakeRoutine()
    {
        originalPos = transform.position;
        float elapsed = 0f;

        followCamera.enabled = false;
        while (elapsed < duration)
        {
            Vector3 offset = Random.insideUnitCircle * 0.15f; //esto es la magnitud
            transform.position = originalPos + offset;

            elapsed += Time.deltaTime;
            Debug.Log("He llegado hasta la corrutina por dentro.");
            yield return null;
        }
        followCamera.enabled = true;
        transform.position = originalPos;
    }
}
