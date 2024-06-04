using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemFallScript : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private FallType fallType;
    
    

   
    public void initData(FallType fallType)
    {
        this.fallType = fallType;
        this.gameObject.SetActive(true);
    }
    private void OnEnable()
    {
        StartCoroutine(coundown());
        
    }
    private IEnumerator coundown()
    {
        yield return new WaitForSeconds(5f);

        DestroyImmediate(this.gameObject);
       
    }
    void Update()

    {
        if (fallType == FallType.Down)

        { transform.Translate(Vector3.down * speed * Time.deltaTime); }//tạo chuyển động theo phương thẳng đứng hướng xuống với tốc độ trên theo thời gian

        if (fallType == FallType.Up )

        { transform.Translate(Vector3.up * speed * Time.deltaTime); }
        if (fallType == FallType.Left )

        { transform.Translate(Vector3.left  * speed * Time.deltaTime); }
        if (fallType == FallType.Right )

        { transform.Translate(Vector3.right  * speed * Time.deltaTime); }
        
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource audioSource = collision.GetComponent<AudioSource>();

        //play âm thanh từ component đó
        audioSource.Play();
        Debug.Log("Phát hiện va chạm giữ viên ngọc này và một game object collider khác!");
        Debug.Log("đang xử lý va chạm...");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("viên ngọc đã va chạm với game object có nhãn player");
            Destroy(gameObject);
            Debug.Log("đã xóa viên ngọc này ");
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("viên ngọc đã va chạm với game object có nhãn ground");
            Destroy(gameObject);
            Debug.Log("đã xóa viên ngọc này");
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("viên ngọc đã va chạm với game object có nhãn ground");
            Destroy(gameObject);
            Debug.Log("đã xóa viên ngọc này");
        }
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {

        
        Debug.Log("Phát hiện va chạm giữ viên ngọc này và một game object collider khác!");
        Debug.Log("đang xử lý va chạm...");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("viên ngọc đã va chạm với game object có nhãn player");
            Destroy(gameObject);
            Debug.Log("đã xóa viên ngọc này ");
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("viên ngọc đã va chạm với game object có nhãn ground");
            Destroy(gameObject);
            Debug.Log("đã xóa viên ngọc này");
        }
        AudioSource audioSource = other.GetComponent<AudioSource>();

        //play âm thanh từ component đó
        audioSource.Play();
        // các logic xử lý
        //Khai báo biến tên audioSource để gán thông tin và các hàm của audio component từ lệnh other.GetComponent<AudioSource>()
    }*/
    //Khai báo biến tên audioSource để gán thông tin và các hàm của audio component từ lệnh other.GetComponent<AudioSource>()


}
public enum FallType
{
   Up, 
   Down,
   Left,
   Right
}
