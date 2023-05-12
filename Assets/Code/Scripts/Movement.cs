using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    public Vector3 movPoint;
    Vector2 mov;
    // Start is called before the first frame update
    void Start()
    {
        movPoint = transform.position;
    }

    void Update()
    {
        bool isMoving = Vector3.Distance(transform.position, movPoint) > 0.0f;
        mov = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (mov != Vector2.zero && !isMoving)
        {
            movPoint = new Vector3(
                movPoint.x + mov.x,
                movPoint.y,
                movPoint.z + mov.y
                );
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, movPoint, speed * Time.deltaTime);
        }
    }
}
