using UnityEngine;
using TMPro; // TextMeshPro kutuphanesi

public class PointDisplay : MonoBehaviour
{
    public Movement player; // Player scriptine referans
    public GameObject  pointsText; // TextMeshPro UI elementi

    void Start()
    {
        // Player scriptine erisim (eger atanmadiysa sahnede arayarak bulur)
        if (player == null)
        {
            player = FindObjectOfType<Movement>();
        }

        // TextMeshPro referansinin atanip atanmadigini kontrol et
        if (pointsText == null)
        {
            pointsText = GameObject.FindGameObjectWithTag("Text");
            Debug.LogError("TextMeshPro referansi atandi!");
        }
        
    }

    void Update()
    {
        if (player != null && pointsText != null)
        {
            // Playerin points degerini TextMeshProya yazdir
            pointsText.GetComponent<TextMeshProUGUI>().SetText("Points: " + player.point);
        }
    }
}
