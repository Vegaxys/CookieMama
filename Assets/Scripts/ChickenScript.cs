using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour
{
    private Animator anim;
    public ChickenManager manager;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(RandomAnimation(1));
        StartCoroutine(MoveTo(manager.FindNewPos()));
    }
    IEnumerator MoveTo(Vector3 position) {
        while(Vector3.Distance(transform.position, position) > 2) {
            transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * 3);
            transform.LookAt(position);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            yield return null;
        }
        StartCoroutine(MoveTo(manager.FindNewPos()));
    }



    private IEnumerator RandomAnimation(float random)
    {
        yield return new WaitForSeconds(random);
        float _random = Random.Range(2f, 5f);
        anim.SetTrigger("Change");
        StartCoroutine(RandomAnimation(_random));
    }
}
