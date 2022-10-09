using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    public AudioSource finishSound;//Bitirme sesi.
    private bool levelCompleted = false;//Oyun tamamland� m�?
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();//AudioSource atamas�.
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        //E�er temas eden nesnenin tag'� Player ise ve oyun tamamlanmad� ise;
        {
            finishSound.Play();//Oyun bitirme sesini �al.
            levelCompleted = true;//Oyun bitti mi'yi true yap.
            Invoke("CompleteLevel", 2f);//2 sn sonra CompleteLevel fonksiyonunu �al��t�r.
        }
    }
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Level1'in index nosu 1, Level2'nin 2. mevcut sahneye +1 veriyoruz.
        //Level1'i tamamlay�nca Level2'ye ge�ecek. Mant�k bu.
    }
}
