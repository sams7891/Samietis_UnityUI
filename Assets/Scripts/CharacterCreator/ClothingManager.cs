using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ClothingManager : MonoBehaviour
{
    public TMP_Dropdown genderDropdown;

    public Toggle hatToggle;
    public Toggle shirtToggle;
    public Toggle pantsToggle;
    public Toggle bootsToggle;
    public Toggle glovesToggle;
    public Toggle amuletToggle;

    [Header("UI Option Images")]
    public Image option1;
    public Image option2;
    public Image option3;

    [Header("Sprites Male")]
    public Sprite[] maleHats;
    public Sprite[] maleShirts;
    public Sprite[] malePants;
    public Sprite[] maleBoots;
    public Sprite[] maleGloves;
    public Sprite[] maleAmulets;

    [Header("Sprites Female")]
    public Sprite[] femaleHats;
    public Sprite[] femaleShirts;
    public Sprite[] femalePants;
    public Sprite[] femaleBoots;
    public Sprite[] femaleGloves;
    public Sprite[] femaleAmulets;

    // 🔹 called by toggles or dropdown
    public void UpdateOptions()
    {
        int gender = genderDropdown.value; // 0 = male, 1 = female
        Sprite[] selectedSet = null;

        if (gender == 0) // Male
        {
            if (hatToggle.isOn) selectedSet = maleHats;
            else if (shirtToggle.isOn) selectedSet = maleShirts;
            else if (pantsToggle.isOn) selectedSet = malePants;
            else if (bootsToggle.isOn) selectedSet = maleBoots;
            else if (glovesToggle.isOn) selectedSet = maleGloves;
            else if (amuletToggle.isOn) selectedSet = maleAmulets;
        }
        else // Female
        {
            if (hatToggle.isOn) selectedSet = femaleHats;
            else if (shirtToggle.isOn) selectedSet = femaleShirts;
            else if (pantsToggle.isOn) selectedSet = femalePants;
            else if (bootsToggle.isOn) selectedSet = femaleBoots;
            else if (glovesToggle.isOn) selectedSet = femaleGloves;
            else if (amuletToggle.isOn) selectedSet = femaleAmulets;
        }

        if (selectedSet != null && selectedSet.Length >= 3)
        {
            option1.sprite = selectedSet[0];
            option2.sprite = selectedSet[1];
            option3.sprite = selectedSet[2];
        }
    }
}