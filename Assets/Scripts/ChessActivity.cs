using UnityEngine;

public class ChessActivity : MonoBehaviour
{
public GameObject chessActivity;

private void Start()
{
    if (chessActivity != null) chessActivity.SetActive(false);  // Ensure chess activity is hidden at start
}

private void TutorialCompleted()
{
    if (chessActivity != null) chessActivity.SetActive(true);   //  Show chess activity when tutorial is completed
}
}
