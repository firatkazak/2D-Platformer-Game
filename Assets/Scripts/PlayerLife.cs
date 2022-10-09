using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    private Animator anim;//�lme animasyonu i�in.
    private Rigidbody2D playerRb;//Player'in rigidbody'si.
    public AudioSource deathSoundEffect;//�l�m sesi.
    private void Start()
    {
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        //Atamalar.
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
            //E�er Player, Trap(tuzak) ile temas ederse;
            Die();//�lme fonksiyonunu �al��t�r.
    }
    private void Die()
    {
        deathSoundEffect.Play();//�lme sesini oynat.
        playerRb.bodyType = RigidbodyType2D.Static;//Player'in Rigidbody'sini Statik yap.
        //Statik dura�an demek. �l�nce hi� hareket edemeyecek yani. Mant�k bu.
        anim.SetTrigger("death");//�lme animasyonunu oynat.
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Aktif sahneyi ba�tan ba�lat.
        //Animasyon'a girdik. Death animasyonunun son sahnesinden 1 kare gittik. Sprite Renderer'i kapatt�k.
        //Tam o noktada bu fonksiyonu Animation event ile oradan oynatt�k.
        //Yani Death animasyonu bitince 1 kare Sprite renderer kapanacak, karakter yok olacak ve oyun ayn� sahnede ba�tan ba�layacak.
    }
}
