using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBullet : MonoBehaviour {

    public float timeBetweenBullets = 0.15f;
    public GameObject projectile;
    //bullet info

    public Slider playerManaSlider;
    public int maxRounds;
    public int startingRounds;
    int remainingRounds;
    float nextBullet;

    //audio info
    AudioSource LampMuzzleAS;
    public AudioClip shootSounds;
    public AudioClip reloadSounds;

    //graphic info
    public Sprite weaponSprite;
    public Image weaponImage;

	void Awake () {
        nextBullet = 0f;
        remainingRounds = startingRounds;
        playerManaSlider.maxValue = maxRounds;
        playerManaSlider.value = remainingRounds;
        LampMuzzleAS = GetComponent<AudioSource>();
	}
	
	void Update () {
        PlayerController myPlayer = transform.root.GetComponent<PlayerController>();

        if (Input.GetAxisRaw("Fire1")>0 && nextBullet < Time.time && remainingRounds >0)
        {
            nextBullet = Time.time + timeBetweenBullets;
            Vector3 rot;
            if (myPlayer.GetFacing() == -1f)
            {
                rot = new Vector3(0, -90, 0);
            }
            else rot = new Vector3(0, 90, 0);

            Instantiate(projectile, transform.position, Quaternion.Euler(rot));

            PlayASound(shootSounds);

            remainingRounds -= 1;
            playerManaSlider.value = remainingRounds;
        }
	}

    public void Reload()
    {
        remainingRounds = maxRounds;
        playerManaSlider.value = remainingRounds;
        PlayASound(reloadSounds);

    }

    void PlayASound(AudioClip playTheSound)
    {
        LampMuzzleAS.clip = playTheSound;
        LampMuzzleAS.Play();
    }

    public void initializeWeapon()
    {
        LampMuzzleAS.clip = reloadSounds;
        LampMuzzleAS.Play();
        nextBullet = 0;
        playerManaSlider.maxValue = maxRounds;
        playerManaSlider.value = remainingRounds;
        weaponImage.sprite = weaponSprite;
    } 
}
