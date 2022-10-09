using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    private Animator anim;//Ölme animasyonu için.
    private Rigidbody2D playerRb;//Player'in rigidbody'si.
    public AudioSource deathSoundEffect;//Ölüm sesi.
    private void Start()
    {
        anim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody2D>();
        //Atamalar.
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
            //Eðer Player, Trap(tuzak) ile temas ederse;
            Die();//Ölme fonksiyonunu çalýþtýr.
    }
    private void Die()
    {
        deathSoundEffect.Play();//Ölme sesini oynat.
        playerRb.bodyType = RigidbodyType2D.Static;//Player'in Rigidbody'sini Statik yap.
        //Statik duraðan demek. Ölünce hiç hareket edemeyecek yani. Mantýk bu.
        anim.SetTrigger("death");//Ölme animasyonunu oynat.
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Aktif sahneyi baþtan baþlat.
        //Animasyon'a girdik. Death animasyonunun son sahnesinden 1 kare gittik. Sprite Renderer'i kapattýk.
        //Tam o noktada bu fonksiyonu Animation event ile oradan oynattýk.
        //Yani Death animasyonu bitince 1 kare Sprite renderer kapanacak, karakter yok olacak ve oyun ayný sahnede baþtan baþlayacak.
    }
}
