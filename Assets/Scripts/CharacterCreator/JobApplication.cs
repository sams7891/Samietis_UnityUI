using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JobApplication : MonoBehaviour
{
    public TMP_Text text;
    public TMP_InputField nameInput;
    public TMP_InputField ageInput;
    public TMP_Dropdown dropDown;
    public TMP_Text txtArea;

    public void Check()
    {
        if (nameInput != null && ageInput != null)
            CreateJobApplication();
    }

    private void CreateJobApplication()
    {
        string name = nameInput.text;
        string bornDate = ageInput.text;
        int age;

        int.TryParse(bornDate, out age);
        age = System.DateTime.Now.Year - age;

        string description = "";

        switch (dropDown.options[dropDown.value].text)
        {
            case "Vīrietis":
                switch (Random.Range(0, 4))
                {
                    case 0:
                        description = "Šis LEGO vīrietis vienmēr ir gatavs jauniem piedzīvojumiem. Viņam patīk būvēt transportlīdzekļus un izpētīt apkārtējo pasauli.";
                        break;

                    case 1:
                        description = "Viņš strādā par inženieri LEGO pilsētā un palīdz veidot jaunas ēkas. Viņš vienmēr cenšas atrast labāko risinājumu.";
                        break;

                    case 2:
                        description = "Šis tēls aizraujas ar sportu un aktīvu dzīvesveidu. Viņam patīk trenēties un piedalīties sacensībās.";
                        break;

                    case 3:
                        description = "Viņš ir zinātnieks, kurš interesējas par jaunām tehnoloģijām un eksperimentiem.";
                        break;
                }
                break;

            case "Sieviete":
                switch (Random.Range(0, 4))
                {
                    case 0:
                        description = "Šī LEGO sieviete ir arhitekte, kurai patīk veidot skaistas un praktiskas ēkas.";
                        break;

                    case 1:
                        description = "Viņa ir pētniece, kas ar interesi izzina dabu un apkārtējo vidi.";
                        break;

                    case 2:
                        description = "Šis tēls nodarbojas ar mākslu un rada dažādus darbus no LEGO klucīšiem.";
                        break;

                    case 3:
                        description = "Viņa strādā par skolotāju un palīdz citiem apgūt jaunas prasmes.";
                        break;
                }
                break;
        }

        if (age != System.DateTime.Now.Year && name != "")
        {
            text.text = "Vārds: " + name +
                        "\nVecums: " + age;
        }
        else if (age == System.DateTime.Now.Year && name.Equals(""))
        {
            text.text = "Vārds: nav ievadīts" +
                        "\nVecums: nav ievadīts";
            txtArea.text = "Nav izveidots kamēr visi pārējie lauki nav aizpildīti";
        }
        else if (age == System.DateTime.Now.Year)
        {
            text.text = "Vārds: " + name +
                        "\nVecums: nav ievadīts";
            txtArea.text = "Nav izveidots kamēr visi pārējie lauki nav aizpildīti";

        }
        else
        {
            text.text = "Vārds: nav ievadīts" +
                        "\nVecums: " + age;
            txtArea.text = "Nav izveidots kamēr visi pārējie lauki nav aizpildīti";

        }
        txtArea.text = description;
    }
}