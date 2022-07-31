using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    public bool drag = true;
    private Vector3 mOffset;
    private float mZCoord;
    public void OnMouseDown(){
        if(drag==true){
        mZCoord= Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset= gameObject.transform.position- GetMouseWorldPos();
        }
    }
    public Vector3 GetMouseWorldPos(){
        if(drag==true){
        Vector3 mousePoint= Input.mousePosition;

        mousePoint.z=mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
        }
        else{
            return new Vector3(0,0,0);
        }
    }
   public void OnMouseDrag(){
    if(drag==true){
            transform.position= GetMouseWorldPos() + mOffset;
        }

   }

}

/* using UnityEngine;

public class DragDrop : MonoBehaviour {

    private GameObject selectedObject;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {

            if(selectedObject == null) {
                RaycastHit hit = CastRay();

                if(hit.collider != null) {
                    if (!hit.collider.CompareTag("drag")) {
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            } else {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);

                selectedObject = null;
                Cursor.visible = true;

            }
        }

        if(selectedObject != null) {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);

        }
    }

    private RaycastHit CastRay() {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
} */

