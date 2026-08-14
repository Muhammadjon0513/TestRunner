using UnityEngine;

public enum PickupType
{
    Money,
    Alcohol
}

public class Pickup : MonoBehaviour
{
    [Header("Pickup Settings")]
    public PickupType type = PickupType.Money;
    public int valueAmount = 10;
    public float rotateSpeed = 100f;

    private void Update()
    {
        // Ob'ektni o'z o'qi atrofida aylanib turishi uchun
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Qahramonga tekkanda (Player tagiga ega bo'lishi kerak)
        if (other.CompareTag("Player"))
        {
            // PlayerStatus skriptini topamiz
            PlayerStatus status = other.GetComponentInParent<PlayerStatus>();
            if (status != null)
            {
                // Agar pul bo'lsa musbat, alkogol bo'lsa manfiy qiymat beramiz
                int finalAmount = (type == PickupType.Money) ? valueAmount : -valueAmount;
                status.AddWealth(finalAmount);
                
                // Olingan narsani sahnadan o'chiramiz
                Destroy(gameObject);
            }
        }
    }
}
