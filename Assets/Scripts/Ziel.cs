using UnityEngine;

public class Ziel : MonoBehaviour
{
    public GameObject jaeger;
    Jaeger jaegerKlasse;

    void Start()
    {
        transform.position = new Vector3(Random.Range(20, 980), 50, Random.Range(20, 980));
        jaegerKlasse = jaeger.GetComponent<Jaeger>();
    }

    void Update()
    {
        jaegerKlasse.Pruefen(gameObject);
    }
}
