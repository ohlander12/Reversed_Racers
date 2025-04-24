using UnityEngine;

public class EnemyDriver : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints; // S�t dine waypoint-objekter i denne array i Unity
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotationSpeed = 5f;

    private int currentWaypointIndex = 0;

    void Update()
    {
        if (currentWaypointIndex >= waypoints.Length)
            return;

        Transform target = waypoints[currentWaypointIndex];

        // Retningen mod n�ste waypoint
        Vector2 direction = (target.position - transform.position).normalized;

        // Flyt fjenden mod waypoint
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

        // Drej mod waypoint (valgfri � ser p�nere ud hvis bilen roterer)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Hvis vi er t�t nok p� waypoint, g� videre til det n�ste
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance < 0.2f)
        {
            currentWaypointIndex++;
        }
    }
}
