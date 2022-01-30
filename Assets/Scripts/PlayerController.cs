using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    float rot;

    CharacterController characterController;

    public GameObject cam;

    public Animator anim;

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

        if (vertical > 0 || horizontal > 0)
            anim.SetBool("Walking", true);
        else
        {
            anim.SetBool("Walking", false);
        }
    }

    void UpdateCamera()
    {
        cam.transform.eulerAngles = transform.eulerAngles;
        cam.transform.position = new Vector3(transform.position.x, cam.transform.position.y, transform.position.z);
    }

    private void LateUpdate()
    {
        UpdateCamera();
    }
}
