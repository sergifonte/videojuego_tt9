using UnityEngine;

public class Landing : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(hit.transform);
        }
        else
        {
            transform.SetParent(null);
        }
    }
}