using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 5f;
    public float swerveSpeed = 5f;
    public float maxHorizontalLimit = 4.5f;

    private float _lastFrameFingerPositionX;
    private float _moveFactorX;
    public bool isPlaying = false;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (!isPlaying) return;

        // Oldinga yugurish
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Boshqaruv (Swerve)
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
            _lastFrameFingerPositionX = Input.mousePosition.x;

            float swerveAmount = (_moveFactorX / Screen.width) * swerveSpeed * 100f * Time.deltaTime;
            float targetX = transform.position.x + swerveAmount;
            
            // Yo'ldan tushib ketmaslik uchun cheklash
            targetX = Mathf.Clamp(targetX, -maxHorizontalLimit, maxHorizontalLimit);
            
            transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        }
    }

    public void StartGame()
    {
        isPlaying = true;
        if (_animator != null) _animator.SetTrigger("Run");
    }

    public void EndGame()
    {
        isPlaying = false;
        if (_animator != null) _animator.SetTrigger("Idle");
    }
}
