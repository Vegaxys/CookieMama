using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(RandomAnimation(1));
    }

    private IEnumerator RandomAnimation(float random)
    {
        yield return new WaitForSeconds(random);
        float _random = Random.Range(2f, 5f);
        anim.SetTrigger("Change");
        StartCoroutine(RandomAnimation(_random));
    }
}
