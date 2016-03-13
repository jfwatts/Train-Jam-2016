using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InstructionScreen : MonoBehaviour {
    public GameObject header;
    public float headerWavelength;
    public float headerOffset;
    public GameObject headerShadow;

    public GameObject[] instructionText;
    public float instructionTextWavelength;

    void Start () {
        StartCoroutine(Hover(header.transform, headerWavelength, headerOffset));
        StartCoroutine(Hover(headerShadow.transform, headerWavelength, headerOffset));

        for (int i = 0; i < instructionText.Length; i++)
        {
            StartCoroutine(Hover(instructionText[i].transform, instructionTextWavelength, i));
        }
    }

    private void Update() {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    private IEnumerator Hover(Transform tr, float waveStr, float offSet) {
        while (true) 
        {
            var pos = tr.position;
            pos.y += Mathf.Sin(Time.time + offSet) * waveStr;
            tr.position = pos;
            yield return null;
        }
    }
}