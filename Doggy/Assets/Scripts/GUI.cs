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
        health.SetText(GameManager.instancia.health.ToString());
        redDiamond.SetText(GameManager.instancia.redJewels.ToString());
        blueDiamond.SetText(GameManager.instancia.blueJewels.ToString());
        level.SetText("Nivel: "+ GameManager.instancia.level.ToString());
        time.SetText("Tiempo: " + GameManager.instancia.time.ToString());
        coins.SetText(GameManager.instancia.money.ToString());

    }

}
