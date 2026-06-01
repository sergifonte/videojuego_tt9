using UnityEngine;

public class CameraFollowFixed : MonoBehaviour
{
    [Header("Objectiu a seguir")]
    [SerializeField] private Transform target;

    [Header("Configuració de Distància")]
    [Tooltip("Distància relativa de la càmera respecte al personatge (X, Y, Z)")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 6f, -8f);

    [Tooltip("Temps de resposta de la càmera. Com més baix, més ràpida.")]
    [SerializeField] private float smoothTime = 0.25f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target == null) return;

        //posicio inicial
        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    }
}