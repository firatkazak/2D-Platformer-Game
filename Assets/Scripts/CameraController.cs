using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform playerTransform;//Player'i kontrol etmek için Player'in Transformunu aldýk.
    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        //Player'in x'i, y'si ve Kamera'nýn z'sini kameraya ata.(Oyun 2d, z haliyle kamera ile ayný.)
    }
}
