using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float jumpForce = 8f;
    public float gravity = 9.81f * 2f;

    // Declare events for obstacle hit and gummy passed.
    public delegate void ObstacleHitAction();
    public delegate void GummyPassedAction();

    public event ObstacleHitAction OnObstacleHit;
    public event GummyPassedAction OnGummyPassed;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        direction += gravity * Time.deltaTime * Vector3.down;

        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.GetButton("Jump"))
            {
                direction = Vector3.up * jumpForce;
            }
        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Trigger the obstacle hit event.
            if (OnObstacleHit != null)
            {
                OnObstacleHit();

            }
        }
        else if (other.CompareTag("Gummy"))
        {

            // Trigger the gummy passed event.
            if (OnGummyPassed != null)
            {
                OnGummyPassed();

                other.gameObject.SetActive(false);
            }
        }
    }
}





