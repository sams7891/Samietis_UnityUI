using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpriteChanger : MonoBehaviour
{
    public TMP_Dropdown genderDropdown;

    public Toggle hatToggle;
    public Toggle shirtToggle;
    public Toggle pantsToggle;

    [Header("UI Option Images")]
    public Image option1;
    public Image option2;
    public Image option3;

    [Header("Male")]
    public Sprite[] maleHats;
    public Sprite[] maleShirts;
    public Sprite[] malePants;

    [Header("Female")]
    public Sprite[] femaleHats;
    public Sprite[] femaleShirts;
    public Sprite[] femalePants;

    private void Start()
    {
        // Optional: initialize once at start
        UpdateOptions();
    }

    // 🔹 This gets called by toggles
    public void OnToggleChanged(bool isOn)
    {
        if (!isOn) return; // Ignore when toggle is turned OFF
        UpdateOptions();
    }

    // 🔹 This gets called by dropdown
    public void OnGenderChanged(int index)
    {
        UpdateOptions();
    }

    public void UpdateOptions()
    {
        int gender = genderDropdown.value;
        Sprite[] selectedSet = null;

        if (gender == 0) // Male
        {
            if (hatToggle.isOn)
                selectedSet = maleHats;
            else if (shirtToggle.isOn)
                selectedSet = maleShirts;
            else if (pantsToggle.isOn)
                selectedSet = malePants;
        }
        else // Female
        {
            if (hatToggle.isOn)
                selectedSet = femaleHats;
            else if (shirtToggle.isOn)
                selectedSet = femaleShirts;
            else if (pantsToggle.isOn)
                selectedSet = femalePants;
        }

        if (selectedSet != null && selectedSet.Length >= 3)
        {
            option1.sprite = selectedSet[0];
            option2.sprite = selectedSet[1];
            option3.sprite = selectedSet[2];
        }
    }
}