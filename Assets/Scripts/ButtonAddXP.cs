using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class ButtonAddXP : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI LV, xpRemain, nameOfCharacter;
    [SerializeField] private CharacterXP character;

    private void Start()
    {
        inputField.onValidateInput += ValidateDecimalInput;
        nameOfCharacter.text = character.name;
        UpdateAll();
    }

    public void AddXP()
    {
        string input = inputField.text;
        if (string.IsNullOrEmpty(input))
        {
            inputField.text = "";
            return;
        }
        // Replace comma with dot to handle decimal values consistently
        string formattedInput = input.Replace(',', '.');
        // Try to parse the input text to a float using InvariantCulture to handle the dot as decimal separator
        if (int.TryParse(formattedInput, NumberStyles.Integer, CultureInfo.InvariantCulture, out int number))
        {
            PlayerPrefs.SetInt(character.name, number + PlayerPrefs.GetInt(character.name));
            UpdateAll();
        }
        else
        {
            Debug.LogWarning("Input string was not in a correct format.");
            inputField.text = "Invalid input";
        }
    }

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

    private void UpdateAll()
    {
        character.CalculateXPAndLV();
        LV.text = "Nb lv : " + character.nbLv.ToString();
        xpRemain.text = "Xp remain : " + character.nbXpToNextLv.ToString();
        inputField.text = ""; 
    }
}
