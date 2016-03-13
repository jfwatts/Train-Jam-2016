using UnityEngine;

public class HotTubLights : MonoBehaviour {
    private SpriteRenderer sr;

    private void Start () {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update () {
        sr.color = LightManager.currentColor;
    }
}