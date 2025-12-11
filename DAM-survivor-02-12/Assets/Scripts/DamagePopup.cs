using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer = 1f; 
    private float moveSpeed = 2f; 

    void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    public void Setup(int damageAmount)
    {
        textMesh.text = damageAmount.ToString();
    }

    void Update()
    {
        //1. Mover hacia arriba
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        //Invertimos la dirección para que mire DE FRENTE y no nos dé la espalda
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);

        //3. Temporizador para desaparecer
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            Color textColor = textMesh.color;
            textColor.a -= 3f * Time.deltaTime;
            textMesh.color = textColor;

            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}