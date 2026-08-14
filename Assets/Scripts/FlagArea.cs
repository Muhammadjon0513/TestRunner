using UnityEngine;

public class FlagArea : MonoBehaviour
{
    [Header("Flag Area Settings")]
    public int requiredWealthToPass = 10; // Shu bayroqdan (zinadan) o'tish uchun qancha boylik kerakligi
    
    private bool _isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isTriggered) return;

        if (other.CompareTag("Player"))
        {
            PlayerStatus status = other.GetComponentInParent<PlayerStatus>();
            if (status != null)
            {
                // Agar qahramonda yetarli boylik bo'lsa
                if (status.currentWealth >= requiredWealthToPass)
                {
                    status.AddWealth(-requiredWealthToPass); // Boylikni olib qo'yamiz va u yurishda davom etadi
                    _isTriggered = true;
                }
                else
                {
                    // Pul tugadi, o'yin shu yerda "Yutuq" bilan yakunlanadi
                    if (GameManager.Instance != null)
                    {
                        GameManager.Instance.LevelComplete();
                    }
                }
            }
        }
    }
}
