using UnityEngine;

public class wizzardMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed

    private bool isMoving;
    private Vector3 targetPosition;
    private Camera wizzardCamera;

    private void Awake()
    {
        wizzardCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = wizzardCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Move to the clicked position
                MoveToPosition(hit.point);
            }
        }
    }

    private void MoveToPosition(Vector3 position)
    {
        targetPosition = position;
        isMoving = true;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 direction = targetPosition - transform.position;
            float distance = direction.magnitude;

            // Check if we have reached the target position
            if (distance <= 0.1f)
            {
                isMoving = false;
                return;
            }

            // Move towards the target position
            Vector3 movement = direction.normalized * moveSpeed * Time.fixedDeltaTime;
            transform.Translate(movement, Space.World);
        }
    }
}