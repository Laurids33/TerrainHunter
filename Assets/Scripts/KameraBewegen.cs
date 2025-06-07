using UnityEngine;
using UnityEngine.UI;

public class KameraBewegen : MonoBehaviour
{
    Vector3 abstandStart;
    Vector3 abstand;
    public GameObject jaeger;
    public Slider zoomSlider;

    void Start()
    {
        abstandStart = jaeger.transform.position - transform.position;
        abstand = abstandStart;
    }

    void Update()
    {
        transform.position = jaeger.transform.position - abstand;
    }

    public void WertGewechselt()
    {
        abstand = abstandStart / (zoomSlider.value * 10);
    }
}
