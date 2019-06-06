using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeMouvement
{
    TRANSLATE,
    ROTATION
}

public class Interaction : MonoBehaviour{
    [SerializeField] TypeMouvement typeMouvement;
    [SerializeField] Vector3 v_close;
    [SerializeField] Vector3 v_open;

    [SerializeField] AnimationCurve curve;

    private float lerpValue = 1, t = 0;

    public void Switch() {
        StopAllCoroutines();
        StartCoroutine(SwitchState());
    }

    private IEnumerator SwitchState() {
        lerpValue *= -1;
        if (lerpValue == 1) {
            float t = 0;
            while (t < 1) {
                t += Time.deltaTime;
                switch (typeMouvement) {
                    case TypeMouvement.TRANSLATE:
                        transform.localPosition = Vector3.Lerp(v_open, v_close, curve.Evaluate(t));
                        break;
                    case TypeMouvement.ROTATION:
                        transform.localRotation = Quaternion.Lerp(Quaternion.Euler(v_open), Quaternion.Euler(v_close), curve.Evaluate(t));
                        break;
                }
                yield return null;
            }
        }
        if (lerpValue == -1) {
            float t = 0;
            while (t < 1) {
                t += Time.deltaTime;
                switch (typeMouvement) {
                    case TypeMouvement.TRANSLATE:
                        transform.localPosition = Vector3.Lerp(v_close, v_open, curve.Evaluate(t));
                        break;
                    case TypeMouvement.ROTATION:
                        transform.localRotation = Quaternion.Lerp(Quaternion.Euler(v_close), Quaternion.Euler(v_open), curve.Evaluate(t));
                        break;
                }
                yield return null;
            }
        }
    }

}
