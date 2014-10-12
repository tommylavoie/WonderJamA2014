using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {

    public static SoundScript Instance;

    public AudioClip powerUpSound;
    public AudioClip playerAttackSound;
    public AudioClip enemyAttackSound;
    public AudioClip playerDeathSound;

	void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundScript!");
        }
        Instance = this;
    }

    public void MakePowerUpSound()
    {
        MakeSound(powerUpSound);
    }

    public void MakePlayerAttackSound()
    {
        MakeSound(playerAttackSound);
    }

    public void MakeenemyAttackSound()
    {
        MakeSound(enemyAttackSound);
    }

    public void MakePlayerDeathSound()
    {
        MakeSound(playerDeathSound);
    }

    private void MakeSound(AudioClip soundClip)
    {
        AudioSource.PlayClipAtPoint(soundClip, transform.position);
    }
    
}
