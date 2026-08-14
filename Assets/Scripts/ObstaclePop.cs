using UnityEngine;
using DG.Tweening;

public class ObstaclePop : MonoBehaviour
{
    [Header("Pop Settings")]
    public float popHeight = 2f;
    public float popDuration = 0.5f;
    public float triggerDistance = 15f; // Qahramon qancha masofaga kelganda to'siq chiqadi
    
    private bool _isTriggered = false;
    private Transform _playerTransform;
    private float _originalY;

    private void Start()
    {
        _originalY = transform.position.y;
        
        // Boshida yashirin turishi uchun yerni tagiga tushiramiz
        transform.position = new Vector3(transform.position.x, _originalY - popHeight, transform.position.z);
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerTransform = player.transform;
        }
    }

    private void Update()
    {
        if (_isTriggered || _playerTransform == null) return;

        // Qahramon Z o'qida to'siqqa qanchalik yaqinlashganini tekshiramiz
        float distanceZ = transform.position.z - _playerTransform.position.z;
        
        if (distanceZ > 0 && distanceZ <= triggerDistance)
        {
            TriggerPop();
        }
    }

    private void TriggerPop()
    {
        _isTriggered = true;
        
        // DOTween orqali to'siqni yerdan sakratib (OutBack) chiqaramiz
        transform.DOMoveY(_originalY, popDuration).SetEase(Ease.OutBack);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Qahramon to'siqqa urilganda jazolanadi
        if (other.CompareTag("Player"))
        {
            PlayerStatus status = other.GetComponentInParent<PlayerStatus>();
            if (status != null)
            {
                status.AddWealth(-20); // Katta zarar (kolliziya)
                
                // Urilgandan so'ng qayta jazolamasligi uchun Colliderni o'chirib qo'yamiz
                Collider col = GetComponent<Collider>();
                if (col != null) col.enabled = false;
            }
        }
    }
}
