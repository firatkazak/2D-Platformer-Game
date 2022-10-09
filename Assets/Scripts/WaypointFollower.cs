using UnityEngine;
public class WaypointFollower : MonoBehaviour
{
    //Bu class Býçaða ve Bizi taþýyan platforma atanýyor. 2 tane noktanýn arasýnda gel git yapmasý için.
    //Platform bizi taþýyacak olan a ve b noktasý arasýnda gidip geliyor.
    //Býçak da yukarý aþaðý ya da saða sola hareket ederek bize zorluk çýkartýyor. Mantýðý bu.
    public GameObject[] wayPoints;//A ve B noktalarý için Array hazýrladýk.
    private int currentWayPointIndex = 0;//1. noktanýn indexini haliyle 0 yaptýk.
    private int speed = 2;//Gel git hýzý.
    public void Update()
    {
        if (Vector2.Distance(wayPoints[currentWayPointIndex].transform.position, transform.position) < 1)
            //Eðer AveB noktasýnýn, mevcut index'inin pozisyonu ile mevcut nesnenin(býçak ya da platform)aralýðýn farký 1'den küçük ise;
            currentWayPointIndex++;//Mevcut mesafenin indexini 1 arttýr.
        if (currentWayPointIndex >= wayPoints.Length)
            //Eðer mevcut mesafenin index'i, Mesafenin uzunluðundan büyük ya da eþit ise;
            currentWayPointIndex = 0;//Mevcut mesafenin indexini 0 yap.
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWayPointIndex].transform.position, Time.deltaTime * speed);
        //Mevcut konumumuzdan hedefe kadar speed hýzýnda taþý. Bunu mevcut konuma ata.
        //Mantýk: Way Point(Varýlacak yer) adýnda boþ game objeleri oluþturduk. Sürekli bu 2 way point arasýnda speed hýzýnda hareket edecek býçak ve platform.
        //Böylece platform bizi taþýmaya yardým edecek, býçak da engel çýkaracak. Olay bu.
    }
}
