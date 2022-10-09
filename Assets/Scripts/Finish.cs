using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    public AudioSource finishSound;//Bitirme sesi.
    private bool levelCompleted = false;//Oyun tamamlandý mý?
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();//AudioSource atamasý.
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        //Eðer temas eden nesnenin tag'ý Player ise ve oyun tamamlanmadý ise;
        {
            finishSound.Play();//Oyun bitirme sesini çal.
            levelCompleted = true;//Oyun bitti mi'yi true yap.
            Invoke("CompleteLevel", 2f);//2 sn sonra CompleteLevel fonksiyonunu çalýþtýr.
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Level1'in index nosu 1, Level2'nin 2. mevcut sahneye +1 veriyoruz.
        //Level1'i tamamlayýnca Level2'ye geçecek. Mantýk bu.
    }
}
