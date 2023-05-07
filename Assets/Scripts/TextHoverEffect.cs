using UnityEngine;
using TMPro;

public class TextHoverEffect : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter()
    {
        textMeshPro.color = Color.red; // Set the text color to red when hovering over the text.
    }

    public void OnPointerExit()
    {
        textMeshPro.color = Color.white; // Set the text color back to white when the mouse leaves the text.
    }
}
