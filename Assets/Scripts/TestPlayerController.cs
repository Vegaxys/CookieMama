using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour{

    public Transform _camera;
    public Rigidbody rigid;
    public GameObject testBall;

    public float speed, fallMultiplier, jumpForce, distanceToGround;

    public bool hasJump;

    private void Update() {
        Mouvement();
        Jump();
        Interaction();
    }

    void Mouvement() {
        float xx = Input.GetAxis("Horizontal");
        float zz = Input.GetAxis("Vertical");

        Vector3 translate = new Vector3(xx, 0, zz);
        transform.Translate(translate * speed * Time.deltaTime);

       // transform.GetChild(0).position = new Vector3(0, 2 * (value / 100), 0);
    }
    void Jump() {
        if (rigid.velocity.y < 0) {
            rigid.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        if (Input.GetButtonDown("Jump") && hasJump == false && IsGrounded()) {
            hasJump = true;
            rigid.AddForce(transform.up * jumpForce, ForceMode.Acceleration);
        }
        if (Input.GetButtonUp("Jump") && hasJump == true) {
            hasJump = false;
        }
    }
    private bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
    }
    private void Interaction() {
        if (Input.GetButtonDown("Fire1")) {
            RaycastHit hit;
            Ray ray = _camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
                Debug.DrawLine(_camera.position, hit.point, Color.red);
                print(hit.collider.tag);
                if (hit.collider.CompareTag("Interactable")) {
                    if(hit.collider.GetComponent<Interaction>() != null) {
                        hit.collider.GetComponent<Interaction>().Switch();
                    } else {
                        hit.collider.GetComponentInChildren<Interaction>().Switch();
                    }
                } else {
                    FireBall();
                }
            }
        }
    }

    //****************************** Tests **********************************

    private void FireBall() {
        GameObject ball = Instantiate(testBall, _camera.position + _camera.forward, _camera.rotation);
        ball.GetComponent<Rigidbody>().AddForce(_camera.forward * 20, ForceMode.Impulse);
        Destroy(ball, 5);
    }
}
