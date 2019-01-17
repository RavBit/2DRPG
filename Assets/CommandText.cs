using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CommandText : MonoBehaviour {

    private Text textBox;

    private void Awake()
    {
        textBox = GetComponentInChildren<Text>();
    }
    public void UpdateText(string text)
    {
        textBox.text = text;
    }

}
