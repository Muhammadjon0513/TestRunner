using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour
{
    [Header("Gate Settings")]
    public int gateValue = 20; // Musbat bo'lsa daromad (Yashil darvoza), manfiy bo'lsa zarar (Qizil darvoza)
    public TextMeshPro textMesh;
    
    private bool _hasPassed = false;

    private void Start()
    {
        // Yozuvni avtomatik yangilash
        if (textMesh != null)
        {
            string sign = gateValue >= 0 ? "+" : "";
            textMesh.text = sign + gateValue.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_hasPassed) return;

        if (other.CompareTag("Player"))
        {
            PlayerStatus status = other.GetComponentInParent<PlayerStatus>();
            if (status != null)
            {
                status.AddWealth(gateValue);
                _hasPassed = true;
                
                // Darvozadan o'tganda vizual o'chib ketadi
                gameObject.SetActive(false);
            }
        }
    }
}
