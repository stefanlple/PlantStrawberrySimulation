using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Vector2 turingVec;

    Rigidbody Rigid;
    [SerializeField] float MoveSpeed;
    [SerializeField] GameObject Head;
    private void Start()
    {
        Rigid = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;


    }

    void Update()
    {
        turingVec.y += Input.GetAxis("Mouse Y");
        Head.transform.localRotation = Quaternion.Euler(-turingVec.y, Head.transform.localRotation.x, 0);

        Rigid.MoveRotation(Rigid.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") , 0)));
        Rigid.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * MoveSpeed) + (transform.right * Input.GetAxis("Horizontal") * MoveSpeed));
     
    }
   
   
}
