using TMPro;
using UnityEngine;



public class Scoring : MonoBehaviour
{
    public static int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Change from UnityEngine.UI.Text to TMPro.TextMeshProUGUI
        GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
