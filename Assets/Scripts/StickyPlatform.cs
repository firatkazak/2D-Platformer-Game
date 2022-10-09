using UnityEngine;
public class StickyPlatform : MonoBehaviour
{
    //Box collider'a temas edince platformun üstünde duruyor fakat bizi taþýmýyordu.
    //Bizi taþýmasý için bu scripti yazdýk.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")//Eðer temas edilen objenin tag'ý Player ise;
            collision.gameObject.transform.SetParent(transform);//Player'i Platform'un çocuðu yap.
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")//Eðer temastan çýkýlan objenin tag'ý Player ise;
            collision.gameObject.transform.SetParent(null);//Parent'i null yap.
    }
    //Mantýk: Player platform'a temas edince onun çocuðu olarak onunla birlikte saða sola hareket edecek.
    //Ondan ayrýlýnca da ebeveynlik iliþkisi bitmiþ olacak. Böylece Player'i taþýyabileceðiz. Mantýk bu.
}
