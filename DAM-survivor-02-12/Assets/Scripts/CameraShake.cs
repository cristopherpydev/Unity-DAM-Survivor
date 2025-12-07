using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public float duration = 0.2f; 
    public float magnitude = 0.3f;

    private Vector3 originalPos;

    void Awake()
    {
        originalPos = transform.localPosition;
    }

    public void Shake()
    {
        Debug.Log("Shake() llamado en " + gameObject.name);
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine());
    }


    private IEnumerator ShakeRoutine()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            //Se simula el movimiento aleatorio en una esfera unitaria
            Vector3 offset = Random.insideUnitSphere * magnitude;
            transform.localPosition = originalPos + offset;

            elapsed += Time.deltaTime;
            yield return null;
        }

        //y para cuando termine, tenemos que volver a la posición original
        transform.localPosition = originalPos;
    }
}
