using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public GameObject particleEffectPrefab; // Inspector에서 할당

    private void OnCollisionEnter(Collision collision)
    {
        // 이 오브젝트가 Player인지 검사
        if (CompareTag("Player"))
        {
            // 자신의 위치에서 파티클 생성
            GameObject particle = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
            Destroy(particle, 1f); // 0.5초 뒤 파티클 제거


        }
    }
}
