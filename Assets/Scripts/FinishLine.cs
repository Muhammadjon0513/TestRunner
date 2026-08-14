using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private bool _isFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_isFinished) return;

        // Qahramon Finish (Marra) chizig'idan o'tsa
        if (other.CompareTag("Player"))
        {
            _isFinished = true;
            
            // Qahramon endi faqat to'g'riga (bayroqlar zonasiga) yurishi uchun boshqaruvni o'chiramiz
            PlayerController controller = other.GetComponentInParent<PlayerController>();
            if (controller != null)
            {
                controller.canSwerve = false;
            }
            
            // Agar Marrada qo'shimcha Confetti effekti bo'lsa, shu yerda yoqiladi
            // GetComponent<ParticleSystem>()?.Play();
        }
    }
}
