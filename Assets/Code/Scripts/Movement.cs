using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    Transform playerModel;
    CharacterController playerController;
    Vector2 mov;
    // Start is called before the first frame update
    void Start()
    {
        playerModel = transform.Find("PlayerModel").transform;
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(Woredrobe.OnWardrobe())
            return;
        
        mov = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (mov != Vector2.zero)
        {
            SetTargetAngle();
        }

        playerController.Move(new Vector3(mov.x, 0, mov.y) * speed * Time.deltaTime);
    }

    public void SetTargetAngle()
    {
        Vector3 temppos = playerModel.position;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(temppos.x + mov.x, temppos.y, temppos.z + mov.y) - temppos, Vector3.up);
        Quaternion newRotation = Quaternion.RotateTowards(playerModel.rotation, targetRotation, 360);
        playerModel.rotation = newRotation;
    }
}
