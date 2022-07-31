using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAround : MonoBehaviour
{
    public Vector2 turingVec;
    [SerializeField] public float sentiv = 1;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Wiederändern bei Cam Modes
    }

    // Update is called once per frame
    void Update()
    {
        LookAround();

    }

    private void LookAround()
    {
        turingVec.x += Input.GetAxis("Mouse X");
        turingVec.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turingVec.y, turingVec.x, 0);
    }
}
