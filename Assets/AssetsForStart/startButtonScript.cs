using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    public Canvas startCanvas; // Reference to the current canvas
    public Canvas rulesCanvas; // Reference to the canvas you want to show next

    // Function called by Unity's onClick event
    public void OnStartButtonClick()
    {
        // Call the SwitchCanvas method with parameters
        SwitchCanvas();
    }

    // Wrapper function to switch between canvases
    public void SwitchCanvas()
    {
        // Hide the current canvas
        startCanvas.gameObject.SetActive(false);

        // Show the next canvas
        rulesCanvas.gameObject.SetActive(true);
    }
}
