
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float speedMultiplier = 1.0f;
    public Vector2 initialDirection;
    public LayerMask obstacleLayer;



    public new Rigidbody2D rigidbody { get; private set; }


    public Vector2 direction { get; private set; }
    public Vector2 nextDirection { get; private set; }
    public Vector3 startingPosition { get; private set; }



    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.startingPosition = this.transform.position;

    }
    private void Start()
    {
        ResetState();
    }
    public void ResetState()
    {
        this.speedMultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = this.Vector2.zero;
        this.transform.position = this.startingPosition;
        this.rigidbody.isKinematic = false;
        this.enabled = true;

    }

    private void FixedUpdate()
    {
        Vector2 position = this.rigitbody.position;
        Vector2 translation = this.direction * this.speed * this.speedMultiplier * Time.fixedDeltaTime;
        this.rigidbody.MovePosition(position + translation);

      
    }




}
