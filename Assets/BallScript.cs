using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D myRigidbody;
    private Camera mainCamera;
    private bool isPausedCode = false;
    [SerializeField]
    private TrailRenderer trailRenderer;
    public ParticleSystem collisionParticle;
    public float maxInitialAngle = 0.67f;
    public float moveSpeed = 20f;
    public float speedIncrease = 1.1f;
    public float maxStartY = 4f;
    Vector2 direction = Vector2.left;
    //[SerializeField] private float speed = 5f;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        direction.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        myRigidbody.velocity = direction * moveSpeed;
        EmitParticle(32);
    }
    public void stopBall()
    {
        trailRenderer.enabled = false;
        Vector2 defaultPosition = new Vector2(0, 0);
        transform.position = defaultPosition;
        myRigidbody.velocity = Vector2.zero;
    }
    public void ResetBall()
    {
        // Reset vị trí của quả bóng
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(0, posY);
        transform.position = position;

        // Reset vận tốc của quả bóng
        direction.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        myRigidbody.velocity = direction * moveSpeed;

        // Reset trạng thái của trail renderer và cờ tạm dừng
        trailRenderer.enabled = true;
        isPausedCode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPausedCode) return; // Nếu đang tạm dừng, không thực hiện hành động

        //transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Kiểm tra xem quả bóng có ra ngoài màn hình không
        // Kiểm tra xem quả bóng có ra ngoài màn hình không
        if (transform.position.x >= 9f || transform.position.x <= -9f)
        {
            StartCoroutine(PauseAndResetBall(1f)); // Bắt đầu Coroutine để xử lý tạm dừng và reset
        }
    }
    private IEnumerator PauseAndResetBall(float duration)
    {
        isPausedCode = true; // Đặt cờ tạm dừng
        trailRenderer.enabled = false;
        yield return new WaitForSeconds(duration); // Chờ trong khoảng thời gian cho trước
        ResetBall(); // Reset quả bóng
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            EmitParticle(16);
            LogicManagerScript.Instance.audio.PlayPaddle();
            myRigidbody.velocity *= speedIncrease;
            LogicManagerScript.Instance.screenShake.StartShake(Mathf.Sqrt(myRigidbody.velocity.magnitude) * 0.02f, 0.075f);

        }

        if (collision.gameObject.layer == 7)
        {
            EmitParticle(8);
            LogicManagerScript.Instance.audio.PlayWall();
            myRigidbody.velocity *= speedIncrease;
            LogicManagerScript.Instance.screenShake.StartShake(0.033f, 0.033f);
        }
    }
    private void EmitParticle(int amount)
    {
        collisionParticle.Emit(amount);
    }
}
