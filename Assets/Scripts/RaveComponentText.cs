using UnityEngine;
using UnityEngine.UI;

public class RaveComponentText : MonoBehaviour {
    private Text text;

    private void Start () {
        text = this.gameObject.GetComponent<Text>();
    }

    private void Update () {
        text.color = LightManager.currentColor;
    }
}