using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Pointer : MonoBehaviour{

    [SerializeField] float length = 5;
    [SerializeField] GameObject dot;
    [SerializeField] VRInputModule inputModule;
    private LineRenderer lineRenderer;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update() {
        UpdateLine();
    }
    private void UpdateLine() {
        //distance
        PointerEventData data = inputModule.GetData();
        float targetLength = data.pointerCurrentRaycast.distance == 0 ? length : data.pointerCurrentRaycast.distance;
        //raycast
        RaycastHit hit = CreateRaycast(targetLength);

        //default
        Vector3 endPosition = transform.position + (transform.forward * targetLength);
         
        //Hit
        if (hit.collider != null) {
            endPosition = hit.point;
        }
        dot.transform.position = endPosition;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPosition);
    }
    private RaycastHit CreateRaycast(float _length) {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, length);
        return hit;
    } 
}
