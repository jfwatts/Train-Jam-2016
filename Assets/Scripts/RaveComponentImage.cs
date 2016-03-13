using UnityEngine;
using UnityEngine.UI;
//using System.Collections;

public class RaveComponentImage : MonoBehaviour {
    private Image aura;

    private void Start() {
        aura = this.gameObject.GetComponent<Image>();

    }

    private void Update() {
        aura.color = LightManager.currentColor;
    }
}