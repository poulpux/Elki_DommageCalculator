using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    [SerializeField] TMP_InputField inputField;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputField.text.Length == 0)
            return;
        int number = int.Parse(inputField.text);
        textMesh.text = number.ToString();
    }
}
