using UnityEngine;

public class Jaeger : MonoBehaviour
{
    readonly float eingabeFaktor = 15;

    void Update()
    {
        float xEingabe = Input.GetAxis("Horizontal");
        float zEingabe = Input.GetAxis("Vertical");

        float xNeu = transform.position.x + xEingabe * eingabeFaktor * Time.deltaTime;
        float zNeu = transform.position.z + zEingabe * eingabeFaktor * Time.deltaTime;
        transform.position = new Vector3(xNeu, transform.position.y, zNeu);
        Pruefen(gameObject);
    }

    public void Pruefen(GameObject go)
    {
        if (go.transform.position.y < 0)
            go.transform.position += Vector3.up * 50;

        if (go.transform.position.x < 0)
            go.transform.position = new Vector3(
                0,
                go.transform.position.y,
                go.transform.position.z
            );
        else if (go.transform.position.x > 1000)
            go.transform.position = new Vector3(
                1000,
                go.transform.position.y,
                go.transform.position.z
            );

        if (go.transform.position.z < 0)
            go.transform.position = new Vector3(
                go.transform.position.x,
                go.transform.position.y,
                0
            );
        else if (go.transform.position.x > 1000)
            go.transform.position = new Vector3(
                go.transform.position.x,
                go.transform.position.y,
                1000
            );

    }
}
