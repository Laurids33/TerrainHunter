using UnityEngine;

public class Abwehr : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(SelbstZerstoerung), 10);
    }

    void SelbstZerstoerung()
    {
        Destroy(gameObject);
    }
}
