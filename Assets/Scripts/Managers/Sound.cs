using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    public void PlaySound()
    {
        if (_clip != null && SoundsManager.instance != null)
        {
            SoundsManager.instance.PlaySound(_clip);
        }
    }
}