using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    float rot;

    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical") * speed;
        float horizontal = Input.GetAxis("Horizontal") * turnSpeed;

        rot += horizontal;

        transform.eulerAngles = new Vector3(0f, rot, 0f);
        Vector3 moveDirection = transform.TransformDirection(Vector3.forward);

        characterController.Move((moveDirection * vertical) * Time.deltaTime);
    }
}
