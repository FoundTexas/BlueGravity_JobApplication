using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb2d;
    Vector2 mov;

    Camera cam;

    Animator anim;
    bool canmove;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
    }
    private void Update()
    {
        canmove = !Woredrobe.OnWardrobe();
    }
    private void FixedUpdate()
    {
        mov = (canmove) ? new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) : Vector2.zero;

        rb2d.velocity = (mov * speed * Time.deltaTime);

        float minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).x;
        float maxWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 10)).x;
        float minHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).y;
        float maxHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 10)).y;

        /*rb2d.position = new Vector3(
            Mathf.Clamp(rb2d.position.x, minWidth + 1, maxWidth - 1),
            Mathf.Clamp(rb2d.position.y, minHeight, maxHeight)
        );*/

        anim.SetFloat("mag", rb2d.velocity.magnitude);

        if (mov != Vector2.zero)
        {
            anim.SetFloat("X", mov.x);
            anim.SetFloat("Y", mov.y);
        }
    }
}
