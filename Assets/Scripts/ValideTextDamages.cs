using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    TextMeshProUGUI result;
    [SerializeField] TMP_InputField inputField;
    void Start()
    {
        result = GetComponent<TextMeshProUGUI>();
        // Set up the validation callback for the input field
        inputField.onValidateInput += ValidateDecimalInput;

        // Set up a listener for when the input field text changes
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    // This method is called whenever the input field text changes
    private void OnInputValueChanged(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            result.text = "";
            return;
        }

        // Replace comma with dot to handle decimal values consistently
        string formattedInput = input.Replace(',', '.');

        // Try to parse the input text to a float using InvariantCulture to handle the dot as decimal separator
        if (float.TryParse(formattedInput, NumberStyles.Float, CultureInfo.InvariantCulture, out float number))
        {
            // Convert the float back to a string and display it
            result.text = number.ToString(CultureInfo.InvariantCulture);
        }
        else
        {
            Debug.LogWarning("Input string was not in a correct format.");
            result.text = "Invalid input";
        }
    }

    // This method is used to validate the input characters
    private char ValidateDecimalInput(string text, int charIndex, char addedChar)
    {
        // Allow digits
        if (char.IsDigit(addedChar))
        {
            return addedChar;
        }

        // Allow one comma or dot for decimal separator
        if ((addedChar == ',' || addedChar == '.') && !text.Contains(",") && !text.Contains("."))
        {
            return addedChar;
        }

        // Otherwise, reject the input
        return '\0';
    }
}
