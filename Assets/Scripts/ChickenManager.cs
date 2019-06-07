using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenManager : MonoBehaviour{
    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.localScale.x * 10, transform.localScale.y * 10, transform.localScale.z * 10));
    }
    public Vector3 FindNewPos() {
        Vector3 newPos = new Vector3(
            transform.position.x + Random.Range(-transform.localScale.x * 5, transform.localScale.x * 5),
            0,
            transform.position.z + Random.Range(-transform.localScale.z * 5, transform.localScale.z * 5));
        return newPos;
    }
}
