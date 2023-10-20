using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class DamageNumbers : MonoBehaviour
{

    public static DamageNumbers Instance;
    public GameObject prefab;
    public TextMeshProUGUI scoreKeep;
    public int totalDamage;
    private int oldTotalDamage;

    // Update is called once per frame
    private void Awake()
    {
        Instance = this;
        totalDamage = 0;
        oldTotalDamage = 0;
        scoreKeep.text = "Total Damage : 0";
    }

    private void Update()
    {
        
    }

    public void CreateText(Vector3 position, string text, Color color) {
        var popup = Instantiate(prefab, position, Quaternion.identity);
        var temp = popup.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        temp.text = text;
        temp.faceColor = color;

        Destroy(popup,1f);
    }

    private void FixedUpdate()
    {
        if (totalDamage != oldTotalDamage) {
            scoreKeep.text = "Total Damage : "+totalDamage;
            oldTotalDamage = totalDamage;
        }
    }

}
