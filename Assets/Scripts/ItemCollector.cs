using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;//Toplanan Viþnelerin sayýsý. Baþlangýç 0.
    public Text cherriesText;//Cherry sayýsýný göstereceðimiz Text.
    public AudioSource CollectionSourceEffect;//Viþne toplayýnca çýkacak ses.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))//Eðer Player Cherry'e temas ederse;
        {
            CollectionSourceEffect.Play();//Viþne toplama sesini çal.
            Destroy(collision.gameObject);//Viþneyi yok et.
            cherries++;//Cherry sayýsýný 1 arttýr.
            cherriesText.text = "Cherries: " + cherries;//Toplanan Viþneyi yazdýr. Örn; Cherries: 10
        }
    }
}
