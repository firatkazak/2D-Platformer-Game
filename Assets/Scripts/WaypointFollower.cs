using UnityEngine;
public class WaypointFollower : MonoBehaviour
{
    //Bu class B��a�a ve Bizi ta��yan platforma atan�yor. 2 tane noktan�n aras�nda gel git yapmas� i�in.
    //Platform bizi ta��yacak olan a ve b noktas� aras�nda gidip geliyor.
    //B��ak da yukar� a�a�� ya da sa�a sola hareket ederek bize zorluk ��kart�yor. Mant��� bu.
    public GameObject[] wayPoints;//A ve B noktalar� i�in Array haz�rlad�k.
    private int currentWayPointIndex = 0;//1. noktan�n indexini haliyle 0 yapt�k.
    private int speed = 2;//Gel git h�z�.
    public void Update()
    {
        if (Vector2.Distance(wayPoints[currentWayPointIndex].transform.position, transform.position) < 1)
            //E�er AveB noktas�n�n, mevcut index'inin pozisyonu ile mevcut nesnenin(b��ak ya da platform)aral���n fark� 1'den k���k ise;
            currentWayPointIndex++;//Mevcut mesafenin indexini 1 artt�r.
        if (currentWayPointIndex >= wayPoints.Length)
            //E�er mevcut mesafenin index'i, Mesafenin uzunlu�undan b�y�k ya da e�it ise;
            currentWayPointIndex = 0;//Mevcut mesafenin indexini 0 yap.
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWayPointIndex].transform.position, Time.deltaTime * speed);
        //Mevcut konumumuzdan hedefe kadar speed h�z�nda ta��. Bunu mevcut konuma ata.
        //Mant�k: Way Point(Var�lacak yer) ad�nda bo� game objeleri olu�turduk. S�rekli bu 2 way point aras�nda speed h�z�nda hareket edecek b��ak ve platform.
        //B�ylece platform bizi ta��maya yard�m edecek, b��ak da engel ��karacak. Olay bu.
    }
}
