using UnityEngine;
using TMPro;
public class Jaeger : MonoBehaviour
{
    readonly float eingabeFaktor = 15;

    public GameObject explosionRot;
    int punkte = 0;
    public TextMeshProUGUI punkteAnzeige, infoAnzeige;

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ziel"))
        {
            Vector3 zielPos = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
            Instantiate(explosionRot, zielPos, Quaternion.identity);

            punkte++;
            punkteAnzeige.text = $"Punkte: {punkte}";
            if (punkte >= 10)
            {
                gameObject.SetActive(false);
                infoAnzeige.text = "Sie haben es geschafft";
            }
        }
    }
}
