using UnityEngine;
public class StickyPlatform : MonoBehaviour
{
    //Box collider'a temas edince platformun �st�nde duruyor fakat bizi ta��m�yordu.
    //Bizi ta��mas� i�in bu scripti yazd�k.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")//E�er temas edilen objenin tag'� Player ise;
            collision.gameObject.transform.SetParent(transform);//Player'i Platform'un �ocu�u yap.
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")//E�er temastan ��k�lan objenin tag'� Player ise;
            collision.gameObject.transform.SetParent(null);//Parent'i null yap.
    }
    //Mant�k: Player platform'a temas edince onun �ocu�u olarak onunla birlikte sa�a sola hareket edecek.
    //Ondan ayr�l�nca da ebeveynlik ili�kisi bitmi� olacak. B�ylece Player'i ta��yabilece�iz. Mant�k bu.
}
