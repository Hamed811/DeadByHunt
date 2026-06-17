using UnityEngine;
using TMPro;

public class MapManager : MonoBehaviour
{
    public static int selectedMap = 1;

    public TMP_Text selectedMapText;

    private void Start()
    {
        selectedMapText.text = "Map 1 Selected";
    }

    public void SelectMap1()
    {
        selectedMap = 1;
        selectedMapText.text = "Map 1 Selected";
    }

    public void SelectMap2()
    {
        selectedMap = 2;
        selectedMapText.text = "Map 2 Selected";
    }

    public void SelectMap3()
    {
        selectedMap = 3;
        selectedMapText.text = "Map 3 Selected";
    }
}