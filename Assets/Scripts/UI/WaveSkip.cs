using UnityEngine;

public class WaveSkip : MonoBehaviour
{
    public void skipToLastWave()
    {
        WaveManager.wmInstance.waveSkip();
    }
}
