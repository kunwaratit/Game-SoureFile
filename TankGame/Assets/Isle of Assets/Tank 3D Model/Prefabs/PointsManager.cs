using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public Text pointsText; // Reference to the UI Text for displaying points
    private int points;

    private void Start()
    {
        points = 0;
        UpdatePointsUI();
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        UpdatePointsUI();
    }

    private void UpdatePointsUI()
    {
        if (pointsText != null)
        {
            pointsText.text = "Points: " + points.ToString();
        }
    }
}

