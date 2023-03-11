using UnityEngine;

public class ThrustCheckImproved : MonoBehaviour
{
    [SerializeField] public ParticleSystem rocketL;
    [SerializeField] public ParticleSystem rocketR;
    [SerializeField] public ParticleSystem turningL;
    [SerializeField] public ParticleSystem turningR;

    private void Awake()
    {
        rocketL.Stop();
        rocketR.Stop();
        turningL.Stop();
        turningR.Stop();
    }
    private void Update()
    {
        Thrusting();
        TurningL();
        TurningR();
    }

    private void Thrusting()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rocketL.Play();
            rocketR.Play();
        }

        else
        {
            rocketL.Stop();
            rocketR.Stop();
        }
    }

    private void TurningL()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            turningL.Play();
        }

        else
        {
            turningL.Stop();
        }
    }

    private void TurningR()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            turningR.Play();
        }

        else
        {
            turningR.Stop();
        }
    }

}
