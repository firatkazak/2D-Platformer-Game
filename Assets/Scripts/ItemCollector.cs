using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;//Toplanan Vi�nelerin say�s�. Ba�lang�� 0.
    public Text cherriesText;//Cherry say�s�n� g�sterece�imiz Text.
    public AudioSource CollectionSourceEffect;//Vi�ne toplay�nca ��kacak ses.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))//E�er Player Cherry'e temas ederse;
        {
            CollectionSourceEffect.Play();//Vi�ne toplama sesini �al.
            Destroy(collision.gameObject);//Vi�neyi yok et.
            cherries++;//Cherry say�s�n� 1 artt�r.
            cherriesText.text = "Cherries: " + cherries;//Toplanan Vi�neyi yazd�r. �rn; Cherries: 10
        }
    }
}
