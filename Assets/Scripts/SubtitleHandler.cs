using UnityEngine;
using TMPro;

public class SubtitleHandler : MonoBehaviour
{
    [SerializeField] string[] subtitiles;
    [SerializeField] TMP_Text subtitleText;

    int currentSubtitleIndex = 0;

    public void ShowNextSubtitle()
    {
        currentSubtitleIndex++;
        subtitleText.text = subtitiles[currentSubtitleIndex]; 
    }
}
