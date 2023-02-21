using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{

    public Rigidbody2D rigidBody { get; private set; }
    AddPointEvent addPointEvent = new AddPointEvent();

    public float speed = 600f;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ResetPosition();
        EventManager.AddEventInvoker(this);
    }
    public void ResetPosition()
    {
        this.transform.position = Vector2.zero;
        this.rigidBody.velocity = Vector2.zero;
        Invoke(nameof(SetRandomTrajectory), 1f);

    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        rigidBody.AddForce(force.normalized * speed);
    }
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Brick brick = gameObject.AddComponent<Brick>();
        if (collision.gameObject.name == "Brick")
        {
            addPointEvent.Invoke(brick.pointUnit);
        }
    }
    public void AddedEventListener(UnityAction<int> listener)
    {
        addPointEvent.AddListener(listener);
    }
    

}
