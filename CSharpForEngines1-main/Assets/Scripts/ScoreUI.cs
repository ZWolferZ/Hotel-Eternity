using UnityEngine;

// Score system (Not Used)

public class ScoreUI : MonoBehaviour
{
    public ScoreSystem scoreSystem;
    public TMPro.TextMeshProUGUI uiLabel;

    private void Update()
    {

        uiLabel.text = "Score: " + scoreSystem.score;
    }
}
