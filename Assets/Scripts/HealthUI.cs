using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    Health healthScript;
    [SerializeField]
    Image healthbar;
    [SerializeField]
    GameObject myCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        healthScript = GetComponentInParent<Health>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (healthScript != null)
        {
            healthbar.rectTransform.localScale = new Vector3(healthScript.GetCurrentHealth() / healthScript.GetMaxHealth(), 1, 1);
            transform.LookAt(Camera.main.transform.position);
        }
    }

    public void TurnOnUI()
    {
        myCanvas.SetActive(true);
    }
    
    public void TurnOffUI()
    {
       myCanvas.SetActive(false);
    }
}
