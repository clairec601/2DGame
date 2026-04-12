using UnityEngine;

public class camera_follow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float yThreshold = 3f;  // how far up/down before camera follows

    private Vector3 targetPos;

    void LateUpdate()
    {
        targetPos = transform.position;

        float yDiff = player.position.y - transform.position.y;

        // Only move if player goes beyond threshold
        if (Mathf.Abs(yDiff) > yThreshold)
        {
            targetPos.y = player.position.y - (yThreshold * Mathf.Sign(yDiff));
        }

        transform.position = targetPos;
    }
}