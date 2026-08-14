using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("Wealth Settings")]
    public int currentWealth = 0;
    public int maxWealth = 100;

    [Header("Wealth Thresholds")]
    public int decentThreshold = 30;
    public int richThreshold = 60;
    public int millionaireThreshold = 90;

    [Header("Visual Models (Drag & Drop)")]
    public GameObject hoboModel;
    public GameObject decentModel;
    public GameObject richModel;
    public GameObject millionaireModel;

    [Header("Effects")]
    public ParticleSystem moneyCollectEffect;
    public ParticleSystem alcoholCollectEffect;
    
    // UI uchun event
    public System.Action<int> OnWealthChanged;

    private void Start()
    {
        UpdateVisuals();
    }

    public void AddWealth(int amount)
    {
        currentWealth += amount;
        
        // Boylik 0 dan kamayib ketsa ham, juda pastga tushib ketmasligi uchun chegara
        currentWealth = Mathf.Clamp(currentWealth, -10, maxWealth); 
        
        // Zarrachalar (Particle) effektlarini o'ynatish
        if (amount > 0 && moneyCollectEffect != null)
        {
            moneyCollectEffect.Play();
        }
        else if (amount < 0 && alcoholCollectEffect != null)
        {
            alcoholCollectEffect.Play();
        }

        UpdateVisuals();
        OnWealthChanged?.Invoke(currentWealth);
    }

    private void UpdateVisuals()
    {
        // Dastlab barcha modellarni yashiramiz
        if (hoboModel != null) hoboModel.SetActive(false);
        if (decentModel != null) decentModel.SetActive(false);
        if (richModel != null) richModel.SetActive(false);
        if (millionaireModel != null) millionaireModel.SetActive(false);

        // Hozirgi boylik darajasiga qarab tegishli modelni yoqamiz
        if (currentWealth >= millionaireThreshold)
        {
            if (millionaireModel != null) millionaireModel.SetActive(true);
        }
        else if (currentWealth >= richThreshold)
        {
            if (richModel != null) richModel.SetActive(true);
        }
        else if (currentWealth >= decentThreshold)
        {
            if (decentModel != null) decentModel.SetActive(true);
        }
        else
        {
            if (hoboModel != null) hoboModel.SetActive(true);
        }
    }
}
