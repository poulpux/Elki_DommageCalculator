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
        inputField.onValidateInput += ValidateDecimalInput;
    }

    void Update()
    {
        if (inputField.text.Length == 0)
        {
            textMesh.text = "";
            return;
        }

        // Try to parse the input text to a float
        if (float.TryParse(inputField.text.Replace(',', '.'), out float number))
        {
            textMesh.text = number.ToString();
        }
        else
        {
            Debug.LogWarning("Input string was not in a correct format.");
            textMesh.text = "Invalid input";
        }
    }

    private char ValidateDecimalInput(string text, int charIndex, char addedChar)
    {
        // Allow digits
        if (char.IsDigit(addedChar))
        {
            return addedChar;
        }

        // Allow one comma or point for decimal separator
        if ((addedChar == ',' || addedChar == '.') && !text.Contains(",") && !text.Contains("."))
        {
            return addedChar;
        }

        // Otherwise, reject the input
        return '\0';
    }
}
