using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform playerTransform;//Player'i kontrol etmek i�in Player'in Transformunu ald�k.
    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        //Player'in x'i, y'si ve Kamera'n�n z'sini kameraya ata.(Oyun 2d, z haliyle kamera ile ayn�.)
    }
}
