using UnityEngine;

public class LightManager : MonoBehaviour {
    public Color[] lightColors;
    public float pulseRate = 1.0f;
    public static Color currentColor;
    public bool smoothColorShift;
    public float smoothShiftRate = 5.0f;

    private Color targetColor;
    private int colorID;
    private float lastTimeChanged;

    private void Start() {
        if (pulseRate == 0.0f)
        {
            pulseRate = 1.0f;
        }
        lastTimeChanged = Time.time;
        targetColor = Color.yellow;
    }

    private void Update() {
        if (Time.time - lastTimeChanged > pulseRate)
        {
            ChangeLights();
        }

        if (smoothColorShift)
        {
            currentColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * smoothShiftRate);
        }
    }

    private void ChangeLights() {
        lastTimeChanged = Time.time;
        if (lightColors.Length > 0)
        {
            var nextColor = Random.Range(0, lightColors.Length - 1);
            if (nextColor == colorID)
            {
                nextColor++;
            }
            colorID = nextColor;
            if (!smoothColorShift)
            {
                currentColor = lightColors[colorID];
            }
            else
            {
                targetColor = lightColors[colorID];
            }
        }
    }
}