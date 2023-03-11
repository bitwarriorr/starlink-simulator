using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public ParticleSystem explosion;
    public float respawnTime = 3.0f;
    public float respawnProtectionTime = 3.0f;

    public int lives = 3;

    public int score = 0;

    [SerializeField] public Text livesText;
    [SerializeField] public Text scoreText;
    [SerializeField] public Text gameOverText;

    private void Awake()
    {
        livesText.text = "" + lives;
    }

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        if (asteroid.size < 0.35f)
        {
            this.score += 100;
        }
        else if (asteroid.size < 0.5f)
        {
            this.score += 50;
        }
        else
        {
            this.score += 25;
        }

        scoreText.text = "" + score;
    }

    public void PlayerDied()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

        this.lives--;

        if (this.lives <= 0)
        {
            GameOver();
        }

        else
        {
            Invoke(nameof(Respawn), this.respawnTime);
        }

        livesText.text = "" + lives;
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;

        this.player.gameObject.layer = LayerMask.NameToLayer("IgnoreCollisions");

        this.player.gameObject.SetActive(true);

        Invoke(nameof(TurnOnCollision), respawnProtectionTime);

        gameOverText.gameObject.SetActive(false);
    }

    private void TurnOnCollision()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        this.lives = 3;
        this.score = 0;

        livesText.text = "" + lives;
        scoreText.text = "" + score;
        gameOverText.gameObject.SetActive(true);
        Invoke(nameof(Respawn), this.respawnTime);
    }
}
