using UnityEngine;

public class Ziel : MonoBehaviour
{
    public GameObject jaeger;
    Jaeger jaegerKlasse;

    public GameObject abwehrPrefab;
    bool nachladen = false;

    void Start()
    {
        transform.position = new Vector3(Random.Range(20, 980), 50, Random.Range(20, 980));
        jaegerKlasse = jaeger.GetComponent<Jaeger>();
    }

    void Update()
    {
        Vector3 abstand = jaeger.transform.position - transform.position;
        if (!nachladen && abstand.magnitude < 10)
        {
            GameObject abwehr = (GameObject)Instantiate(
                abwehrPrefab,
                transform.position,
                Quaternion.identity
            );
            abwehr.GetComponent<Rigidbody>().AddForce(100 * abstand);
            nachladen = true;
            Invoke(nameof(NachladenBeendet), 1);
        }
        jaegerKlasse.Pruefen(gameObject);
    }

    void NachladenBeendet()
    {
        nachladen = false;
    }
}
