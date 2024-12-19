using UnityEngine;

public class getscore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scoring.score++;
    }
}
