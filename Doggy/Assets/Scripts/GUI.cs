using UnityEngine;
using TMPro;

public class GUI : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI level;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI blueDiamond;
    public TextMeshProUGUI redDiamond;
    public TextMeshProUGUI health;
    public string timeText;
    public string levelText;
    public string coinsText;
    public string blueDiamondText;
    public string redDiamondText;
    public string healthText;

    // Start is called before the first frame update
    void Start()
    {
        time = time.GetComponent<TextMeshProUGUI>();
        level = level.GetComponent<TextMeshProUGUI>();
        coins = coins.GetComponent<TextMeshProUGUI>();
        blueDiamond = blueDiamond.GetComponent<TextMeshProUGUI>();
        redDiamond = redDiamond.GetComponent<TextMeshProUGUI>();
        health = health.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        time.SetText(timeText);
        level.SetText(levelText);
        coins.SetText(coinsText);
        blueDiamond.SetText(blueDiamondText);
        redDiamond.SetText(redDiamondText);
        health.SetText(healthText);
    }
}
